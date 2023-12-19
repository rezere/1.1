using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2_2
{
    public partial class Form1 : Form
    {
        List<string> Vowels = new List<string>() {"a", "e", "i", "o","u","y"};
        List<string> Consonants = new List<string>() { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q",
            "r", "s","t", "v", "w", "x", "y", "z" };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomLengh = random.Next(1, 20);
            int length = (randomLengh + 4) / 5 * 5;
            int volews = length * 2 / 5;
            int consonants = length - volews;
            string password = "";
            MessageBox.Show("Lenght " + length + " volews " + volews + " consonants " + consonants);
            while (length > 0)
            {
                randomLengh = random.Next(2);
                if (randomLengh == 0)
                {
                    if(volews != 0)
                    {
                        int tempRandom = random.Next(Vowels.Count-1);
                        if (password.Length > 0)
                        {
                            if (Vowels[tempRandom][0] == password[password.Length-1])
                            {
                                continue;
                            }
                            else
                            {
                                password += Vowels[tempRandom];
                                volews--;
                                length--;
                            }
                        }
                        else
                        {
                            password += Vowels[tempRandom];
                            volews--;
                            length--;
                        }
                    }
                }
                else
                {
                    if (consonants != 0)
                    {
                        int tempRandom = random.Next(Consonants.Count - 1);
                        if (password.Length > 0)
                        {
                            if (Consonants[tempRandom][0] == password[password.Length-1])
                            {
                                continue;
                            }
                            else
                            {
                                password += Consonants[tempRandom];
                                consonants--;
                                length--;
                            }
                        }
                        else
                        {
                            password += Consonants[tempRandom];
                            consonants--;
                            length--;
                        }
                    }
                }
            }
            
            MessageBox.Show(" Password " + password);

            string temp = "Ваш пароль: " + password + ". Хотите сменить его?";
            DialogResult result = MessageBox.Show(temp, "Смена пароля", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(result == DialogResult.Yes)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4.Text.Length >5)
            {
                        //Сохраняем
            }
        }
    }
}
