using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Drawing;

/*TODO:
    - map all language codes from MS Word to ISO codes
*/

namespace languagetool_msword10_addin
{
    public partial class ThisAddIn
    {
        private readonly int maxSuggestions = 12;

        static public CheckingForm myCheckingForm = new CheckingForm();
        static public dynamic parsedResultsCurrentPara;
        static public int errorNumberCurrentPara;
        static public Word.Range rangeToCheck;
        static public int rangeToCheckStart;
        static public int accumulatedOffset;
        static public int errorOffset;
        static public int errorLength;
        static public bool updatedContext;
        static public bool preparingDialog;
        static public int contextLength;
        static public int contextOffset;
        static public List<string> ignoredWords;
        static public string correctionLanguageCode;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ignoredWords = new List<string>();
        }


        /****** Check with Dialog******/

        public static void checkCurrentParagraph()
        {
            Microsoft.Office.Interop.Word.Document Doc = Globals.ThisAddIn.Application.ActiveDocument;
            if (Doc == null || Doc.ReadOnly)
                return;
            rangeToCheck = Globals.ThisAddIn.Application.Selection.Range;
            rangeToCheck.Start = rangeToCheck.Paragraphs.First.Range.Start;
            rangeToCheck.End = rangeToCheck.Paragraphs.First.Range.End;
            rangeToCheckStart = rangeToCheck.Start;
            if (rangeToCheck.Text.Equals("\u0002 \r"))  // avoid checking empty footnotes
            {
                parsedResultsCurrentPara = null;
                return;
            }
            String textToCheck = rangeToCheck.Text.ToString();
            String results = getResultsFromServer(rangeToCheck.LanguageID.ToString(), textToCheck);
            parsedResultsCurrentPara = ParseJSONResults(results);
            accumulatedOffset = 0;
            errorNumberCurrentPara = 0;
        }

        public static void prepareDialog()
        {
            while (parsedResultsCurrentPara == null || errorNumberCurrentPara >= parsedResultsCurrentPara.Length)
            {
                Word.Range newRange = rangeToCheck;
                int desiredRangeStart = rangeToCheck.Paragraphs.Last.Range.End + 1;
                newRange.Start = desiredRangeStart;
                newRange.End = newRange.Start;
                if (newRange.Start < desiredRangeStart)
                {
                    myCheckingForm.finalize();
                    return;
                }
                newRange.Select();
                checkCurrentParagraph();
            }

            dynamic myerror = parsedResultsCurrentPara[errorNumberCurrentPara];

            errorOffset = myerror["offset"];

            int beforeLength = myerror["context"]["offset"];
            errorLength = myerror["length"];
            string contextStr = myerror["context"]["text"];
            int afterLength = contextStr.Length - errorLength - beforeLength;

            string beforeErrorStr = contextStr.Substring(0, beforeLength);
            string errorStr = contextStr.Substring(beforeLength, errorLength);
            string afterErrorStr = contextStr.Substring(beforeLength + errorLength, afterLength);

            contextLength = beforeLength + errorLength + afterLength;
            contextOffset = errorOffset - beforeLength;

            Word.Range rangeToReplace = rangeToCheck;
            rangeToReplace.Start = rangeToCheckStart + accumulatedOffset + errorOffset;
            rangeToReplace.End = rangeToReplace.Start + errorLength;
            rangeToReplace.Select();

            if (rangeToReplace.Text != errorStr 
                || ignoredWords.Contains(rangeToReplace.Text))
            {
                errorNumberCurrentPara++;
                prepareDialog();
                return;
            }
            preparingDialog = true;
            myCheckingForm.contextTextBox.Clear();
            myCheckingForm.contextTextBox.Text = "";
            myCheckingForm.suggestionsBox.Items.Clear();

            System.Drawing.Color myErrorColor = Color.Blue;
            String myIssueType = myerror["rule"]["issueType"];
            switch (myIssueType)
            {
                case "misspelling":
                    myErrorColor = Color.Red;
                    break;
                case "style":
                case "registrer":
                case "locale-violation":
                    myErrorColor = Color.Green;
                    break;
            }
            myCheckingForm.contextTextBox.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular); 
            myCheckingForm.contextTextBox.SelectionColor = Color.Black;
            myCheckingForm.contextTextBox.AppendText(beforeErrorStr);
            myCheckingForm.contextTextBox.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            myCheckingForm.contextTextBox.SelectionColor = myErrorColor;
            myCheckingForm.contextTextBox.AppendText(errorStr);
            myCheckingForm.contextTextBox.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
            myCheckingForm.contextTextBox.SelectionColor = Color.Black;
            myCheckingForm.contextTextBox.AppendText(afterErrorStr);
            updatedContext = false;

