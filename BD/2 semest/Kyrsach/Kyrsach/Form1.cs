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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (password.Text.Length == 0)
            {
                user = "parent";
            }
            else if(password.Text == adminPass)
            {
                user = "admin";
                Form2 example = new Form2();
                example.Show();
            }
            else if(adminPass == eduPass)
            {
                user = "educ";
            }
            else
            {
                MessageBox.Show("Данный пароль не верный");
            }
            password.Text = "";
            
        }
    }
}
