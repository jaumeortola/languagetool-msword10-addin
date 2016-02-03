using System;
using System.Windows.Forms;

namespace languagetool_msword10_addin
{
    public partial class CatalanSettingsForm : Form
    {
        public CatalanSettingsForm()
        {
            InitializeComponent();

            this.checking_options_label.Text = Resources.WinFormStrings.checking_options;
            this.save_button.Text = Resources.WinFormStrings.ok;
            this.cancel_button.Text = Resources.WinFormStrings.cancel;
            this.typography_checkbox.Text = Resources.WinFormStrings.typography;
            this.Text = Resources.WinFormStrings.settings + ": " + Resources.WinFormStrings.ca_ES;
            this.comboBoxPreferences.Items.AddRange(
                Properties.Settings.Default.CatalanPreferencesOptions.Split(';'));
            this.comboBoxPreferences.Text = Properties.Settings.Default.CatalanUserPreferences;
            this.typography_checkbox.Checked = Properties.Settings.Default.TypographyRulesEnabled;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Refresh();
        }


        private void saveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CatalanUserPreferences = this.comboBoxPreferences.Text;
            Properties.Settings.Default.TypographyRulesEnabled = this.typography_checkbox.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelSettings_click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
