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
        public int k = 0;
        public float kof;
        public float Res;
        public float Ing;
        public int IdResepy;
        public int top;

        public int Id;
        public string Name;
        public int Person = 0;
        public string[] NameIng = new string [15];
        public float[] SumIng = new float[15];
        public string[] MeraIng = new string[15];
        
        Form o;

        SqlConnection SqlConnection;
        public OpenResepy(Show f1)
        {
            InitializeComponent();
            Id = f1.IdResepy;
            ratio.Text = "";

        }
        public void button1_Click(object sender, EventArgs e)
        {
            Person++;
            ratio.Text = Convert.ToString(Person);
            Refresh();
            Update();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE Id =" + Id, SqlConnection);

            using (SqlConnection)
            {

                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kof = 1 / (float.Parse(Convert.ToString(reader["Person"])));

                    for (int j = 1; j < 16 && !(Convert.ToString(reader["NameIng" + j]) == ""); j++)
                    {
                        this.Controls.RemoveByKey("lb5" + (j).ToString());
                    }
                 
                    Label[] lb5 = new Label[15];
                    for (int j = 0; j < lb5.Length && !(Convert.ToString(reader["NameIng" + (j + 1)]) == ""); j++)
                    {

                        NameIng[j] = Convert.ToString(reader["NameIng" + (j + 1)]);
                        MeraIng[j] = Convert.ToString(reader["MeraIng" + (j + 1)]);

                        Ing = float.Parse(Convert.ToString(reader["SumIng" + (j + 1)]));
                        Res = Person * kof * Ing;

                        lb5[j] = new System.Windows.Forms.Label();
                        lb5[j].Location = new System.Drawing.Point(460, 610 + j * 40);
                        lb5[j].Height = 40;
                        lb5[j].Name = "lb5" + (j + 1).ToString();
                        lb5[j].Width = 150;
                        lb5[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                        if (int.Parse(Convert.ToString(reader["SumIng" + (j + 1)])) < 1)

                        {
                            lb5[j].Text = "" + Convert.ToString(reader["MeraIng" + (j + 1)]);
                        }
                        else
                        {
                            lb5[j].Text = Res + "       " + Convert.ToString(reader["MeraIng" + (j + 1)]);
                        }

                        SumIng[j] = Res;
                        Controls.Add(lb5[j]);
                         
                    }

                }
                reader.Close();
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
            Refresh();
            Update();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE Id =" + Id, SqlConnection);

            using (SqlConnection)
            {

                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kof = 1 / (float.Parse(Convert.ToString(reader["Person"])));

                    for (int j = 1; j < 16 && !(Convert.ToString(reader["NameIng" + j]) == ""); j++)
                    {
                        this.Controls.RemoveByKey("lb5" + (j).ToString());
                    }

                    Label[] lb5 = new Label[15];
                    for (int j = 0; j < lb5.Length && !(Convert.ToString(reader["NameIng" + (j + 1)]) == ""); j++)
                    {

                        NameIng[j] = Convert.ToString(reader["NameIng" + (j + 1)]);
                        MeraIng[j] = Convert.ToString(reader["MeraIng" + (j + 1)]);

                        Ing = float.Parse(Convert.ToString(reader["SumIng" + (j + 1)]));
                        Res = Person * kof * Ing;

                        lb5[j] = new System.Windows.Forms.Label();
                        lb5[j].Location = new System.Drawing.Point(460, 610 + j * 40);
                        lb5[j].Height = 40;
                        lb5[j].Name = "lb5" + (j + 1).ToString();
                        lb5[j].Width = 150;
                        lb5[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                        if (int.Parse(Convert.ToString(reader["SumIng" + (j + 1)])) < 1)
                        {
                            lb5[j].Text = "" + Convert.ToString(reader["MeraIng" + (j + 1)]);
                        }
                        else
                        {
                            lb5[j].Text = Res + "       " + Convert.ToString(reader["MeraIng" + (j + 1)]);
                        }

                        SumIng[j] = Res;
                        Controls.Add(lb5[j]);

                    }

                }
                reader.Close();
            }
        }

        public void OpenResepy_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE Id =" + Id, SqlConnection);
           
            using (SqlConnection)
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Name = Convert.ToString(reader["Name"]);
                    kof = 1 / (float.Parse(Convert.ToString(reader["Person"])));
                    Person = int.Parse(Convert.ToString(reader["Person"]));

                    ratio.Text = Convert.ToString(Person);
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
                    pb.Tag = Convert.ToString(reader["Id"]);

                    Label lb2 = new Label();
                    lb2.Left = 100;
                    lb2.Top = 475;
                    lb2.Height = 40;
                    lb2.Width = 200;
                    lb2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    lb2.Text = Convert.ToString(reader["Time"]);
                    this.Controls.Add(lb2);

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

                    Label[] lb5 = new Label[15];
                    CheckBox[] lb4 = new CheckBox[15];

                    for (int j = 0; j < lb5.Length && !(Convert.ToString(reader["NameIng" + (j+1)]) == ""); j++)
                    {

                        NameIng[j] = Convert.ToString(reader["NameIng" + (j+1)]);
                        MeraIng[j] = Convert.ToString(reader["MeraIng" + (j+1)]);
                       
                        Ing = float.Parse(Convert.ToString(reader["SumIng" + (j+1)]));
                        Res = Person * kof * Ing;

                        lb5[j] = new System.Windows.Forms.Label();
                        lb5[j].Location = new System.Drawing.Point(460, 610 + j * 40);
                        lb5[j].Height = 40;
                        lb5[j].Name = "lb5" + (j + 1).ToString();
                        lb5[j].Width = 150;
                        lb5[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                        if (int.Parse(Convert.ToString(reader["SumIng" + (j+1)])) < 1)
                        {
                            lb5[j].Text = "" + Convert.ToString(reader["MeraIng" + (j+1)]);
                        }
                        else
                        {
                            lb5[j].Text = Res + "       " + Convert.ToString(reader["MeraIng" + (j+1)]);
                        }

                        SumIng[j] = Res;
                        Controls.Add(lb5[j]);

                        lb4[j] = new System.Windows.Forms.CheckBox();
                        lb4[j].Location = new System.Drawing.Point(100, 610 + j * 40);
                        lb4[j].Name = "lb4" + (j + 1).ToString();
                        lb4[j].Height = 40;
                        lb4[j].Width = 250;
                        lb4[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        lb4[j].Text = (j+1) + "    " + Convert.ToString(reader["NameIng" + (j+1)]);
                        Controls.Add(lb4[j]);
                        
                        k = j;
                        top = 610 + j * 40;
                    }


                    Label[] lb6 = new Label[10];
                    for (int k = 0; k < lb6.Length && !(Convert.ToString(reader["Step" + (k + 1)]) == ""); k++)
                    {
                        lb6[k] = new System.Windows.Forms.Label();
                        lb6[k].Location = new System.Drawing.Point(100, top + (k+1) * 100);
                        lb6[k].Height = 90;
                        lb6[k].Width = 500;
                        lb6[k].Name = "lb6" + (k + 1).ToString();
                        lb6[k].TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        lb6[k].Text = k + 1 + "    " + Convert.ToString(reader["Step" + (k + 1)]);
                        Controls.Add(lb6[k]);
                    }
                   
                }
                reader.Close();
            }

            Button btn = new Button();
            btn.Text = "Добавить в список покупок";
            btn.Name = "AddShopList";
            btn.Width = 500;
            btn.Location = new System.Drawing.Point(100, top + 50);
            btn.Click += new System.EventHandler(AddShopList);
            this.Controls.Add(btn);

        }

        public void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }


        private void ratio_Click(object sender, EventArgs e)
        {

        }

        public void button3_Click(object sender, EventArgs e)
        {

            UpDate o = new UpDate(this);
            o.ShowDialog();
            Close();
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

                    command.Parameters.AddWithValue("IdResepy", Id);
                    command.Parameters.AddWithValue("Name", Name);
                    command.Parameters.AddWithValue("Person", Person);

                    for (int j = 0; j < k; j++)
                    {
                        if ((Controls["lb4" + (j + 1).ToString()] as CheckBox).Checked == true)
                        {
                            command.Parameters.AddWithValue("NameIng" + (j + 1), NameIng[j]);
                            command.Parameters.AddWithValue("SumIng" + (j + 1), SumIng[j]);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

 }
