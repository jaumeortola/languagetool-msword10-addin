using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.IO;
using System.Web;
using System.Net;
using System.Xml;
using Microsoft.Office.Interop.Word;

namespace languagetool_msword10_addin
{
    public partial class ThisAddIn
    {
        Word.Application application;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            application = this.Application;
            application.WindowBeforeRightClick +=
                new Word.ApplicationEvents4_WindowBeforeRightClickEventHandler(application_WindowBeforeRightClick);

            application.CustomizationContext = application.ActiveDocument;

            //Office.CommandBar commandBar = application.CommandBars.Add("LTShortcutMenu", Microsoft.Office.Core.MsoBarPosition.msoBarPopup, flase, true);

        }

        public void application_WindowBeforeRightClick(Word.Selection selection, ref bool Cancel)
        {
            if (selection != null && !String.IsNullOrEmpty(selection.Text))
            {
                string selectionText = selection.Text;

                Office.CommandBar commandBar = application.CommandBars["Text"];

                if (selection.Font.Underline == WdUnderline.wdUnderlineWavy)
                {
                    Office.CommandBarButton button = (Office.CommandBarButton)commandBar.Controls.Add(
                        Office.MsoControlType.msoControlButton); //                   

                    button.accName = "LanguageTool";
                    button.Caption = "LanguageTool";

                }
                else
                {
                    try
                    {
                        if (commandBar.Controls["LanguageTool"] != null)
                        {
                            commandBar.Controls["LanguageTool"].Delete();
                        }
                    }
                    catch
                    {

                    }

                }

            }
        }

        // Handles the event when a button on the new toolbar is clicked. 
        private void ButtonClick(Office.CommandBarButton ctrl, ref bool cancel)
        {
            System.Windows.Forms.MessageBox.Show("You clicked: " + ctrl.Caption);
        }

        public static void CheckActiveDocument()
        {
            //Dóna error si és un document protegit contra escriptura, p. ex. perquè ve d'Internet
            Microsoft.Office.Interop.Word.Document Doc = Globals.ThisAddIn.Application.ActiveDocument;
            if (Doc == null || Doc.ReadOnly)
            {
                return;
            }
            RemoveAllErrorMarks();
            try
            {
                //TODO Troba el primer paràgraf visible, i a partir d'aquest revisa només una certa quantitat de text.
                Word.Paragraph firstPara = Doc.Paragraphs.First;
                int numParagraphs = Doc.Paragraphs.Count;
                for (int i = 1; i <= numParagraphs; i++)
                {
                    Word.Paragraph para = firstPara.Next(i - 1);
                    Word.Range myrange = para.Range;
                    String paraStr = para.Range.Text.ToString();
                    String lang = GetLanguageISO(para.Range.LanguageID.ToString());
                    //System.Windows.Forms.MessageBox.Show("El paràgraf núm. " + i + " en " + lang);
                    String uriString = "https://www.softcatala.org/languagetool/api/checkDocument?language=" + lang + "&text=" + WebUtility.UrlEncode(paraStr);
                    uriString = uriString.Replace("%C2%A0", "+"); // ????
                    Uri uri = new Uri(uriString);
                    //System.Windows.Forms.MessageBox.Show(uriString);
                    String results = GetResultsFrom(uri);
                    //System.Windows.Forms.MessageBox.Show(results);

                    int myParaOffset = 0;

                    foreach (var myerror in ParseXMLResults(results))
                    {
                        int errorStart = para.Range.Start + int.Parse(myerror["offset"]) + myParaOffset;
                        int errorEnd = errorStart + int.Parse(myerror["errorlength"]);
                        Word.Range rng = Doc.Range(errorStart, errorEnd);
                        Word.WdColor mycolor = Word.WdColor.wdColorBlue;
                        switch (myerror["locqualityissuetype"])
                        {
                            case "misspelling":
                                mycolor = Word.WdColor.wdColorRed;
                                break;
                            case "style":
                            case "locale-violation":
                                mycolor = Word.WdColor.wdColorGreen;
                                break;
                        }
                        bool isTrackingRevisions = Doc.TrackRevisions;
                        Doc.TrackRevisions = false;
                        rng.Font.Underline = WdUnderline.wdUnderlineWavy;//  wdUnderlineWavyHeavy;
                        rng.Font.UnderlineColor = mycolor;

                        string errorData = "{{" + myerror["msg"] + "|" + myerror["replacements"] + "}}";
                        myParaOffset += errorData.Length;

                        Word.Range newRng = Doc.Range(errorEnd, errorEnd);
                        newRng.Text = errorData;
                        newRng.Font.Hidden = 1;

                        //Field myfield = Doc.Fields.Add(rng, Word.WdFieldType.wdFieldPrivate, Type.Missing, Type.Missing);
                        //myfield.Data = myerror["msg"];
                        //Doc.Comments.Add(rng, myerror["msg"]);
                        Doc.TrackRevisions = isTrackingRevisions;
                        //System.Windows.Forms.MessageBox.Show(int.Parse(myerror["offset"]) + " " + int.Parse(myerror["errorlength"]) + " " + errorStart + " " + errorEnd );
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception if for some reason the document is not available.
            }

        }

        public static void RemoveAllErrorMarks()
        {
            Microsoft.Office.Interop.Word.Document Doc = Globals.ThisAddIn.Application.ActiveDocument;
            if (Doc == null || Doc.ReadOnly)
            {
                return;
            }
            bool isTrackingRevisions = Doc.TrackRevisions;
            Doc.TrackRevisions = false;
            //options
            object findText = "";
            object replaceWithText = "";
            object matchCase = false;
            object matchWholeWord = false;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = true;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = WdReplace.wdReplaceAll;
            object wrap = WdFindWrap.wdFindContinue;
            Word.Range rng = Doc.Content;
            rng.Find.ClearFormatting();
            rng.Find.Replacement.ClearFormatting();
            rng.Find.Font.Underline = WdUnderline.wdUnderlineWavy;
            rng.Find.Replacement.Font.Underline = WdUnderline.wdUnderlineNone;
            //execute find and replace
            rng.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
            //Remove hidden data
            findText = "*";
            replaceWithText = "";
            matchWildCards = true;
            replace = WdReplace.wdReplaceAll;
            wrap = WdFindWrap.wdFindContinue;
            rng.Find.ClearFormatting();
            rng.Find.Replacement.ClearFormatting();
            rng.Find.Font.Hidden = 1;
            //execute find and replace
            rng.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);

            Doc.TrackRevisions = isTrackingRevisions;
        }

        private static List<Dictionary<string, string>> ParseXMLResults(String xmlString)
        {
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
        }

        //S'hauria de fer d'una altra manera!
        private static String GetLanguageISO(String langObj)
        {
            switch (langObj)
            {
                case "wdCatalan":
                    return "ca";
                case "wdEnglishUS":
                    return "en-US";
                default:
                    return ("");
            }
        }

        private static string GetResultsFrom(Uri address)
        {
            string result = "";
            // Create the web request  
            System.Net.HttpWebRequest request = System.Net.WebRequest.Create(address) as System.Net.HttpWebRequest;
            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                // Read the whole contents and return as a string  
                result = reader.ReadToEnd();
            }
            return result;
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
