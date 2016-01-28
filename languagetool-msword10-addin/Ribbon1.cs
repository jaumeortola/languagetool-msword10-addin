using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace languagetool_msword10_addin
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            this.check_button.Label = Resources.WinFormStrings.check;
            this.settings_button.Label = Resources.WinFormStrings.settings;
        }

        private void LTSettings_onclick(object sender, RibbonControlEventArgs e)
        {
            LTSettingsForm myLTSettingsForm = new LTSettingsForm();
            myLTSettingsForm.ShowDialog();
        }

        private void button4_onclick(object sender, RibbonControlEventArgs e)
        {
            ThisAddIn.checkOnDialogStart();
        }
    }
}

