using System;
using System.Windows.Forms;

namespace languagetool_msword10_addin
{
    public partial class LTSettingsForm : Form
    {
        public LTSettingsForm()
        {
            InitializeComponent();
            this.LT_server_label.Text = Resources.WinFormStrings.LT_server;
            this.save_button.Text = Resources.WinFormStrings.ok;
            this.cancel_button.Text = Resources.WinFormStrings.cancel;
            this.default_language_label.Text = Resources.WinFormStrings.default_language;
            this.Text = Resources.WinFormStrings.LT_settings;
            foreach (string languageISO in ThisAddIn.getLanguagesList())
            {
                ComboItem myComboItem = new ComboItem(languageISO, ThisAddIn.getLanguageName(languageISO));
                this.comboBoxLanguages.Items.Add(myComboItem); 
                if (Properties.Settings.Default.DefaultLanguage == languageISO)
                    this.comboBoxLanguages.SelectedItem = myComboItem;
            }
            this.comboBoxLTServer.Items.AddRange(
                Properties.Settings.Default.LTServerOptions.Split(';'));
            this.comboBoxLTServer.Text = Properties.Settings.Default.LTServer;
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
            Properties.Settings.Default.DefaultLanguage = ((ComboItem)this.comboBoxLanguages.SelectedItem).Key;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelSettings_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void languageSpecificSettings_Click(object sender, EventArgs e)
        {
            string selectedLanguage = ((ComboItem)this.comboBoxLanguages.SelectedItem).Key;
            if (selectedLanguage.StartsWith("ca")) 
            {
                CatalanSettingsForm myCatalanSettingsForm = new CatalanSettingsForm();
                myCatalanSettingsForm.Show();
            }
        }

        private void comboBoxLanguages_TextChanged(object sender, EventArgs e)
        {
            string selectedLanguage = ((ComboItem)this.comboBoxLanguages.SelectedItem).Key;
            this.languageSpecificSettings.Text = Resources.WinFormStrings.settings + ": " + ThisAddIn.getLanguageName(selectedLanguage);
            if (selectedLanguage.StartsWith("ca"))
            {
                this.languageSpecificSettings.Visible = true;
            }
            else
            {
                this.languageSpecificSettings.Visible = false;
            }
        }
    }
}