            myCheckingForm.messageBox.Text = myerror["message"];
            if (myerror["rule"]["urls"] != null && myerror["rule"]["urls"][0]["value"].Length > 3)
            {
                LinkLabel.Link link = new LinkLabel.Link();
                link.LinkData = myerror["rule"]["urls"][0]["value"];
                myCheckingForm.moreinfoLinkLabel.Text = Resources.WinFormStrings.more_information;
                myCheckingForm.moreinfoLinkLabel.Links.Add(0, 14, link);
            }
            else
            {
                myCheckingForm.moreinfoLinkLabel.Text = "";
                myCheckingForm.moreinfoLinkLabel.Links.Clear();
            }
            myCheckingForm.languageBox.Text = Resources.WinFormStrings.language + ": " + getLanguageName(correctionLanguageCode);
            myCheckingForm.servernameBox.Text = Resources.WinFormStrings.LT_server + ": " + Properties.Settings.Default.LTServer.ToString();
            
            if (myerror["replacements"].Length > 0)
            {
                int i = 0;
                while (i < myerror["replacements"].Length && i < Globals.ThisAddIn.maxSuggestions)
                {
                    myCheckingForm.suggestionsBox.Items.Add(myerror["replacements"][i]["value"]);
                    i++;
                }
                myCheckingForm.suggestionsBox.SetSelected(0, true);
                myCheckingForm.changeSuggestion.Enabled = true;
            }
            else
            {
                myCheckingForm.changeSuggestion.Enabled = false;
            }
            preparingDialog = false;
            myCheckingForm.suggestionsBox.Enabled = true;
        }

        public static void checkOnDialogStart()
        {
            ignoredWords.Clear();
            checkCurrentParagraph();
            prepareDialog();
            if (parsedResultsCurrentPara == null
                || parsedResultsCurrentPara.Count < 1)
            {
                MessageForm myMessageForm = new MessageForm();
                myMessageForm.ShowDialog();
            }
            else
            {
                myCheckingForm.suggestionsBox.Enabled = true;
                myCheckingForm.ShowDialog();
            }
            
        }

        public static void checkOnDialogChange(string replacement)
        {          
            Word.Range rangeToReplace = rangeToCheck;
            if (!updatedContext)
            {
                rangeToReplace.Start = rangeToCheckStart + accumulatedOffset + errorOffset;
                rangeToReplace.End = rangeToReplace.Start + errorLength;
                rangeToReplace.Text = replacement;
                accumulatedOffset += replacement.Length - errorLength;
            }
            else
            {
                string updatedContext = myCheckingForm.contextTextBox.Text;
                if (updatedContext.StartsWith("..."))
                {
                    contextLength = contextLength - 3;
                    contextOffset = contextOffset + 3;
                    updatedContext = updatedContext.Substring(3);
                }
                if (updatedContext.EndsWith("..."))
                {
                    contextLength = contextLength - 3;
                    updatedContext = updatedContext.Substring(0, updatedContext.Length - 3);
                }
                rangeToReplace.Start = rangeToCheckStart + accumulatedOffset + contextOffset;
                rangeToReplace.End = rangeToReplace.Start + contextLength;
                rangeToReplace.Text = updatedContext;
                accumulatedOffset += updatedContext.Length - contextLength;
            }
            rangeToReplace.Select();
            
            errorNumberCurrentPara++;
            prepareDialog();
        }

        internal static void checkOnDialogIgnore()
        {
            errorNumberCurrentPara++;
            prepareDialog();
        }

        internal static void checkOnDialogIgnoreAlways()
        {
            Word.Range rangeToIgnore = rangeToCheck;
            rangeToIgnore.Start = rangeToCheckStart + accumulatedOffset + errorOffset;
            rangeToIgnore.End = rangeToIgnore.Start + errorLength;
            ignoredWords.Add(rangeToIgnore.Text);
            errorNumberCurrentPara++;
            prepareDialog();
        }

        // End of Check with Dialog


        /*private static List<Dictionary<string, string>> ParseXMLResults(String xmlString)
        {
            if (string.IsNullOrWhiteSpace(xmlString))
                return null;
            XElement xml = XElement.Parse(xmlString);
            var suggestions = new List<Dictionary<string, string>>();

            foreach (var myerror in xml.Descendants("error"))
            {
                var suggestion = new Dictionary<string, string>();
                foreach (var myattribute in myerror.Attributes())
                {
                    suggestion.Add(myattribute.Name.ToString(), myattribute.Value);
                }
                suggestions.Add(suggestion);
            }
            return suggestions;
        }*/

        private static dynamic ParseJSONResults(String jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
                return null;
            dynamic json = System.Web.Helpers.Json.Decode(jsonString);
            dynamic matches = json["matches"];
            return matches;
        }

        private static string getLanguageCode(string langID)
        {
            //Missing: Tagalog, Asturian, Breton, Esperanto
            switch (langID)
            {
                case "wdCatalan":
                    if (Properties.Settings.Default.CatalanUserPreferences.StartsWith("valencià"))
                        return "ca-ES-valencia";
                    else
                        return "ca-ES";
                case "wdEnglishUS":
                    return "en-US";
                case "wdEnglishUK":
                    return "en-GB";
                case "wdEnglishAUS":
                    return "en-AU";
                case "wdEnglishCanadian":
                    return "en-CA";
                case "wdEnglishNewZealand":
                    return "en-NZ";
                case "wdEnglishSouthAfrica":
                    return "en-ZA";
                case "wdFrench":
                    return "fr";
                case "wdGerman":
                    return "de-DE";
                case "wdGermanAustria":
                    return "de-AT";
                case "wdSwissGerman":
                    return "de-CH";
                case "wdItalian":
                    return "it";
                case "wdPolish":
                    return "pl-PL";
                case "wdByelorussian":
                    return "be-BY";
                case "wdPortuguese":
                    return "pt-PT";
                case "wdPortugueseBrazil":
                    return "pt-BR";
                case "wdSimplifiedChinese":
                    return "zh-CN";
                case "wdDanish":
                    return "da-DK";
                case "wdGalician":
                    return "gl-ES";
                case "wdGreek":
                    return "el-GR";
                case "wdIcelandic":
                    return "is-IS";
                case "wdJapanese":
                    return "ja-JP";
                case "wdKhmer":
                    return "km-KH";
                case "wdLithuanian":
                    return "lt-LT";
                case "wdMalayalam":
                    return "ml-IN";
                case "wdPersian":
                    return "fa";
                case "wdRomanian":
                    return "ro-RO";
                case "wdRussian":
                    return "ru-RU";
                case "wdDutch":
                    return "nl";
                case "wdSlovak":
                    return "sk-SK";
                case "wdSlovenian":
                    return "sl-SI";
                case "wdSwedish":
                    return "sv";
                case "wdTamil":
                    return "ta-IN";
                case "1150":
                    return "br-FR";
                case "wdUkrainian":
                    return "uk-UA";
            }
            if (langID.StartsWith("wdEnglish"))
                return "en-US";
            if (langID.StartsWith("wdSpanish"))
                return "es";
            return (Properties.Settings.Default.DefaultLanguage);
        }

        private static string getUrlParameters(string langID)
        {
            string enabledRules = "";
            string disabledRules = "";
            string urlParameters = "";
            if (langID.Equals("wdCatalan")) {
                switch (Properties.Settings.Default.CatalanUserPreferences)
                {
                    case "general":
                        enabledRules += ",EXIGEIX_PLURALS_S";
                        break;
                    case "valencià":
                        break;
                    case "valencià (accentuació general)":
                        disabledRules += ",EXIGEIX_ACCENTUACIO_VALENCIANA";
                        enabledRules += ",EXIGEIX_ACCENTUACIO_GENERAL";
                        break;
                    case "balear":
                        enabledRules += ",EXIGEIX_VERBS_BALEARS";
                        disabledRules += ",EXIGEIX_VERBS_CENTRAL";
                        break;
                }
                if (Properties.Settings.Default.TypographyRulesEnabled)
                {
                    enabledRules += ",PRIORITZAR_COMETES,GUIONET_GUIO,COMETES_TIPOGRAFIQUES," 
                        +" GUIO_SENSE_ESPAI,APOSTROF_TIPOGRAFIC,PUNTS_SUSPENSIUS,EVITA_EXCLAMACIO_INICIAL";
                }
            }
            if (disabledRules.Length > 0)
                urlParameters += "&disabledRules=" + disabledRules;
            if (enabledRules.Length > 0)
                urlParameters += "&enabledRules=" + enabledRules;
            return urlParameters;
        }
        private static string getResultsFromServer(string langID, string textToCheck)
        {
            if (string.IsNullOrWhiteSpace(textToCheck)) {
                return "";
            }
            correctionLanguageCode = getLanguageCode(langID);
            textToCheck = textToCheck.Replace("\u0002", "*"); //char used for footnote references 
            string uriString = Properties.Settings.Default.LTServer + "check?language=" + correctionLanguageCode
                + "&text=" + WebUtility.UrlEncode(textToCheck) + getUrlParameters(langID);
            //uriString = uriString.Replace("%C2%A0", "+"); // replace non-breaking space. Why?
            uriString = uriString.Replace("%0B", "%A0"); // replace "vertical-tab". Why?
            Uri uri = new Uri(uriString); //TODO set a limit of length
            string result = "";
            try
            {
                // Create the web request  
                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(uri) 
                    as System.Net.HttpWebRequest;
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream(), 
                        System.Text.Encoding.UTF8);
                    // Read the whole contents and return as a string  
                    result = reader.ReadToEnd();
                }
                return result;
            }
            catch //(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(Resources.WinFormStrings.unable_to_connect_to_server + ": "
                    + Properties.Settings.Default.LTServer 
                    /*+ " URL: " + uri.ToString()
                    + " RESULT: " + result
                    + " EXCEPTION: " + e.ToString()*/);
            }
            return "";
        }

        public static string getLanguageName(string ISOCode)
        {
            return Resources.WinFormStrings.ResourceManager.GetString(ISOCode.Replace("-", "_"));
        }

        public static List<string> getLanguagesList()
        {
            var languages = new List<string>();
            languages.Add("ast-ES");
            languages.Add("be-BY");
            languages.Add("br-FR");
            languages.Add("ca-ES");
            languages.Add("ca-ES-valencia");
            languages.Add("zh-CN");
            languages.Add("da-DK");
            languages.Add("nl");
            languages.Add("en");
            languages.Add("en-AU");
            languages.Add("en-CA");
            languages.Add("en-GB");
            languages.Add("en-NZ");
            languages.Add("en-ZA");
            languages.Add("en-US");
            languages.Add("eo");
            languages.Add("fr");
            languages.Add("gl-ES");
            languages.Add("de");
            languages.Add("de-AT");
            languages.Add("de-DE");
            languages.Add("de-CH");
            languages.Add("el-GR");
            languages.Add("is-IS");
            languages.Add("it");
            languages.Add("ja-JP");
            languages.Add("km-KH");
            languages.Add("lt-LT");
            languages.Add("ml-IN");
            languages.Add("fa");
            languages.Add("pl-PL");
            languages.Add("pt");
            languages.Add("pt-BR");
            languages.Add("pt-PT");
            languages.Add("ro-RO");
            languages.Add("ru-RU");
            languages.Add("de-DE-x-simple-language");
            languages.Add("sk-SK");
            languages.Add("sl-SI");
            languages.Add("es");
            languages.Add("sv");
            languages.Add("tl-PH");
            languages.Add("ta-IN");
            languages.Add("uk-UA");
            return languages;

            /* gets the list of available languages from the server (it is sometimes slow)
            string xmlResults = "";
            string uri = Properties.Settings.Default.LTServer + "Languages";
            try
            {
                // Create the web request  
                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(uri)
                    as System.Net.HttpWebRequest;
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream(),
                        System.Text.Encoding.UTF8);
                    // Read the whole contents and return as a string  
                    xmlResults = reader.ReadToEnd();
                }
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show("No es pot contactar amb el servidor: "
                //    + Properties.Settings.Default.LTServer + ".");
            }        
            if (!string.IsNullOrWhiteSpace(xmlResults))
            {            
                XElement xml = XElement.Parse(xmlResults);
                foreach (var lang in xml.Descendants("language"))
                    languages.Add(lang.Attribute("name").Value, lang.Attribute("abbrWithVariant").Value);
            }*/
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
