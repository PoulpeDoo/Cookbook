﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class maincs : Form
    {
        Form f;
        public maincs()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f = new Insert();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f = new Form1();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f = new Show();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f = new ShopList();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
