using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace WindowsFormsApplication1
{
    public partial class Addresepy : Form
    {
        public Addresepy()
        {
            InitializeComponent();
        }

        private void Addresepy_Load(object sender, EventArgs e)
        {
            MessageBox.Show(GetTitleResepy(1));
        }
        
        private string GetTitleResepy(int num)
        {
            string resepyTitle = "";
            
            try
            {
                using (var Request = new HttpRequest())
                {
                    string sourcePage;
                    string[] Title;

                    sourcePage = Request.Get("http://www.edimdoma.ru/retsepty?page=" + num).ToString();
                    Title = sourcePage.Substrings("<a href=\"", "\">", 0);

                    for (int i = 0; i <= Title.Length; i++)
                    {
                        resepyTitle += Title[i] + "\r\n";

                    }
                }
            }
            catch
            {

            }

            return resepyTitle;
        }
        private int GetCountPages()
        {
            int countPage = 0;

            try
            {

                using (var Request = new HttpRequest())
                {
                    string sourcePage;

                    sourcePage = Request.Get("http://www.edimdoma.ru/retsepty").ToString();
                    countPage = Convert.ToInt32(sourcePage.Substrings("/retsepty?page=", "\" class=\" paginator__item\">")[3]);
                }

            }
            catch { }
            return countPage;
        }
    }
}
