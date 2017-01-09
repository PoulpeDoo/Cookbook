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
using System.Text.RegularExpressions;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private string GetText(int num)
        {
            string names = "";
            try
            {
                using (var Request = new HttpRequest())
                {
                    string sourcePage;

                    string[] title;
                    

                    sourcePage = Request.Get("http://cooking.wild-mistress.ru/main_dishes/second_courses/meat_offal/" + num + "/").ToString();
                    title = sourcePage.Substrings("<div>", "</div>", 0);
                    
                    for (int i = 0; i <= title.Length; i++)
                    {
                        names += title[i] + "\r\n";
                    }
                    
                }

            
            }
            catch
            {

            }
            return names;
        }

        private int GetCountPages()
        {
            int countPage = 0;
            try
            {
                using(var Request = new HttpRequest())
                {
                    string sourcePage;
                    sourcePage = Request.Get("http://cooking.wild-mistress.ru/main_dishes/second_courses/meat_offal/").ToString();
                    countPage = Convert.ToInt32(sourcePage.Substrings("/main_dishes/second_courses/meat_offal/", "/\">")[7]);
                }
            }
            catch { }
            return countPage;
        }

        private void Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int countPages = GetCountPages();
                for (int i = 1; i <= countPages; i++)
                {
                    Thread.ReportProgress(0, GetText(i));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.Text += e.UserState;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.RunWorkerAsync();
        }
    }
}
