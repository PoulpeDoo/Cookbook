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
    public partial class UpDate : Form
    {
        public int Id;
        SqlConnection SqlConnection;
        public UpDate (OpenResepy o1)
        {
            Id = o1.Id;
            InitializeComponent();
        }
        private void UpDate_Load_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE Id =" + Id, SqlConnection);
            using (SqlConnection)
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nameTextBox.Text = Convert.ToString(reader["Name"]);
                    opicanieTextBox.Text = Convert.ToString(reader["Opicanie"]);
                    ImgUrl.Text = Convert.ToString(reader["ImgUrl"]);
                    timeTextBox.Text = Convert.ToString(reader["Time"]);
                    PersonTextBox.Text = Convert.ToString(reader["Person"]);

                    nameIng1TextBox.Text = Convert.ToString(reader["NameIng1"]);
                    nameIng2TextBox.Text = Convert.ToString(reader["NameIng2"]);
                    nameIng3TextBox.Text = Convert.ToString(reader["NameIng3"]);
                    nameIng4TextBox.Text = Convert.ToString(reader["NameIng4"]);
                    nameIng5TextBox.Text = Convert.ToString(reader["NameIng5"]);
                    nameIng6TextBox.Text = Convert.ToString(reader["NameIng6"]);
                    nameIng7TextBox.Text = Convert.ToString(reader["NameIng7"]);
                    nameIng8TextBox.Text = Convert.ToString(reader["NameIng8"]);
                    nameIng9TextBox.Text = Convert.ToString(reader["NameIng9"]);
                    nameIng10TextBox.Text = Convert.ToString(reader["NameIng10"]);
                    nameIng11TextBox.Text = Convert.ToString(reader["NameIng11"]);
                    nameIng12TextBox.Text = Convert.ToString(reader["NameIng12"]);
                    nameIng13TextBox.Text = Convert.ToString(reader["NameIng13"]);
                    nameIng14TextBox.Text = Convert.ToString(reader["NameIng14"]);
                    nameIng15TextBox.Text = Convert.ToString(reader["NameIng15"]);

                    sumIng1TextBox.Text = Convert.ToString(reader["SumIng1"]);
                    sumIng2TextBox.Text = Convert.ToString(reader["SumIng2"]);
                    sumIng3TextBox.Text = Convert.ToString(reader["SumIng3"]);
                    sumIng4TextBox.Text = Convert.ToString(reader["SumIng4"]);
                    sumIng5TextBox.Text = Convert.ToString(reader["SumIng5"]);
                    sumIng6TextBox.Text = Convert.ToString(reader["SumIng6"]);
                    sumIng7TextBox.Text = Convert.ToString(reader["SumIng7"]);
                    sumIng8TextBox.Text = Convert.ToString(reader["SumIng8"]);
                    sumIng9TextBox.Text = Convert.ToString(reader["SumIng9"]);
                    sumIng10TextBox.Text = Convert.ToString(reader["SumIng10"]);
                    sumIng11TextBox.Text = Convert.ToString(reader["SumIng11"]);
                    sumIng12TextBox.Text = Convert.ToString(reader["SumIng12"]);
                    sumIng13TextBox.Text = Convert.ToString(reader["SumIng13"]);
                    sumIng14TextBox.Text = Convert.ToString(reader["SumIng14"]);
                    sumIng15TextBox.Text = Convert.ToString(reader["SumIng15"]);

                    meraIng1TextBox.Text = Convert.ToString(reader["MeraIng1"]);
                    meraIng2TextBox.Text = Convert.ToString(reader["MeraIng2"]);
                    meraIng3TextBox.Text = Convert.ToString(reader["MeraIng3"]);
                    meraIng4TextBox.Text = Convert.ToString(reader["MeraIng4"]);
                    meraIng5TextBox.Text = Convert.ToString(reader["MeraIng5"]);
                    meraIng6TextBox.Text = Convert.ToString(reader["MeraIng6"]);
                    meraIng7TextBox.Text = Convert.ToString(reader["MeraIng7"]);
                    meraIng8TextBox.Text = Convert.ToString(reader["MeraIng8"]);
                    meraIng9TextBox.Text = Convert.ToString(reader["MeraIng9"]);
                    meraIng10TextBox.Text = Convert.ToString(reader["MeraIng10"]);
                    meraIng11TextBox.Text = Convert.ToString(reader["MeraIng11"]);
                    meraIng12TextBox.Text = Convert.ToString(reader["MeraIng12"]);
                    meraIng13TextBox.Text = Convert.ToString(reader["MeraIng13"]);
                    meraIng14TextBox.Text = Convert.ToString(reader["MeraIng14"]);
                    meraIng15TextBox.Text = Convert.ToString(reader["MeraIng15"]);

                    step1TextBox.Text = Convert.ToString(reader["Step1"]);
                    step2TextBox.Text = Convert.ToString(reader["Step2"]);
                    step3TextBox.Text = Convert.ToString(reader["Step3"]);
                    step4TextBox.Text = Convert.ToString(reader["Step4"]);
                    step5TextBox.Text = Convert.ToString(reader["Step5"]);
                    step6TextBox.Text = Convert.ToString(reader["Step6"]);
                    step7TextBox.Text = Convert.ToString(reader["Step7"]);
                    step8TextBox.Text = Convert.ToString(reader["Step8"]);
                    step9TextBox.Text = Convert.ToString(reader["Step9"]);
                    step10TextBox.Text = Convert.ToString(reader["Step10"]);

                }
                reader.Close();
            }
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

           string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE [Table] SET Name = @Name, Opicanie = @Opicanie, Time = @Time, ImgUrl = @ImgUrl, Person = @Person, NameIng1 = @NameIng1, SumIng1 = @SumIng1, MeraIng1 = @MeraIng1, NameIng2 = @NameIng2, SumIng2 = @SumIng2, MeraIng2 = @MeraIng2,  NameIng3 = @NameIng3, SumIng3 = @SumIng3, MeraIng3 = @MeraIng3, NameIng4 = @NameIng4, SumIng4 = @SumIng4, MeraIng4 = @MeraIng4, NameIng5 = @NameIng5, SumIng5 = @SumIng5, MeraIng5 = @MeraIng5, NameIng6 = @NameIng6, SumIng6 = @SumIng6, MeraIng6 = @MeraIng6, NameIng7 = @NameIng7, SumIng7 = @SumIng7, MeraIng7 = @MeraIng7, NameIng8 = @NameIng8, SumIng8 = @SumIng8, MeraIng8 = @MeraIng8, NameIng9 = @NameIng9, SumIng9 = @SumIng9, MeraIng9 = @MeraIng9, NameIng10 = @NameIng10, SumIng10 = @SumIng10, MeraIng10 = @MeraIng10, NameIng11 = @NameIng11, SumIng11 = @SumIng11, MeraIng11 = @MeraIng11, NameIng12 = @NameIng12, SumIng12 = @SumIng12, MeraIng12 = @MeraIng12, NameIng13 = @NameIng13, SumIng13 = @SumIng13, MeraIng13 = @MeraIng13, NameIng14 = @NameIng14, SumIng14 = @SumIng14, MeraIng14 = @MeraIng14, NameIng15 = @NameIng15, SumIng15 = @SumIng15, MeraIng15 = @MeraIng15, Step1 = @Step1, Step2 = @Step2, Step3 = @Step3, Step4 = @Step4, Step5 = @Step5, Step6 = @Step6, Step7 = @Step7, Step8 = @Step8, Step9 = @Step9, Step10 = @Step10 WHERE Id =" + Id;

                    command.Parameters.AddWithValue("Name", nameTextBox.Text);
                    command.Parameters.AddWithValue("Opicanie", opicanieTextBox.Text);
                    command.Parameters.AddWithValue("Time", timeTextBox.Text);
                    command.Parameters.AddWithValue("ImgUrl", ImgUrl.Text);
                    command.Parameters.AddWithValue("Person", PersonTextBox.Text);
                    command.Parameters.AddWithValue("NameIng1", nameIng1TextBox.Text);
                    command.Parameters.AddWithValue("NameIng2", nameIng2TextBox.Text);
                    command.Parameters.AddWithValue("NameIng3", nameIng3TextBox.Text);
                    command.Parameters.AddWithValue("NameIng4", nameIng4TextBox.Text);
                    command.Parameters.AddWithValue("NameIng5", nameIng5TextBox.Text);
                    command.Parameters.AddWithValue("NameIng6", nameIng6TextBox.Text);
                    command.Parameters.AddWithValue("NameIng7", nameIng7TextBox.Text);
                    command.Parameters.AddWithValue("NameIng8", nameIng8TextBox.Text);
                    command.Parameters.AddWithValue("NameIng9", nameIng9TextBox.Text);
                    command.Parameters.AddWithValue("NameIng10", nameIng10TextBox.Text);
                    command.Parameters.AddWithValue("NameIng11", nameIng11TextBox.Text);
                    command.Parameters.AddWithValue("NameIng12", nameIng12TextBox.Text);
                    command.Parameters.AddWithValue("NameIng13", nameIng13TextBox.Text);
                    command.Parameters.AddWithValue("NameIng14", nameIng14TextBox.Text);
                    command.Parameters.AddWithValue("NameIng15", nameIng15TextBox.Text);
                    command.Parameters.AddWithValue("SumIng1", sumIng1TextBox.Text);
                    command.Parameters.AddWithValue("SumIng2", sumIng2TextBox.Text);
                    command.Parameters.AddWithValue("SumIng3", sumIng3TextBox.Text);
                    command.Parameters.AddWithValue("SumIng4", sumIng4TextBox.Text);
                    command.Parameters.AddWithValue("SumIng5", sumIng5TextBox.Text);
                    command.Parameters.AddWithValue("SumIng6", sumIng6TextBox.Text);
                    command.Parameters.AddWithValue("SumIng7", sumIng7TextBox.Text);
                    command.Parameters.AddWithValue("SumIng8", sumIng8TextBox.Text);
                    command.Parameters.AddWithValue("SumIng9", sumIng9TextBox.Text);
                    command.Parameters.AddWithValue("SumIng10", sumIng10TextBox.Text);
                    command.Parameters.AddWithValue("SumIng11", sumIng11TextBox.Text);
                    command.Parameters.AddWithValue("SumIng12", sumIng12TextBox.Text);
                    command.Parameters.AddWithValue("SumIng13", sumIng13TextBox.Text);
                    command.Parameters.AddWithValue("SumIng14", sumIng14TextBox.Text);
                    command.Parameters.AddWithValue("SumIng15", sumIng15TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng1", meraIng1TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng2", meraIng2TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng3", meraIng3TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng4", meraIng4TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng5", meraIng5TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng6", meraIng6TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng7", meraIng7TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng8", meraIng8TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng9", meraIng9TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng10", meraIng10TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng11", meraIng11TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng12", meraIng12TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng13", meraIng13TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng14", meraIng14TextBox.Text);
                    command.Parameters.AddWithValue("MeraIng15", meraIng15TextBox.Text);
                    command.Parameters.AddWithValue("Step1", step1TextBox.Text);
                    command.Parameters.AddWithValue("Step2", step2TextBox.Text);
                    command.Parameters.AddWithValue("Step3", step3TextBox.Text);
                    command.Parameters.AddWithValue("Step4", step4TextBox.Text);
                    command.Parameters.AddWithValue("Step5", step5TextBox.Text);
                    command.Parameters.AddWithValue("Step6", step6TextBox.Text);
                    command.Parameters.AddWithValue("Step7", step7TextBox.Text);
                    command.Parameters.AddWithValue("Step8", step8TextBox.Text);
                    command.Parameters.AddWithValue("Step9", step9TextBox.Text);
                    command.Parameters.AddWithValue("Step10", step10TextBox.Text);

                    if (nameTextBox.Text == "")
                    {
                        MessageBox.Show("Вы не ввели название рецепта");
                    }
                    else
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Поздравляем! Рецет успешно изменен!");
                        nameTextBox.BackColor = Color.White;
                        connection.Close();
                        Close();

                    }
                }
            }
        }
    }
}
