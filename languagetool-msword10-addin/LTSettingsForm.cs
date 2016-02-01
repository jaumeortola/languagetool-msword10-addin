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
    public partial class LTSettingsForm : Form
    {
        public LTSettingsForm()
        {
            InitializeComponent();


            this.LT_server_label.Text = Resources.WinFormStrings.LT_server;
            this.checking_options_label.Text = Resources.WinFormStrings.checking_options;
            this.save_button.Text = Resources.WinFormStrings.ok;
            this.cancel_button.Text = Resources.WinFormStrings.cancel;
            this.typography_checkbox.Text = Resources.WinFormStrings.typography;
            this.default_language_label.Text = Resources.WinFormStrings.default_language;
            this.Text = Resources.WinFormStrings.Languagetool_settings;

            foreach (string languageISO in ThisAddIn.getLanguagesList())
            {
                this.comboBoxLanguages.Items.Add(new ComboItem(languageISO, ThisAddIn.getLanguageName(languageISO))); 
            }
            this.comboBoxLanguages.Text = ThisAddIn.getLanguageName(Properties.Settings.Default.DefaultLanguage);
            this.comboBoxPreferences.Items.AddRange(
                Properties.Settings.Default.CatalanPreferencesOptions.Split(';'));
            this.comboBoxPreferences.Text = Properties.Settings.Default.CatalanUserPreferences;
            this.comboBoxLTServer.Items.AddRange(
                Properties.Settings.Default.LTServerOptions.Split(';'));
            this.comboBoxLTServer.Text = Properties.Settings.Default.LTServer;
            this.typography_checkbox.Checked = Properties.Settings.Default.TypographyRulesEnabled;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Refresh();
        }

        class ComboItem
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public ComboItem(string key, string value)
            {
                Key = key; Value = value;
            }
            public override string ToString()
            {
                return Value;
            }
        }


        private void saveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LTServer = this.comboBoxLTServer.Text;
            Properties.Settings.Default.CatalanUserPreferences = this.comboBoxPreferences.Text;
            Properties.Settings.Default.TypographyRulesEnabled = this.typography_checkbox.Checked;
            Properties.Settings.Default.DefaultLanguage = ((ComboItem)this.comboBoxLanguages.SelectedItem).Key;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelSettings_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
