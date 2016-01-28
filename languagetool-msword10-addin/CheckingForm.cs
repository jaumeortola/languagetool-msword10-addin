using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.label1.Text = Resources.WinFormStrings.suggestions + ":";
            this.button1.Text = Resources.WinFormStrings.cancel;
            this.button2.Text = Resources.WinFormStrings.ignore_all;
            this.linkLabel1.Text = Resources.WinFormStrings.more_information;
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
            this.Close();
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

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel.Link)e.Link.LinkData).LinkData.ToString());
        }

    }
}
