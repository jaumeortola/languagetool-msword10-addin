using System;
using System.Drawing;
using System.Windows.Forms;

namespace languagetool_msword10_addin
{
    public partial class CheckingForm : Form
    {
        public CheckingForm()
        {
            InitializeComponent();
            this.changeSuggestion.Text = Resources.WinFormStrings.change;
            this.ignoreSuggestion.Text = Resources.WinFormStrings.ignore_once;
            this.suggestionsLabel.Text = Resources.WinFormStrings.suggestions + ":";
            this.cancelButton.Text = Resources.WinFormStrings.cancel;
            this.ignoreAllButton.Text = Resources.WinFormStrings.ignore_all;
            this.moreinfoLinkLabel.Text = Resources.WinFormStrings.more_information;
            this.Text = Resources.WinFormStrings.proofreading_with_LanguageTool;

            this.languageBox.Text = "";
        }

        private void changeSuggestion_Click(object sender, EventArgs e)
        {
            if (this.suggestionsBox.SelectedItem != null)
            {
                ThisAddIn.checkOnDialogChange(this.suggestionsBox.SelectedItem.ToString());
            }
            else
            {
                ThisAddIn.checkOnDialogChange("");
            }
            
        }

        private void ignoreSuggestion_Click(object sender, EventArgs e)
        {
            ThisAddIn.checkOnDialogIgnore();
        }
        private void ignoreAlwaysSuggestion_Click(object sender, EventArgs e)
        {
            ThisAddIn.checkOnDialogIgnoreAlways();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.finalize();
        }

        private void textUpdated(object sender, EventArgs e)
        {
            if (! ThisAddIn.preparingDialog)
            {
                this.suggestionsBox.Enabled = false;
                ThisAddIn.updatedContext = true;
                this.contextTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
                this.changeSuggestion.Enabled = true;
                this.suggestionsBox.SelectedItems.Clear();
            }
        }

        private void linklabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel.Link)e.Link.LinkData).LinkData.ToString());
        }

        public void finalize()
        {
            this.Hide();
            Globals.ThisAddIn.Application.Selection.Move();
            Globals.ThisAddIn.Application.ActiveWindow.SetFocus();
        }

        private void servernameBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText + "Languages"); //show list of available languages
        }
    }
}
