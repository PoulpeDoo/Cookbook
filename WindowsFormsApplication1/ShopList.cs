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
using System.Drawing.Printing;

namespace WindowsFormsApplication1
{
    public partial class ShopList : Form

    {
        Form f;
        public int top = 100;
        public int Delet = 0;
        public int[] l = new int[50];

        SqlConnection SqlConnection;

        public ShopList()
        {
            InitializeComponent();
        }

        private void ShopList_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("SELECT * FROM [ShopList]", SqlConnection);
            using (SqlConnection)
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                CheckBox[] cb = new CheckBox[50];
                
                for (int j = 0; reader.Read(); j++)
                {

                    l[j] = Int32.Parse(Convert.ToString(reader["IdResepy"]));
                    cb[j] = new System.Windows.Forms.CheckBox();
                    cb[j].Location = new System.Drawing.Point(100, top);
                    cb[j].Height = 40;
                    cb[j].Width = 250;
                    cb[j].Name = "cb" + (j).ToString();
                    cb[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    cb[j].Text = Convert.ToString(reader["Name"]);
                    Controls.Add(cb[j]);

                    top += 40;
                    Delet += 1;
                }

                top += 40;
                Button btn = new Button();
                btn = new System.Windows.Forms.Button();
                btn.Location = new System.Drawing.Point(100, top);
                btn.Height = 70;
                btn.Width = 450;
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Text = "Удалить рецепт из списка";
                btn.Click += new System.EventHandler(Del);
                Controls.Add(btn);

                reader.Close();
            }

            SqlConnection = new SqlConnection(connectionString);
            SqlCommand command1 = new SqlCommand("SELECT * FROM [ShopList]", SqlConnection);
            using (SqlConnection)

            {
                SqlConnection.Open();
                SqlDataReader reader = command1.ExecuteReader();

                top = top + 100;
                for (int j = 0; reader.Read(); j++)
                {
                    CheckBox[] lb = new CheckBox[15];

                    for (int k = 0; k < lb.Length; k++)
                    {
                        lb[k] = null;
                        lb[k] = new System.Windows.Forms.CheckBox();
                        lb[k].Location = new System.Drawing.Point(100, top);
                        lb[k].Height = 40;
                        lb[k].Width = 450;
                        lb[k].Name = "lb" + (k).ToString();
                        lb[k].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                        if (!(Convert.ToString(reader["NameIng" + (k + 1)]) == ""))
                        {
                            if (!(float.Parse(Convert.ToString(reader["SumIng" + (k + 1)])) <= 0.01))
                            {
                                lb[k].Text = Convert.ToString(reader["NameIng" + (k + 1)]) + "   " + float.Parse(Convert.ToString(reader["SumIng" + (k + 1)])) + "   " + Convert.ToString(reader["MeraIng" + (k + 1)]);
                                Controls.Add(lb[k]);
                                top += 40;
                            }

                        }
                    }
                }

            }
        }

        public void Del(object sender, EventArgs e)
        {
            int v = 0;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        for (int j = 0; j < Delet; j++)
                        {
                            if ((Controls["cb" + (j).ToString()] as CheckBox).Checked == true)
                            {
                               
                                command.Connection = connection;
                                command.CommandType = CommandType.Text;
                                command.CommandText = @"DELETE FROM ShopList WHERE IdResepy=" + l[j];
                                connection.Open();
                                command.ExecuteNonQuery();
                                connection.Close();
                                MessageBox.Show("Рецепт удален из списка!");
                                Close();
                                f = new ShopList();
                                f.Show();

                            }
                            else v += 1;

                        }
                }
                    catch
                {

                }
                if (v == Delet) MessageBox.Show("Cписок пуст!");
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}