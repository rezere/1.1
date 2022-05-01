using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Regist mainForm = new Regist();
            mainForm.Show();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            //this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Auto mainForm = new Auto();
            mainForm.Show();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Katalog mainForm = new Katalog();
            mainForm.Show();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            this.Close();
        }
    }
}
