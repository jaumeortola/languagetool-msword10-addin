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
            
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            ThisAddIn.checkActiveDocument();
        }

        private void checkBox1_Click(object sender, RibbonControlEventArgs e)
        {
            Properties.Settings.Default.CheckWhileWriting = this.checkBox1.Checked;
            Properties.Settings.Default.Save();
            if (this.checkBox1.Checked)
            {
                ThisAddIn.checkActiveDocument();
            }
            else
            {
                ThisAddIn.removeAllErrorMarks();
            }
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            ThisAddIn.checkParagraphsInSelection();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            ThisAddIn.removeAllErrorMarks();
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

