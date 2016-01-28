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
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
            this.Text = Resources.WinFormStrings.message;
            this.ok_button.Text = Resources.WinFormStrings.ok;
            this.message_label.Text = Resources.WinFormStrings.no_errors_found;
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
