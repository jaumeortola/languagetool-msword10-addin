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
            //System.Windows.Forms.MessageBox.Show("Has fet clic en el botó de revisió. Revisant...");
            languagetool_msword10_addin.ThisAddIn.CheckActiveDocument();

        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            languagetool_msword10_addin.ThisAddIn.RemoveAllErrorMarks();

        }
    }
}

