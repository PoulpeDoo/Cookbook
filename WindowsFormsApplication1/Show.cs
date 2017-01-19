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
        string result = "";
        public string id;
        Form f;
        SqlConnection SqlConnection;
           public Show()
        {
            InitializeComponent();
        }

       
        
         public void Show_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);
            
            
            SqlCommand command = new SqlCommand("SELECT * FROM [Table]", SqlConnection);
          
          int toppb = 85;
          int leftpb = 100;
          int topbt = 85;
          int leftbt = 410;
          

            using (SqlConnection)
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                //id = Convert.ToString(reader["Name"]);

                while (reader.Read())
                {

                    Button bt = new Button();
                    bt.Left = leftbt;
                    bt.Top = topbt;
                    bt.Height = 40;
                    bt.Width = 350;
                    bt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    bt.Text = Convert.ToString(reader["Name"]);
                    bt.Tag = Convert.ToString(reader["id"]);
                    this.Controls.Add(bt);
                    topbt += bt.Height + 170;





                    PictureBox pb = new PictureBox();
                    pb.Left = leftpb;
                    pb.Top = toppb;
                    pb.Height = 200;
                    pb.Width = 300;
                    pb.ImageLocation = Convert.ToString(reader["ImgUrl"]);
                    this.Controls.Add(pb);
                    toppb += pb.Height + 10;
                   
                    
                    bt.Click += new System.EventHandler(resepy);
                                 

                    // button.TextAlign = MiddleCenter;
                   result += Convert.ToString(reader["Id"]);

                }
          
              reader.Close();
            }
        }


        public void resepy(object sender , EventArgs e)
        {

            MessageBox.Show(Convert.ToString((sender as Button).Tag));
            int IdResepy = Int32.Parse(Convert.ToString((sender as Button).Tag));
            f = new OpenResepy();
            f.Show();

        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

    }
}
