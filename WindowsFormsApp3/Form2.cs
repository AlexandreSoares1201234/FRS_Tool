using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        String doc;
        String pdf;
        String excel;
        String tempPath;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern bool ReleaseCapture();
        public Form2(String docPath, String pdfPath, String excelPath, String tempPath)
        {
            InitializeComponent();
            doc = docPath;
            pdf = pdfPath;
            excel = excelPath;
            this.tempPath = tempPath;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0X2, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(bunifuTextBox1.Text, bunifuTextBox4.Text, bunifuTextBox3.Text,bunifuTextBox2.Text,bunifuTextBox6.Text, bunifuTextBox5.Text,bunifuTextBox7.Text,this, doc, pdf, excel, tempPath);
            form1.ShowDialog();
            this.Hide();
            

        }
    }
}
