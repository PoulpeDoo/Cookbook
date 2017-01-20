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


namespace WindowsFormsApplication1
{
    public partial class OpenResepy : Form
    {
        //int ID = IdRecepy;
        int Id;
        SqlConnection SqlConnection;
        public OpenResepy(Show f1)
        {
            InitializeComponent();
            Id = f1.IdResepy;
        }

        public void OpenResepy_Load(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);


            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE Id ="+Id, SqlConnection);


            using (SqlConnection)
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int toplb = 610;
                int topstep;

                while (reader.Read())
                {

                    Label lb1 = new Label();
                    lb1.Left = 218;
                    lb1.Top = 30;
                    lb1.Height = 40;
                    lb1.Width = 350;
                    lb1.Text = Convert.ToString(reader["Name"]);
                    this.Controls.Add(lb1);

                    PictureBox pb = new PictureBox();
                    pb.Left = 100;
                    pb.Top = 85;
                    pb.Height = 400;
                    pb.Width = 500;
                    pb.ImageLocation = Convert.ToString(reader["ImgUrl"]);
                    this.Controls.Add(pb);

                    Label lb2 = new Label();
                    lb2.Left = 100;
                    lb2.Top = 475;
                    lb2.Height = 40;
                    lb2.Width = 200;
                    lb2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lb2.Text = Convert.ToString(reader["Time"]);
                    this.Controls.Add(lb2);

                    NumericUpDown lb3 = new NumericUpDown();
                    lb3.Left = 550;
                    lb3.Top = 490;
                    lb3.Height = 40;
                    lb3.Width = 50;
                    lb3.Value = Int32.Parse(Convert.ToString(reader["Person"]));
                    this.Controls.Add(lb3);

                    TextBox txt = new TextBox();
                    txt.Left = 100;
                    txt.Top = 525;
                    txt.ReadOnly = true;
                    txt.Multiline = true;
                    txt.Height = 75;
                    txt.Width = 500;
                    txt.ScrollBars = ScrollBars.Vertical;
                    txt.Text = Convert.ToString(reader["Opicanie"]);
                    this.Controls.Add(txt);




                    for (int j = 1; j < 16 && !(Convert.ToString(reader["NameIng" + j]) == ""); j++)
                    {
                       
                        Label lb4 = new Label();
                        lb4.Left = 100;
                        lb4.Top = toplb;
                        lb4.Height = 40;
                        lb4.Width = 250;
                        lb4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        lb4.Text = j + "    " + Convert.ToString(reader["NameIng" + j]);
                        this.Controls.Add(lb4);
                        double sum = int.Parse(Convert.ToString(lb3.Value));

                        Label lb5 = new Label();
                        lb5.Left = 360;
                        lb5.Top = toplb;
                        lb5.Height = 40;
                        lb5.Width = 150;
                        lb5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        if (int.Parse(Convert.ToString(reader["SumIng" + j])) < 1)
                        {
                            lb5.Text = "" + Convert.ToString(reader["MeraIng" + j]);

                        }
                        else
                        {
                            lb5.Text = "" + int.Parse(Convert.ToString(reader["SumIng" + j])) + "       " + Convert.ToString(reader["MeraIng" + j]);
                        }
                        this.Controls.Add(lb5);

                        toplb += 40;
                    }
                    topstep = toplb + 50;
                    for (int k = 1; k < 11 && !(Convert.ToString(reader["Step" + k]) == ""); k++)
                    {
                        Label lb6 = new Label();
                        lb6.Left = 100;
                        lb6.Top = topstep;
                        lb6.Height = 90;
                        lb6.Width = 500;
                        lb6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        lb6.Text = k + "    " + Convert.ToString(reader["Step" + k]);
                        this.Controls.Add(lb6);
                        double sum = int.Parse(Convert.ToString(lb3.Value));


                        topstep += 100;
                    }





                }
            reader.Close();
            }
        }
    }
}