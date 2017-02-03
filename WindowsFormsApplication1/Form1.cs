﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;
using System.IO;


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
      
            int countPage = GetCountPages();
            
            int top   = 50;
            int left  = 100;
            int top2  = 50;
            int left2 = 225;

            for (int i = 1; i < countPage; i++)
            {
                string[] str = GetText(i).Split('\n');
                string[] img = GetImg(i).Split('\n');

                for (int j = 0; j < str.Length - 2; j++)
                {

                    Button btn = new Button();
                    btn.Left   = left;
                    btn.Top    = top;
                    btn.Height = 60;
                    btn.Width  = 200;
                    btn.Text   = str[j];
                    btn.Tag    = "resepty";
                    this.Controls.Add(btn);
                    top        += btn.Height + 2;
                    btn.Click  += new System.EventHandler(resepy);

                    PictureBox pic    = new PictureBox();
                    pic.Left          = left2;
                    pic.Top           = top2;
                    pic.Height        = 60;
                    pic.Width         = 200;                    
                    pic.ImageLocation = @"C:\Users\polina\Documents\GitHub\Cookbook\imgForPars\" + i + j + "рец.jpg";                    
                    pic.SizeMode      = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(pic);
                    top2 += pic.Height + 2;
                    
                }

            }

        }
        
        private string GetImg(int num)
        {
            string file = "";
            string url  = "";

            try
            {
                using (var Request = new HttpRequest())
                {
                    string sourcePage;
                    string[] urlImg;

                    sourcePage = Request.Get("http://www.edimdoma.ru/retsepty?page=" + num).ToString();
                    urlImg     = sourcePage.Substrings("<picture class=\"card__picture\"><img src=\"//", "\" alt=\"", 0);
                    

                    for (int i = 0; i <= urlImg.Length; i++)
                    {                                                                    
                        url  = "http://" + urlImg[i];
                        string s = urlImg[i].Substring(urlImg[i].IndexOf('?'));
                        file = @"C:\Users\polina\Documents\GitHub\Cookbook\imgForPars\" + num + i + "рец.jpg";
                        Request.Get(url).ToFile(file);                        
                    }
                }
            }
            catch
            {

            }
            
            return file;
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

                    sourcePage = Request.Get("http://www.edimdoma.ru/retsepty?page=" + num).ToString();
                    title      = sourcePage.Substrings("<div class=\"card__title title\">", "</div>", 0);

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

                using (var Request = new HttpRequest())
                {
                    string sourcePage;

                    sourcePage = Request.Get("http://www.edimdoma.ru/retsepty").ToString();
                    countPage  = Convert.ToInt32(sourcePage.Substrings("/retsepty?page=", "\" class=\" paginator__item\">")[3]);
                }

            }
            catch { }
            return countPage;
        }

        private void resepy(object sender, EventArgs e)
        {
            MessageBox.Show("Тест");
        }
    }
}
