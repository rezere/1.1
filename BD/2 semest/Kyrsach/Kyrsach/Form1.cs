using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrsach
{
    public partial class Form1 : Form
    {
        public static string user;
        private string adminPass = "123", eduPass = "111";
        public Form1()
        {
            InitializeComponent();
            GroupButton.Visible = false;
            parentButton.Visible = false;
            TeachersButton.Visible = false;
            childrenButton.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void TeachersButton_Click(object sender, EventArgs e)
        {
            Form2 example = new Form2();
            example.Show();
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            Form3 example = new Form3();
            example.Show();
        }

        private void childrenButton_Click(object sender, EventArgs e)
        {
            Form5 example = new Form5();
            example.Show();
        }

        private void parentButton_Click(object sender, EventArgs e)
        {
            Form4 example = new Form4();
            example.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (password.Text.Length == 0)
            {
                user = "parent";
                GroupButton.Visible = true;
                parentButton.Visible = false;
                TeachersButton.Visible = false;
                childrenButton.Visible = true;
            }
            else if(password.Text == adminPass)
            {
                user = "admin";
                GroupButton.Visible = true;
                parentButton.Visible = true;
                TeachersButton.Visible = true;
                childrenButton.Visible = true;
                //Form5 example = new Form5();
                //example.Show();
            }
            else if(password.Text == eduPass)
            {
                user = "educ";
                GroupButton.Visible = true;
                parentButton.Visible = true;
                TeachersButton.Visible = false;
                childrenButton.Visible = true;
            }
            else
            {
                MessageBox.Show("Данный пароль не верный");
            }
            password.Text = "";
        }
    }
}
