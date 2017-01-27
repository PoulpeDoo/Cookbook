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
        public int IdResepy;
        string result = "";
        Form f;
        SqlConnection SqlConnection;
           public Show()
        {
            InitializeComponent();
           
        }

        public void Show_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
           
            SqlConnection = new SqlConnection(connectionString);
            
            
            SqlCommand command = new SqlCommand("SELECT * FROM [Table]", SqlConnection);
          
          int toppb = 85;
          int leftpb = 100;
          int topbt = 85;
          int leftbt = 410;
          int leftTxt = 410;
          int topTxt = 135;

            using (SqlConnection)
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
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

                    TextBox txt = new TextBox();
                    txt.Left = leftTxt;
                    txt.Top = topTxt;
                    txt.ReadOnly = true;
                    txt.Multiline = true;
                    txt.Height = 150;
                    txt.Width = 350;
                    txt.ScrollBars = ScrollBars.Vertical;
                    txt.Text = Convert.ToString(reader["Opicanie"]);
                    this.Controls.Add(txt);
                    topTxt += txt.Height + 60;

                    PictureBox pb = new PictureBox();
                    pb.Left = leftpb;
                    pb.Top = toppb;
                    pb.Height = 200;
                    pb.Width = 300;
                    pb.ImageLocation = Convert.ToString(reader["ImgUrl"]);
                    this.Controls.Add(pb);
                    toppb += pb.Height + 10;
                    bt.Click += new System.EventHandler(resepy);
                    result += Convert.ToString(reader["Id"]);
                }
              reader.Close();
            }
            SqlConnection.Close();
        }

        public void resepy(object sender , EventArgs e)
        {
            IdResepy = Int32.Parse(Convert.ToString((sender as Button).Tag));
            OpenResepy f = new OpenResepy(this);
            f.ShowDialog();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

    }


  

}
