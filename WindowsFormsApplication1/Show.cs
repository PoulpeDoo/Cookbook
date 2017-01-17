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
    public partial class Show : Form

    {
        SqlConnection SqlConnection;
        public Show()
        {
            InitializeComponent();
        }

        private void Show_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);
            
            
            SqlCommand command = new SqlCommand("SELECT * FROM [Table]", SqlConnection);
          //  string result = "";
          int top1 = 50;
          int left1 = 100;
            int top2 = 50;
            int left2 = 255;

            using (SqlConnection)
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    ListBox listbox = new ListBox();
                    listbox.Left = left2;
                    listbox.Top = top2;
                    listbox.Height = 82;
                    listbox.Width = 550;
                    Button button = new Button();
                    button.Left = left1;
                    button.Top = top1;
                    button.Height = 82;
                    button.Width = 150;
                    // button.TextAlign = MiddleCenter;
                    //   result += Convert.ToString(reader["Name"]);
                    listbox.Items.Add(Convert.ToString(reader["Opicanie"]));
                    button.Text = Convert.ToString(reader["Name"]);
                    this.Controls.Add(listbox);
                    top2 += listbox.Height + 2;
                    this.Controls.Add(button);
                    top1 += button.Height + 2;
                    
                }
               // 
                // Закрыть DataReader
                reader.Close();
            }
           

        }

                         
              
           
                  
        
    }
}
