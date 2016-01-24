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

            foreach (KeyValuePair<string, string> entry in ThisAddIn.getLanguagesFromServer())   //TODO make secure
            {
                this.comboBoxLanguages.Items.Add(entry.Value); //+ " "+entry.Key+""
            }
            this.comboBoxLanguages.Text = Properties.Settings.Default.DefaultLanguage;
            this.comboBoxPreferences.Items.AddRange(
                Properties.Settings.Default.CatalanPreferencesOptions.Split(';'));
            this.comboBoxPreferences.Text = Properties.Settings.Default.CatalanUserPreferences;
            this.comboBoxLTServer.Items.AddRange(
                Properties.Settings.Default.LTServerOptions.Split(';'));
            this.comboBoxLTServer.Text = Properties.Settings.Default.LTServer;
            this.TypographyRulesEnabled.Checked = Properties.Settings.Default.TypographyRulesEnabled;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Refresh();
        }

        private void LTSettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void saveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LTServer = this.comboBoxLTServer.Text;
            Properties.Settings.Default.CatalanUserPreferences = this.comboBoxPreferences.Text;
            Properties.Settings.Default.TypographyRulesEnabled = this.TypographyRulesEnabled.Checked;
            Properties.Settings.Default.DefaultLanguage = this.comboBoxLanguages.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelSettings_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
