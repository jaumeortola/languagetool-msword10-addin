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
using Microsoft.Office.Tools;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace languagetool_msword10_addin
{
    public partial class ThisAddIn
    {
        private readonly int maxSuggestions = 10;
        private readonly String LTServer = "https://www.softcatala.org/languagetool/api/checkDocument";
        Word.Application application;
        private TaskPaneControl taskPaneControl1;
        private Microsoft.Office.Tools.CustomTaskPane taskPaneValue;
        private List<int> buttonsIds = new List<int>();
        
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            application = this.Application;
            application.WindowBeforeRightClick +=
                new Word.ApplicationEvents4_WindowBeforeRightClickEventHandler(application_WindowBeforeRightClick);

            application.CustomizationContext = application.ActiveDocument;

            taskPaneControl1 = new TaskPaneControl();
            taskPaneValue = this.CustomTaskPanes.Add(
                taskPaneControl1, "Revisió amb LanguageTool");
            taskPaneValue.VisibleChanged +=
                new EventHandler(taskPaneValue_VisibleChanged);
            taskPaneValue.Visible = false;
            taskPaneValue.Width = 300;
        }

        private void taskPaneValue_VisibleChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.Ribbon1.toggleButton1.Checked =
                taskPaneValue.Visible;
        }

        public Microsoft.Office.Tools.CustomTaskPane TaskPane
        {
            get
            {
                return taskPaneValue;
            }
        }

        public object Controls { get; private set; }
        

        public void application_WindowBeforeRightClick(Word.Selection selection, ref bool Cancel)
        {
            if (selection != null && !String.IsNullOrEmpty(selection.Text))
            {
                string selectionText = selection.Text;
                Office.CommandBar commandBar = application.CommandBars["Text"];

                foreach (int buttonId in buttonsIds)
                {
                    commandBar.FindControl(Type.Missing, buttonId, Type.Missing , false, false).Delete();
                }
                buttonsIds.Clear();

                if (selection.Font.Underline == WdUnderline.wdUnderlineWavy)
                {
                    Regex regex = new Regex("\\[(.*)\\|(.*)\\]");
                    Match match = regex.Match(findHiddenData(selection));
                    if (match.Success)
                    {
                        Office.CommandBarButton button1 = (Office.CommandBarButton)commandBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, "info_error", 1, true);
                        button1.Tag = "LTMessage";
                        button1.Caption = match.Groups[1].Value;
                        button1.Enabled = false;
                        button1.Picture = getImage();
                        buttonsIds.Add(button1.Id);
                        
                        String[] suggestions = match.Groups[2].Value.Split('#');
                        if (suggestions.Length > 0 && suggestions[0].Length > 0)
                        {
                            int i = 0;
                            while (i<suggestions.Length && i< maxSuggestions) { 
                                Office.CommandBarButton button2 = (Office.CommandBarButton)commandBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, suggestions[i], i+2, true);
                                button2.Tag = "LTSuggestion" + i;
                                button2.Caption = suggestions[i];
                                buttonsIds.Add(button2.Id);
                                button2.Click +=  new Office._CommandBarButtonEvents_ClickEventHandler(LTbutton_Click);
                                i++;
                            }
                        }
                    }
                }

            }
        }

        public void LTbutton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            //Select underlined words and replace with selected suggestion
            Word.Range rng = Globals.ThisAddIn.Application.Selection.Range;

            //Word.Range rng = selection.Range;
            object findText = Type.Missing; object matchCase = Type.Missing; object matchWholeWord = Type.Missing; object matchWildCards = Type.Missing; object matchSoundsLike = Type.Missing;
            object matchAllWordForms = Type.Missing; object forward = Type.Missing; object wrap = Type.Missing; object format = Type.Missing; object replaceWithText = Type.Missing;
            object replace = Type.Missing; object matchKashida = Type.Missing; object matchDiacritics = Type.Missing; object matchAlefHamza = Type.Missing; object matchControl = Type.Missing;

            forward = true;
            rng.Find.ClearFormatting();
            rng.Find.Font.Underline = WdUnderline.wdUnderlineWavy;
            
            //execute find and replace
            bool found = rng.Find.Execute(ref findText, ref matchCase, ref matchWholeWord, ref matchWildCards, 
                ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, 
                ref replace, ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
            int rangeEnd = rng.End;

            forward = false;
            rng.Find.Execute(ref findText, ref matchCase, ref matchWholeWord, ref matchWildCards,
                ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);

            int rangeStart = rng.Start;

            rng.End = rangeEnd;
            rng.Start = rangeStart;
            rng.Font.Underline = WdUnderline.wdUnderlineNone;
            rng.Text = ctrl.Parameter.ToString();
        }

        public void CheckActiveDocument()
        {
            //Checks the whole document
            //TODO: checking only parts of the document from the cursor
            Microsoft.Office.Interop.Word.Document Doc = Globals.ThisAddIn.Application.ActiveDocument;
            if (Doc == null || Doc.ReadOnly)
            {
                return;
            }

            RemoveAllErrorMarks();
            try
            {
                Word.Paragraph firstPara = Doc.Paragraphs.First;
                int numParagraphs = Doc.Paragraphs.Count;

                for (int i = 1; i <= numParagraphs; i++)
                {
                    Word.Paragraph para = firstPara.Next(i - 1);
                    Word.Range myrange = para.Range;
                    String paraStr = para.Range.Text.ToString();
                    String lang = GetLanguageISO(para.Range.LanguageID.ToString());
                    String uriString = LTServer + "?language=" + lang + "&text=" + WebUtility.UrlEncode(paraStr);
                    uriString = uriString.Replace("%C2%A0", "+"); // ????
                    Uri uri = new Uri(uriString);
                    String results = GetResultsFrom(uri);

                    //int myParaOffset = 0; // Not necessary if results are processed in reverse order
                    //int myTopOffset = 0;
                    int prevErrorStart = -1;
                    int prevErrorEnd = -1;
                    foreach (Dictionary<string, string> myerror in ParseXMLResults(results).Reverse<Dictionary<string, string>>())
                    {
                        //Select error start and end
                        int errorStart = para.Range.Start + int.Parse(myerror["offset"]);// + myParaOffset;
                        int errorEnd = errorStart + int.Parse(myerror["errorlength"]);
                        if (errorEnd == prevErrorEnd)  // Mark just one error at the same place
                        {
                            continue;
                        }
                        Word.Range rng = Doc.Range(errorStart, errorEnd);
                        // choose color for underline
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
                        // do not track changes
                        bool isTrackingRevisions = Doc.TrackRevisions;
                        Doc.TrackRevisions = false;
                        // unerline errors
                        rng.Font.Underline = WdUnderline.wdUnderlineWavy;
                        rng.Font.UnderlineColor = mycolor;
                        // add hidden data after error
                        string errorData = "[" + myerror["msg"] + "|" + myerror["replacements"] + "]";
                        //myParaOffset += errorData.Length;
                        Word.Range newRng = Doc.Range(errorEnd, errorEnd);
                        newRng.Text = errorData;
                        newRng.Font.Hidden = 1;
                        // Store previous start and end values
                        prevErrorEnd = errorEnd;
                        prevErrorStart = errorStart;
                        // Track revisions again
                        Doc.TrackRevisions = isTrackingRevisions;

                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception if for some reason the document is not available.
            }

        }

        private void mySuggestion_click(object sender, EventArgs e)
        {
            MessageBox.Show(((Button)sender).Name);
            //throw new NotImplementedException();
        }


        private String findHiddenData(Word.Selection selection)
        {
            //Retrieve hidden data after underlined words.
            Microsoft.Office.Interop.Word.Document Doc = Globals.ThisAddIn.Application.ActiveDocument;
            if (Doc == null || Doc.ReadOnly)
            {
                return "";
            }

            object findText = "(\\[*\\])";
            object matchCase = false;
            object matchWholeWord = false;
            object matchWildCards = true;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object wrap = WdFindWrap.wdFindStop;
            object format = true;
            object replaceWithText = "\\1";
            object replace = WdReplace.wdReplaceNone;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
                        
            Word.Range rng = selection.Range;                   
            rng.Find.ClearFormatting();
            rng.Find.Font.Hidden = 1;
            rng.Find.Replacement.ClearFormatting();
            rng.Find.Replacement.Font.Hidden = 1;

            Globals.ThisAddIn.Application.ScreenUpdating = false;
            bool isShowingHiddenText = Doc.ActiveWindow.View.ShowHiddenText; //Find & replace work better this way!
            Doc.ActiveWindow.View.ShowHiddenText = true;

            //execute find and replace
            bool found = rng.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);

            String msg = "";
            if (found && rng.Text!= null)
            {
                msg = rng.Text;
            }
            Doc.ActiveWindow.View.ShowHiddenText = isShowingHiddenText;
            Globals.ThisAddIn.Application.ScreenUpdating = true;
            return msg;
        }

        public void RemoveAllErrorMarks()
        {
            Microsoft.Office.Interop.Word.Document Doc = Globals.ThisAddIn.Application.ActiveDocument;
            if (Doc == null || Doc.ReadOnly)
            {
                return;
            }
            bool isTrackingRevisions = Doc.TrackRevisions;
            Doc.TrackRevisions = false;
            Globals.ThisAddIn.Application.ScreenUpdating = false; //Find & replace work better this way!
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
            Doc.ActiveWindow.View.ShowHiddenText = true;
            rng.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
            Doc.ActiveWindow.View.ShowHiddenText = false;

            Globals.ThisAddIn.Application.ScreenUpdating = true;
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

        //TODO: Find a better way
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

        sealed public class ConvertImage : System.Windows.Forms.AxHost
        {
            private ConvertImage()
                : base(null)
            {
            }

            public static stdole.IPictureDisp Convert
                (System.Drawing.Image image)
            {
                return (stdole.IPictureDisp)System.
                    Windows.Forms.AxHost
                    .GetIPictureDispFromPicture(image);
            }
        }
        private stdole.IPictureDisp getImage()
        {
            stdole.IPictureDisp tempImage = null;
            try
            {
                System.Drawing.Icon newIcon =
                    Properties.Resources.LanguageTool_Logo;

                System.Windows.Forms.ImageList newImageList =
                    new System.Windows.Forms.ImageList();
                newImageList.Images.Add(newIcon);
                tempImage = ConvertImage.Convert(newImageList.Images[0]);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return tempImage;
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
