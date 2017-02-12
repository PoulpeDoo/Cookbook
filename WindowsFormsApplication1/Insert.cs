using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Insert : Form
    {
               
        public Insert()
        {
            InitializeComponent();
        }

        private void Insert_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO [dbo].[Table] (Name, Opicanie, Time, ImgUrl, Person, NameIng1, SumIng1, MeraIng1, NameIng2, SumIng2, MeraIng2,  NameIng3, SumIng3, MeraIng3, NameIng4, SumIng4, MeraIng4, NameIng5, SumIng5, MeraIng5, NameIng6, SumIng6, MeraIng6, NameIng7, SumIng7, MeraIng7, NameIng8, SumIng8, MeraIng8, NameIng9, SumIng9, MeraIng9, NameIng10, SumIng10, MeraIng10, NameIng11, SumIng11, MeraIng11, NameIng12, SumIng12, MeraIng12, NameIng13, SumIng13, MeraIng13, NameIng14, SumIng14, MeraIng14, NameIng15, SumIng15, MeraIng15, Step1, Step2, Step3, Step4, Step5, Step6, Step7, Step8, Step9, Step10) VALUES (@Name, @Opicanie, @Time, @ImgUrl, @Person, @NameIng1, @SumIng1, @MeraIng1, @NameIng2, @SumIng2, @MeraIng2, @NameIng3, @SumIng3, @MeraIng3, @NameIng4, @SumIng4, @MeraIng4, @NameIng5, @SumIng5, @MeraIng5, @NameIng6, @SumIng6, @MeraIng6, @NameIng7, @SumIng7, @MeraIng7, @NameIng8, @SumIng8, @MeraIng8, @NameIng9, @SumIng9, @MeraIng9, @NameIng10, @SumIng10, @MeraIng10, @NameIng11, @SumIng11, @MeraIng11, @NameIng12, @SumIng12, @MeraIng12, @NameIng13, @SumIng13, @MeraIng13, @NameIng14, @SumIng14, @MeraIng14, @NameIng15, @SumIng15, @MeraIng15, @Step1, @Step2, @Step3, @Step4, @Step5, @Step6, @Step7, @Step8, @Step9, @Step10)";

                    command.Parameters.AddWithValue("Name", nameTextBox.Text);
                    command.Parameters.AddWithValue("Opicanie", opicanieTextBox.Text);
                    command.Parameters.AddWithValue("Time", timeTextBox.Text);
                    command.Parameters.AddWithValue("ImgUrl", textBox1.Text);
                    command.Parameters.AddWithValue("Person", textBox2.Text);
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
                    command.Parameters.AddWithValue("Step9", textBox3.Text);
                    command.Parameters.AddWithValue("Step10", textBox4.Text);

                    if (nameTextBox.Text == "")
                    {
                        MessageBox.Show("Вы не ввели название рецепта");
                    }
                    else
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Поздравляем! Рецет успешно добавлен!");
                        connection.Close();
                        Close();
                    }
                }
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
