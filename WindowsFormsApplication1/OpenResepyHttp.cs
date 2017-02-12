using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using xNet;
using System.IO;
using System.Text.RegularExpressions;


namespace WindowsFormsApplication1
{
    public partial class OpenResepyHttp : Form
    {
        public int k = 0;
        public float kof;
        public float Res;
        public float Ing;
        public int IdResepy;
        public int top;
        public string http;

        public int Id = 1;
        public string Name;
        public string ImgUrl;
        public string Time;
        public string Opicanie;

        public int Person = 0;
        public string[] Step = new string[10];
        public string[] NameIng = new string[15];
        public float[] SumIng = new float[15];
        public float[] SumIngRes = new float[15];
        public string[] MeraIng = new string[15];

        public OpenResepyHttp(Form1 f1)
        {
            InitializeComponent();
            http = f1.http;
            ratio.Text = "";

        }
        public void button1_Click(object sender, EventArgs e)
        {
            Person++;
            ratio.Text = Convert.ToString(Person);

            using (var Request = new HttpRequest())
            {
                string sourcePage;
                string[] title;
                sourcePage = Request.Get(http).ToString();
                
                title = sourcePage.Substrings("<div class=\"entry-stats__value\" itemprop=\"recipeYield\"><span>", "</span>", 0);
                kof = 1 / (float.Parse(title[0]));

                for (int j = 1; j < 16 ; j++)
                {
                    this.Controls.RemoveByKey("lb5" + (j).ToString());
                }

                Label[] lb5 = new Label[15];
                for (int j = 0; j < NameIng.Length && !(NameIng[j] == null); j++)
                {

                    Ing = SumIng[j];
                    Res = Person * kof * Ing;
                    Res = float.Parse(Convert.ToString(Math.Round(Res, 1)));

                    lb5[j] = new System.Windows.Forms.Label();
                    lb5[j].Location = new System.Drawing.Point(460, 610 + j * 40);
                    lb5[j].Height = 40;
                    lb5[j].Name = "lb5" + (j + 1).ToString();
                    lb5[j].Width = 150;
                    lb5[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    if (SumIng[j] <= 0)
                    {
                        lb5[j].Text = MeraIng[j];
                    }
                    else
                    {
                        lb5[j].Text = Res + "    " + MeraIng[j];
                    }
                    Controls.Add(lb5[j]);
                    SumIngRes[j] = Res;
                }

            }
        }

        public void button2_Click(object sender, EventArgs e)
        {

            Person--;
            if (Person <= 0)
            {
                Person = 0;
                ratio.Text = Convert.ToString(Person);
            }
            else
            {
                ratio.Text = Convert.ToString(Person);
            }

            using (var Request = new HttpRequest())
            {
                string sourcePage;
                string[] title;
                sourcePage = Request.Get(http).ToString();

                title = sourcePage.Substrings("<div class=\"entry-stats__value\" itemprop=\"recipeYield\"><span>", "</span>", 0);
                kof = 1 / (float.Parse(title[0]));
                

                for (int j = 1; j < 16; j++)
                {
                    this.Controls.RemoveByKey("lb5" + (j).ToString());
                }

                Label[] lb5 = new Label[15];
                for (int j = 0; j < NameIng.Length && !(NameIng[j] == null); j++)
                {
                                        
                    Ing = SumIng[j];
                    Res = Person * kof * Ing;
                    Res = float.Parse(Convert.ToString(Math.Round(Res, 1)));

                    lb5[j] = new System.Windows.Forms.Label();
                        lb5[j].Location = new System.Drawing.Point(460, 610 + j * 40);
                        lb5[j].Height = 40;
                        lb5[j].Name = "lb5" + (j + 1).ToString();
                        lb5[j].Width = 150;
                        lb5[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    if (SumIng[j] <= 0)
                    {
                        lb5[j].Text = MeraIng[j];
                    }
                    else
                    {
                        lb5[j].Text = Res + "    " + MeraIng[j];
                    }
                                      
                    Controls.Add(lb5[j]);
                    SumIngRes[j] = Res;

                }

                }

        }
               
        private void OpenResepyHttp_Load_1(object sender, EventArgs e)
        {
            using (var Request = new HttpRequest())
            {
                string sourcePage;
                string[] title;
                sourcePage = Request.Get(http).ToString();

                MatchCollection qqq = Regex.Matches(http, @"(?:\d*\.)?\d+");
                StringBuilder www = new StringBuilder();

                foreach (Match matc in qqq)
                    www.Append(matc.Value);

                IdResepy = Convert.ToInt32(Convert.ToString(www));

                title = sourcePage.Substrings("<div class=\"entry-stats__value\" itemprop=\"recipeYield\"><span>", "</span>", 0);
                kof = 1 / (float.Parse(title[0]));
                Person = Convert.ToInt32(title[0]);
                ratio.Text = Convert.ToString(Person);

                title = sourcePage.Substrings("<h1 class=\"recipe-header__name\" itemprop=\"name\">", "</h1>", 0);

                Name = title[0];
                Label lb1 = new Label();
                lb1.Left = 218;
                lb1.Top = 30;
                lb1.Height = 40;
                lb1.Width = 350;
                lb1.Text = Name;
                Controls.Add(lb1);

                title = sourcePage.Substrings("itemprop=\"totalTime\"><span>", "</div>",  0);
                Time = title[0];
                Time = Time.Replace("<span>", "");
                Time = Time.Replace("</span>", "");
                Label lb2 = new Label();
                lb2.Left = 100;
                lb2.Top = 500;
                lb2.Height = 40;
                lb2.Width = 200;
                lb2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lb2.Text = Time;
                Controls.Add(lb2);


                title = sourcePage.Substrings("title=\""+ Name +"\" src=\"//", "\">", 0);
                title[0] = title[0].Replace("\" /></div><div class=\"recipe-author-block\" data-module=\"scroll-to", "");
                ImgUrl = title[0];
                PictureBox pb = new PictureBox();
                pb.Left = 100;
                pb.Top = 85;
                pb.Height = 400;
                pb.Width = 500;
                pb.ImageLocation = "http://"+ImgUrl;
                Controls.Add(pb);

                title = sourcePage.Substrings("<div itemprop=\"description\"><p>", "</p>", 0);
                try
                {
                    Opicanie = title[0];
                }
                catch
                {
                    Opicanie = "";
                }
                TextBox txt = new TextBox();
                txt.Left = 100;
                txt.Top = 550;
                txt.ReadOnly = true;
                txt.Multiline = true;
                txt.Height = 75;
                txt.Width = 500;
                txt.ScrollBars = ScrollBars.Vertical;
                txt.Text = Opicanie;
                this.Controls.Add(txt);
                                
                    title = sourcePage.Substrings("type=\"checkbox\" value=\"1\" /><span>", "<", 0);
                    for (int i = 0; i < title.Length && i <= 14; i++)
                    {
                        NameIng[i] = title[i];
                    }
                                        
                    title = sourcePage.Substrings("<td class=\"definition-list-table__td definition-list-table__td_value\">", "</td>", 0);

                    for (int i = 0; i < title.Length && i <= 14; i++)
                    {
                    try
                    {
                        title[i] = title[i].Replace("&#189", "0.5");
                    
                        MatchCollection mc = Regex.Matches(title[i], @"(?:\d*\.)?\d+");
                        StringBuilder sb = new StringBuilder();

                        foreach (Match matc in mc)
                            sb.Append(matc.Value);
                  
                        if (Convert.ToString(sb) == "0.5")
                        {
                            SumIng[i] = 0.5F;
                        }
                        else if (Convert.ToString(sb) == "")
                        {
                            SumIng[i] = 0;
                        }
                        else
                        {
                            SumIng[i] = float.Parse(Convert.ToString(sb));
                        }
                    }
                    catch
                    {
                        title[i] = title[i].Replace("&#189", "");
                        title[i] = title[i].Replace("0.5", "");
                        MatchCollection mc = Regex.Matches(title[i], @"(?:\d*\.)?\d+");
                        StringBuilder sb = new StringBuilder();

                        foreach (Match matc in mc)
                            sb.Append(matc.Value);
                        SumIng[i] = float.Parse(Convert.ToString(sb));

                    }
                    }
                    
                title = sourcePage.Substrings("<td class=\"definition-list-table__td definition-list-table__td_value\">", "</td>", 0);

                for (int i = 0; i < title.Length && i <= 14; i++)
                {
                    
                    MatchCollection mc = Regex.Matches(title[i], "[а-яА-Я ]+");
                    StringBuilder sb = new StringBuilder();

                    foreach (Match matc in mc)
                        sb.Append(matc.Value);

                    MeraIng[i] = sb.ToString();

                }
                                
                Label[] lb5 = new Label[15];
                CheckBox[] lb4 = new CheckBox[15];

                for (int j = 0; j < NameIng.Length && !(NameIng[j] == null); j++)
                {
                    
                    Ing = SumIng[j];
                    Res = Person * kof * Ing;
                    Math.Round(Res, 2);

                    lb5[j] = new System.Windows.Forms.Label();
                    lb5[j].Location = new System.Drawing.Point(460, 635 + j * 40);
                    lb5[j].Height = 40;
                    lb5[j].Name = "lb5" + (j + 1).ToString();
                    lb5[j].Width = 150;
                    lb5[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    if (SumIng[j] <= 0)
                    {
                        lb5[j].Text = MeraIng[j];
                    }
                    else
                    {
                        lb5[j].Text = Res + "    "+ MeraIng[j];
                    }

                    SumIng[j] = Res;
                    SumIngRes[j] = Res;
                    Controls.Add(lb5[j]);

                    lb4[j] = new System.Windows.Forms.CheckBox();
                    lb4[j].Location = new System.Drawing.Point(100, 635 + j * 40);
                    lb4[j].Name = "lb4" + (j + 1).ToString();
                    lb4[j].Height = 40;
                    lb4[j].Width = 250;
                    lb4[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lb4[j].Text = (j + 1) + "    " + NameIng[j];
                    Controls.Add(lb4[j]);
                    k = j;
                    top = 635 + j * 40;
                }

                title = sourcePage.Substrings("</noscript></div></div><div class=\"plain-text\">", "</div>", 0);
                Label[] lb6 = new Label[10];
                for (int k = 0; k < title.Length; k++)
                {

                    if (k >= 9)
                    {
                        Step[9] += title[k];
                    }
                    else
                    {
                        Step[k] = title[k];
                        lb6[k] = new System.Windows.Forms.Label();
                        lb6[k].Location = new System.Drawing.Point(100, top + (k + 1) * 100);
                        lb6[k].Height = 90;
                        lb6[k].Width = 500;
                        lb6[k].Name = "lb6" + (k + 1).ToString();
                        lb6[k].TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        lb6[k].Text = k + 1 + "    " + Step[k];
                        Controls.Add(lb6[k]);
                    }
                    if (k + 1 == title.Length && k > 9)
                    {
                        lb6[9] = new System.Windows.Forms.Label();
                        lb6[9].Location = new System.Drawing.Point(100, top + (10) * 100);
                        lb6[9].Height = 200;
                        lb6[9].Width = 500;
                        lb6[9].Name = "lb6" + 10.ToString();
                        lb6[9].TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        lb6[9].Text = 10 + "    " + Step[9];
                        Controls.Add(lb6[9]);
                    }
                    }
                
            }

            Button btn = new Button();
            btn.Text = "Добавить в список покупок";
            btn.Name = "AddShopList";
            btn.Width = 500;
            btn.Location = new System.Drawing.Point(100, top + 50);
            btn.Click += new System.EventHandler(AddShopList);
            this.Controls.Add(btn);
        }
                
        public void AddShopList(object sender, EventArgs e)
        {
            int err = 0;
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO [dbo].[ShopList] (IdResepy, Name, Person, NameIng1, SumIng1, MeraIng1, NameIng2, SumIng2, MeraIng2,  NameIng3, SumIng3, MeraIng3, NameIng4, SumIng4, MeraIng4, NameIng5, SumIng5, MeraIng5, NameIng6, SumIng6, MeraIng6, NameIng7, SumIng7, MeraIng7, NameIng8, SumIng8, MeraIng8, NameIng9, SumIng9, MeraIng9, NameIng10, SumIng10, MeraIng10, NameIng11, SumIng11, MeraIng11, NameIng12, SumIng12, MeraIng12, NameIng13, SumIng13, MeraIng13, NameIng14, SumIng14, MeraIng14, NameIng15, SumIng15, MeraIng15) VALUES (@IdResepy, @Name, @Person, @NameIng1, @SumIng1, @MeraIng1, @NameIng2, @SumIng2, @MeraIng2, @NameIng3, @SumIng3, @MeraIng3, @NameIng4, @SumIng4, @MeraIng4, @NameIng5, @SumIng5, @MeraIng5, @NameIng6, @SumIng6, @MeraIng6, @NameIng7, @SumIng7, @MeraIng7, @NameIng8, @SumIng8, @MeraIng8, @NameIng9, @SumIng9, @MeraIng9, @NameIng10, @SumIng10, @MeraIng10, @NameIng11, @SumIng11, @MeraIng11, @NameIng12, @SumIng12, @MeraIng12, @NameIng13, @SumIng13, @MeraIng13, @NameIng14, @SumIng14, @MeraIng14, @NameIng15, @SumIng15, @MeraIng15)";

                    command.Parameters.AddWithValue("IdResepy", IdResepy);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Person", Person);

                    for (int j = 0; j < k; j++)
                    {
                        if ((Controls["lb4" + (j + 1).ToString()] as CheckBox).Checked == true)
                        {
                            command.Parameters.AddWithValue("NameIng" + (j + 1), NameIng[j]);
                            command.Parameters.AddWithValue("SumIng" + (j + 1), SumIngRes[j]);
                            command.Parameters.AddWithValue("MeraIng" + (j + 1), MeraIng[j]);
                        }
                        else
                        {
                            err += 1;
                            command.Parameters.AddWithValue("NameIng" + (j + 1), "");
                            command.Parameters.AddWithValue("SumIng" + (j + 1), 0);
                            command.Parameters.AddWithValue("MeraIng" + (j + 1), "");
                        }
                    }
                    if (err == k)
                    { MessageBox.Show("Выберите ингредиенты"); }
                    else
                    {
                        for (int j = k; j < 15; j++)
                        {
                            command.Parameters.AddWithValue("NameIng" + (j + 1), "");
                            command.Parameters.AddWithValue("SumIng" + (j + 1), 0);
                            command.Parameters.AddWithValue("MeraIng" + (j + 1), "");
                        }

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Рецепт добавлен в лист покупок");
                            connection.Close();
                            Close();
                        }
                        catch
                        {
                            MessageBox.Show("Этот рецепт уже находится в списке покупок!");
                        }
                    }
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO [dbo].[Table] (Name, Opicanie, Time, ImgUrl, Person, NameIng1, SumIng1, MeraIng1, NameIng2, SumIng2, MeraIng2,  NameIng3, SumIng3, MeraIng3, NameIng4, SumIng4, MeraIng4, NameIng5, SumIng5, MeraIng5, NameIng6, SumIng6, MeraIng6, NameIng7, SumIng7, MeraIng7, NameIng8, SumIng8, MeraIng8, NameIng9, SumIng9, MeraIng9, NameIng10, SumIng10, MeraIng10, NameIng11, SumIng11, MeraIng11, NameIng12, SumIng12, MeraIng12, NameIng13, SumIng13, MeraIng13, NameIng14, SumIng14, MeraIng14, NameIng15, SumIng15, MeraIng15, Step1, Step2, Step3, Step4, Step5, Step6, Step7, Step8, Step9, Step10) VALUES (@Name, @Opicanie, @Time, @ImgUrl, @Person, @NameIng1, @SumIng1, @MeraIng1, @NameIng2, @SumIng2, @MeraIng2, @NameIng3, @SumIng3, @MeraIng3, @NameIng4, @SumIng4, @MeraIng4, @NameIng5, @SumIng5, @MeraIng5, @NameIng6, @SumIng6, @MeraIng6, @NameIng7, @SumIng7, @MeraIng7, @NameIng8, @SumIng8, @MeraIng8, @NameIng9, @SumIng9, @MeraIng9, @NameIng10, @SumIng10, @MeraIng10, @NameIng11, @SumIng11, @MeraIng11, @NameIng12, @SumIng12, @MeraIng12, @NameIng13, @SumIng13, @MeraIng13, @NameIng14, @SumIng14, @MeraIng14, @NameIng15, @SumIng15, @MeraIng15, @Step1, @Step2, @Step3, @Step4, @Step5, @Step6, @Step7, @Step8, @Step9, @Step10)";

                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Opicanie", Opicanie);
                    command.Parameters.AddWithValue("Time", Time);
                    command.Parameters.AddWithValue("ImgUrl", "http://"+ImgUrl);
                    command.Parameters.AddWithValue("Person", Person);

                    for (int j = 0; j < 15; j++)
                    {

                        if (NameIng[j] == null)
                        {
                            command.Parameters.AddWithValue("NameIng" + (j + 1), "");
                            command.Parameters.AddWithValue("SumIng" + (j + 1), 0);
                            command.Parameters.AddWithValue("MeraIng" + (j + 1), "");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("NameIng" + (j + 1), NameIng[j]);
                            command.Parameters.AddWithValue("SumIng" + (j + 1), SumIngRes[j]);
                            command.Parameters.AddWithValue("MeraIng" + (j + 1), MeraIng[j]);
                        }
                     

                    }

                    for (int j = 0; j < 10; j++)
                    {
                        if (Step[j] == null)   command.Parameters.AddWithValue("Step" + (j + 1), "");
                        else command.Parameters.AddWithValue("Step" + (j + 1), Step[j]);
                    }


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Рецепт добавлен");
                        connection.Close();
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Этот рецепт уже есть!");
                    }
                }
                }

            }
        }
    }


