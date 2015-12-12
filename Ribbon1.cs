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
            Globals.ThisAddIn.checkActiveDocument();
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.checkCurrentParagraph();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.removeAllErrorMarks(Globals.ThisAddIn.Application.ActiveDocument.Content);
        }
        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.TaskPane.Visible = ((RibbonToggleButton)sender).Checked;
        }

    }
}

