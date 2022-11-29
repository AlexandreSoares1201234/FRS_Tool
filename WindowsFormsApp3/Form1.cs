using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Office.Interop.Word;



namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        String doc;
        String excelFile;
        String pdf;
        String tempPath;
        String uploadImage;
        String clientFirstName;
        String clientLastName;
        String clientAddress;
        String clientPhone;
        String clientEmail;
        String clientDateOfInspection;
        String customerNumber;
        System.Data.DataTableCollection tableCollection;
        System.Data.DataTable excelData;

        public Func<object, ExcelDataTableConfiguration> ConfigureDataTable { get; }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern bool ReleaseCapture();

        public Form1(String firstName, String lastName, String address, String phone, String email, String dateOfInspection, String customerNmb, Form2 close, String doc, String pdf, String excel, String temp)
        {
            
            using(var stream = File.Open(excel,FileMode.Open, FileAccess.Read))
            {
                using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream)) {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    }) ;
                    tableCollection = result.Tables;
                    excelData = tableCollection[0];


                }
            }
            clientFirstName = firstName;
            clientLastName = lastName;
            clientAddress = address;
            clientPhone = phone;
            clientEmail = email;
            customerNumber = customerNmb;
            clientDateOfInspection = dateOfInspection;
            InitializeComponent();
            this.doc= doc;
            this.excelFile= excel;
            this.pdf= pdf;
            this.tempPath = temp;
            foreach (DataRow var in excelData.Rows)
            {
                comboBox1.Items.Add(var[1]);
                comboBox2.Items.Add(var[1]);
                comboBox3.Items.Add(var[1]);
            }
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0X2, 0);
            }
        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuDataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int x = 0; x < bunifuDataGridView1.Rows.Count - 1; x++)
            {

                if (float.Parse((string)bunifuDataGridView1.Rows[x].Cells[1].Value) == 0)
                {
                    bunifuDataGridView1.Rows.Remove(bunifuDataGridView1.Rows[x]);
                }


            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView1.Rows.Count - 1; x++)
            {
                if (bunifuDataGridView1.Rows[x].Cells[1].Value != null && bunifuDataGridView1.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView1.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView1.Rows[x].Cells[2].Value);

                }
            }
            bunifuLabel3.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuDataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int x = 0; x < bunifuDataGridView2.Rows.Count - 1; x++)
            {

                if (float.Parse((string)bunifuDataGridView2.Rows[x].Cells[1].Value) == 0)
                {
                    bunifuDataGridView2.Rows.Remove(bunifuDataGridView2.Rows[x]);
                }


            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView2.Rows.Count - 1; x++)
            {
                if (bunifuDataGridView2.Rows[x].Cells[1].Value != null && bunifuDataGridView2.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView2.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView2.Rows[x].Cells[2].Value);

                }
            }
            bunifuLabel4.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuDataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int x = 0; x < bunifuDataGridView3.Rows.Count - 1; x++)
            {

                if (float.Parse((string)bunifuDataGridView3.Rows[x].Cells[1].Value) == 0)
                {
                    bunifuDataGridView3.Rows.Remove(bunifuDataGridView3.Rows[x]);
                }


            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView3.Rows.Count - 1; x++)
            {
                if (bunifuDataGridView3.Rows[x].Cells[1].Value != null && bunifuDataGridView3.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView3.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView3.Rows[x].Cells[2].Value);

                }
            }
            bunifuLabel2.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",",".") ;
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            promptConfirmation form2 = new promptConfirmation(this);
            form2.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
        public void clearAll()
        {
            bunifuDataGridView1.Rows.Clear();
            bunifuLabel2.Text = "$99";
            bunifuDataGridView2.Rows.Clear();
            bunifuLabel3.Text = "$99";
            bunifuDataGridView3.Rows.Clear();
            bunifuLabel4.Text = "$99";
        }

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, String[] toFindText, String[] replaceWithText)
        {
            object matchCase = true;

            object matchwholeWord = true;

            object matchwildCards = false;

            object matchSoundLike = false;

            object nmatchAllforms = false;

            object forward = true;

            object format = false;

            object matchKashida = false;

            object matchDiactitics = false;

            object matchAlefHamza = false;

            object matchControl = false;

            object read_only = false;

            object visible = true;

            object replace = -2;

            object wrap = 1;
            int x = 0;
            foreach(String str in toFindText)
            {
                
                object stringFind = str;
                object replaceText = replaceWithText[x];
                if (str == toFindText[6] || str == toFindText[7])
                {
                    replaceText = replaceWithText[x].Replace(",", ".");
                } 
                
                wordApp.Selection.Find.Execute(ref stringFind, ref matchCase,
                                                           ref matchwholeWord, ref matchwildCards, ref matchSoundLike,

                                                           ref nmatchAllforms, ref forward,

                                                           ref wrap, ref format, ref replaceText,

                                                               ref replace, ref matchKashida,

                                                           ref matchDiactitics, ref matchAlefHamza,

                                                            ref matchControl);
                x = x + 1;
            }
   
           
        }


        private void CreateWordDocument(String filename, String SaveAs, String[] toFind, String[] toReplace, DataGridViewRowCollection dataSet, String image, String temp)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            object missing = Missing.Value;

            Microsoft.Office.Interop.Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                

                object isvisible = false;
                
                System.IO.File.Copy(filename,temp , true);
                object file = temp;
                string shadowFile = temp;
                wordApp.Visible = false;
                myWordDoc = wordApp.Documents.Open(ref file, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                     ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();

                Microsoft.Office.Interop.Word.Table table = myWordDoc.Tables[1];
                
                int y = 2;
                int x = 0;
                foreach(DataGridViewRow a in dataSet)
                {
                    if(a.Cells[0].Value != null) {
                        table.Cell(y, 1).Range.Text = a.Cells[0].Value.ToString();
                        table.Cell(y, 2).Range.Text = a.Cells[1].Value.ToString();
                        foreach (DataRow var in excelData.Rows)
                        {
                            if (var[1].ToString() == a.Cells[0].Value.ToString())
                            {
                                table.Cell(y, 3).Range.Text =var[2].ToString();
                                table.Cell(y, 4).Range.Text = (float.Parse(a.Cells[1].Value.ToString()) * float.Parse(var[2].ToString())).ToString();
                            }
                        }
                        x++;
                        y++;
                    }
                    
                   
                }
                int z = 0;
                foreach (Row b in table.Rows)
                {


                    if (z > x)
                    {
                        b.Delete();
                    }
                    z++;
                }
                if (image != null)
                {   
                        var shape = myWordDoc.Bookmarks["Imagem"].Range.InlineShapes.AddPicture(image);
                        shape.Width = 125;
                        shape.Height = 125;
                    
                   
                }
                
                this.FindAndReplace(wordApp, toFind, toReplace);
                String output = SaveAs.Remove(SaveAs.Length - 5, 5);
                output = output + DateTime.Now.ToShortDateString().Replace("/", "_") + toReplace[1] +"_" + toReplace[2];
                output = output + "_pdf";
                
                myWordDoc.ExportAsFixedFormat(output, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF
                    );
                

                myWordDoc.Close();
                wordApp.Quit();
                System.IO.File.Delete( shadowFile);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            String[] toFind = { "DATE OF INSPECTION", "CUSTOMER #", "<Name>", "<Address>", "<Phone>", "<Email>", "Subtotal!", "Total!" };
            String[] toReplace = { clientDateOfInspection, customerNumber, clientFirstName +clientLastName, clientAddress, clientPhone, clientEmail, "$" + (calculateTotal(bunifuDataGridView1)).ToString("0.00")
                    , "$" + (calculateTotal(bunifuDataGridView1)+99).ToString("0.00") };
            CreateWordDocument(doc, pdf, toFind, toReplace, bunifuDataGridView1.Rows, uploadImage, this.tempPath);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            String[] toFind = { "DATE OF INSPECTION", "CUSTOMER #", "<Name>", "<Address>", "<Phone>", "<Email>", "Subtotal!", "Total!" };
            String[] toReplace = { clientDateOfInspection, customerNumber, clientFirstName + clientLastName, clientAddress, clientPhone, clientEmail,"$" + (calculateTotal(bunifuDataGridView2)).ToString("0.00")
                    , "$" + (calculateTotal(bunifuDataGridView2)+99).ToString("0.00")};
            CreateWordDocument(doc, pdf, toFind, toReplace, bunifuDataGridView2.Rows, uploadImage, this.tempPath);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            String[] toFind = { "DATE OF INSPECTION", "CUSTOMER #", "<Name>", "<Address>", "<Phone>", "<Email>", "Subtotal!", "Total!" };
            String[] toReplace = { clientDateOfInspection,customerNumber, clientFirstName + clientLastName, clientAddress, clientPhone, clientEmail, "$" + (calculateTotal(bunifuDataGridView3)).ToString("0.00")
                    , "$" + (calculateTotal(bunifuDataGridView3) + 99).ToString("0.00")};
            CreateWordDocument(doc, pdf, toFind, toReplace, bunifuDataGridView3.Rows, uploadImage, this.tempPath);
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog opem= new OpenFileDialog();
            if(opem.ShowDialog() == DialogResult.OK) {
                this.uploadImage = opem.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            String price = "0";
            if (bunifuDataGridView1.Rows.Count == 1 && comboBox1.Text != null)
            {

                foreach (DataRow var in excelData.Rows)
                {
                    if (var[1].ToString() == comboBox1.Text)
                    {
                        price = var[2].ToString();
                    }
                }
                bunifuDataGridView1.Rows.Add(comboBox1.Text, "1", price);
            }
            else
            {
                if (comboBox1.Text != null)
                {
                    foreach (DataRow var in excelData.Rows)
                    {
                        if (var[1].ToString() == comboBox1.Text)
                        {
                            price = var[2].ToString();
                        }
                    }
                    bool present = false;
                    for (int x = 0; x < bunifuDataGridView1.Rows.Count - 1; x++)
                    {

                        if (bunifuDataGridView1.Rows[x].Cells[0].Value.ToString() == comboBox1.Text) { present = true; }

                    }

                    if (present == false)
                    {
                        bunifuDataGridView1.Rows.Add(comboBox1.Text, "1", price);
                    }
                }
            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView1.Rows.Count; x++)
            {
                if (bunifuDataGridView1.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView1.Rows[x].Cells[2].Value) * float.Parse((string)bunifuDataGridView1.Rows[x].Cells[1].Value);
                }
            }
            bunifuLabel3.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            String price = "0";
            if (bunifuDataGridView2.Rows.Count == 1 && comboBox2.Text != null)
            {

                foreach (DataRow var in excelData.Rows)
                {
                    if (var[1].ToString() == comboBox2.Text)
                    {
                        price = var[2].ToString();
                    }
                }
                bunifuDataGridView2.Rows.Add(comboBox2.Text, "1", price);
            }
            else
            {
                if (comboBox2.Text != null)
                {
                    foreach (DataRow var in excelData.Rows)
                    {
                        if (var[1].ToString() == comboBox2.Text)
                        {
                            price = var[2].ToString();
                        }
                    }
                    bool present = false;
                    for (int x = 0; x < bunifuDataGridView2.Rows.Count - 1; x++)
                    {

                        if (bunifuDataGridView2.Rows[x].Cells[0].Value.ToString() == comboBox2.Text) { present = true; }

                    }

                    if (present == false)
                    {
                        bunifuDataGridView2.Rows.Add(comboBox2.Text, "1", price);
                    }
                }
            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView2.Rows.Count; x++)
            {
                if (bunifuDataGridView2.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView2.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView2.Rows[x].Cells[2].Value);
                }
            }
            bunifuLabel4.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            String price = "0";
            if (bunifuDataGridView3.Rows.Count == 1 && comboBox3.Text != null)
            {
                foreach (DataRow var in excelData.Rows)
                {
                    if (var[1].ToString() == comboBox3.Text)
                    {
                        price = var[2].ToString();
                    }
                }
                bunifuDataGridView3.Rows.Add(comboBox3.Text, "1", price);
            }
            else
            {
                if (comboBox3.Text != null)
                {
                    foreach (DataRow var in excelData.Rows)
                    {
                        if (var[1].ToString() == comboBox3.Text)
                        {
                            price = var[2].ToString();
                        }
                    }
                    bool present = false;
                    for (int x = 0; x < bunifuDataGridView3.Rows.Count - 1; x++)
                    {

                        if (bunifuDataGridView3.Rows[x].Cells[0].Value.ToString() == comboBox3.Text) { present = true; }

                    }

                    if (present == false)
                    {
                        bunifuDataGridView3.Rows.Add(comboBox3.Text, "1", price);
                    }
                }
            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView3.Rows.Count; x++)
            {
                if (bunifuDataGridView3.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView3.Rows[x].Cells[2].Value) * float.Parse((string)bunifuDataGridView3.Rows[x].Cells[1].Value);
                }
            }
            bunifuLabel2.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.CurrentRow.Cells[0].Value != null)
            {
                bunifuDataGridView1.Rows.Remove(bunifuDataGridView1.CurrentRow);

            }
            float newPrice=0;
            for (int x = 0; x < bunifuDataGridView1.Rows.Count - 1; x++)
            {
                if (bunifuDataGridView1.Rows[x].Cells[1].Value != null && bunifuDataGridView1.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView1.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView1.Rows[x].Cells[2].Value);
                }
            }
            bunifuLabel3.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView2.CurrentRow.Cells[0].Value != null)
            {
                bunifuDataGridView2.Rows.Remove(bunifuDataGridView2.CurrentRow);

            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView2.Rows.Count - 1; x++)
            {
                if(bunifuDataGridView2.Rows[x].Cells[1].Value != null && bunifuDataGridView2.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView2.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView2.Rows[x].Cells[2].Value);
                }
            }
            bunifuLabel4.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView3.CurrentRow.Cells[0].Value != null)
            {
                bunifuDataGridView3.Rows.Remove(bunifuDataGridView3.CurrentRow);

            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView3.Rows.Count - 1; x++)
            {
                if (bunifuDataGridView3.Rows[x].Cells[1].Value != null && bunifuDataGridView3.Rows[x].Cells[2].Value != null)
                {
                    newPrice = newPrice + float.Parse((string)bunifuDataGridView3.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView3.Rows[x].Cells[2].Value);
                }
            }
            bunifuLabel2.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            bunifuDataGridView2.Rows.Clear();
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    object[] values = { row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value };
                    bunifuDataGridView2.Rows.Add(values);
                }
                
            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView2.Rows.Count - 1; x++)
            {

                newPrice = newPrice + float.Parse((string)bunifuDataGridView2.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView2.Rows[x].Cells[2].Value);
            }
            bunifuLabel4.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            bunifuDataGridView3.Rows.Clear();
            foreach (DataGridViewRow row in bunifuDataGridView2.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    object[] values = { row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value };
                    bunifuDataGridView3.Rows.Add(values);
                }
           
            }
            float newPrice = 0;
            for (int x = 0; x < bunifuDataGridView3.Rows.Count - 1; x++)
            {

                newPrice = newPrice + float.Parse((string)bunifuDataGridView3.Rows[x].Cells[1].Value) * float.Parse((string)bunifuDataGridView3.Rows[x].Cells[2].Value);
            }
            bunifuLabel2.Text = "$" + (newPrice + 99).ToString("0.00").Replace(",", ".");
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private float calculateTotal(BunifuDataGridView grid)
        {
            float total = 0;
            for (int x = 0; x < grid.Rows.Count - 1; x++)
            {
                if (grid.Rows[x].Cells[1].Value != null && grid.Rows[x].Cells[2].Value != null)
                {
                    total = total + float.Parse((string)grid.Rows[x].Cells[1].Value) * float.Parse((string)grid.Rows[x].Cells[2].Value);
                }
            }
            return total;
        }
    }
}
