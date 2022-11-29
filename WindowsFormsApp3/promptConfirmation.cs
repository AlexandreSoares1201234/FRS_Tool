using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class promptConfirmation : Form
    {
        public bool confirmation;
        private Form1 form;
        public promptConfirmation(Form1 form)
        {
            this.form = form;
            confirmation= false;
            InitializeComponent();
        }

        public void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            form.clearAll();
            this.Close();
        }

        public void bunifuLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
