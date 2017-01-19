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

        SqlConnection SqlConnection;
        public OpenResepy()
        {
            InitializeComponent();
        }

        private void OpenResepy_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);


            SqlCommand command = new SqlCommand("SELECT * FROM [Table] WHERE Id = 5", SqlConnection);


            using (SqlConnection)
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                Button bt = new Button();
                bt.Left = 100;
                bt.Top = 100;
                bt.Height = 40;
                bt.Width = 350;
                bt.Text = Convert.ToString(reader["Name"]);
                this.Controls.Add(bt);
            }
            reader.Close();
            }
        }
    }
}