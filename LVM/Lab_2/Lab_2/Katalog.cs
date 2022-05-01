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
    public partial class Katalog : Form
    {
        public Katalog()
        {
            InitializeComponent();
        }

        private void Katalog_Load(object sender, EventArgs e)
        {
            button34.FlatAppearance.BorderSize = 0;
            button34.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            this.Close();
        }
    }
}
