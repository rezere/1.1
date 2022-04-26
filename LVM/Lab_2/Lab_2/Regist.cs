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
    public partial class Regist : Form
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if(PIB.TextLength < 10) MessageBox.Show("Длина ФИО должна быть больше 10 символов");
            if (phoneNumber.TextLength != 10)
            {
                MessageBox.Show("Длина номера телефона должна быть равно 10 символов");
            }
            else if (phoneNumber.Text[0] != '0')
            {
                MessageBox.Show("Номер телефона должен начинаться с 0. Пример:0991337174");
            }
            bool dog = false, correct = false;
            string[] subs = mail.Text.Split('@');
            string[] mailType = { "mail.ru", "gmail.com", "ukr.net"};
            if (subs.Length == 2)
            {
                dog = true;
            }
            if (dog)
            {
                for (int i = 0; i < mailType.Length; i++)
                {
                    if (subs[1] == mailType[i]) correct = true;
                }
            }
            if(!dog || !correct) MessageBox.Show("Неверный формат почты. Пример:froust87@gmail.com");
            if(password.TextLength<6) MessageBox.Show("Длина пароля должна быть больше 6 символов");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Auto mainForm = new Auto();
            mainForm.Show();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            this.Close();
        }
    }
}
