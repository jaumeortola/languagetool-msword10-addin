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
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Refresh();
        }

        private void click_OK(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
