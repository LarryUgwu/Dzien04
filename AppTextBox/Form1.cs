using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTextBox
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //metody muszą mbyć void i muszą mieć dwa parametry:
        // object i eventargs
    
        private void btnShow_Click(object sender, EventArgs e)
        {
            lblResult.Text = tbtekst.Text;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
        }

        private void WhichButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Tag.ToString();
            MessageBox.Show("Wciśnięto przycisk: " + btn.Tag, "Info");
        }

    }
}
