using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string docPath = System.Configuration.ConfigurationManager.AppSettings["docxPath"];
            string pdfPath = System.Configuration.ConfigurationManager.AppSettings["pdfPath"];
            string excelPath = System.Configuration.ConfigurationManager.AppSettings["excelPath"];
            string tempPath = System.Configuration.ConfigurationManager.AppSettings["tempPath"];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2(docPath, pdfPath, excelPath, tempPath));
        }
    }
}
