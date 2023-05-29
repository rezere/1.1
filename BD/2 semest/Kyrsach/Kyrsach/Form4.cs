using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Net.Mime.MediaTypeNames;

namespace Kyrsach
{
    public partial class Form4 : Form
    {
        MySqlConnection connection = new MySqlConnection("User Id=root;Host=127.0.0.1;Database=kindergarten;Charset=utf8;");
        public Form4()
        {
            InitializeComponent();
            LoadTable("SELECT * FROM parent");
            if(Form1.user == "educ")
            {
                tabPage1.Enabled = false;
                tabPage1.Hide();

                tabPage2.Enabled = false;
                tabPage2.Hide();
                tabPage4.Enabled = false;
                tabPage4.Hide();
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Surname.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Прізвище");
            }
            else if (Name.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Ім'я");
            }
            else if (SecondName.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле По-батькові");
            }
            else if (Adress.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Адресу");
            }
            else if (Number.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Телефон");
            }
            else if (Surname.Text.Length > 50)
            {
                MessageBox.Show("Поле Прізвище не може перевищювати 50 символів");
            }
            else if (Name.Text.Length > 50)
            {
                MessageBox.Show("Поле Ім'я не може перевищювати 50 символів");
            }
            else if (SecondName.Text.Length > 50)
            {
                MessageBox.Show("Поле По-батькові не може перевищювати 50 символів");
            }
            else if (Adress.Text.Length > 50)
            {
                MessageBox.Show("Поле Адреса не може перевищювати 50 символів");
            }
            else if (Number.Text.Length != 10 )
            {
                MessageBox.Show("Поле Номер повинен містити 10 символів");
            }
            else if (Email.Text.Length > 50)
            {
                MessageBox.Show("Поле Пошта не може перевищювати 50 символів");
            }
            else
            {
                string pattern = @"^(099|098|066|050|039|096|097|063|080)\d{7}$";

                bool isValid = Regex.IsMatch(Number.Text, pattern);

                if (!isValid)
                {
                    MessageBox.Show("Номер телефона некоректний.");
                }
                else
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "SELECT Max(ID) FROM parent";

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();

                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO parent (ID, Surname, Name, SName, Adress, Number, Email) " +
                        "VALUES (@ID, @Surname, @Name, @SName, @Adress, @Number, @Email)";
                    command.Parameters.AddWithValue("@ID", count + 1);
                    command.Parameters.AddWithValue("@Surname", Surname.Text);
                    command.Parameters.AddWithValue("@Name", Name.Text);
                    command.Parameters.AddWithValue("@SName", SecondName.Text);
                    command.Parameters.AddWithValue("@Adress", Adress.Text);
                    command.Parameters.AddWithValue("@Number", Number.Text);
                    command.Parameters.AddWithValue("@Email", Email.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Surname.Text = "";
                    Name.Text = "";
                    SecondName.Text = "";
                    Adress.Text = "";
                    Number.Text = "";
                    Email.Text = "";
                }
            }
            


            LoadTable("SELECT * FROM parent");
        }

        private void LoadTable(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadTable("SELECT * FROM parent");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string temp = "SELECT G_Name, COUNT(DISTINCT ID_P) AS 'Кількість батьків'" +
                " FROM children JOIN pclind ON children.ID_c = pclind.ID_C" +
                " JOIN parent ON parent.ID = pclind.ID_P GROUP BY G_Name;";
            LoadTable(temp);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string temp = "SELECT p.Surname, COUNT(DISTINCT pc.ID_C) as ChildrenCount" +
                " FROM parent p JOIN pclind pc ON p.ID = pc.ID_P GROUP BY p.ID HAVING ChildrenCount >= 2; ";
            LoadTable(temp);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && IsNumericInput(textBox1.Text))
            {
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT *FROM parent where ID = " + textBox1.Text;

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                if (count > 0)
                {
                    button5.Visible = true;
                }
                else
                {
                    button5.Visible = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                string sql = "SELECT Surname, Name, SName, Adress, Number, Email FROM parent WHERE ID = @groupName";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@groupName", Convert.ToInt32(textBox1.Text));
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            
                            string surname = rdr.GetString(0);
                            string name = rdr.GetString(1);
                            string sName = rdr.GetString(2);
                            string adress = rdr.GetString(3);
                            string number = rdr.GetString(4);
                            string email = rdr.GetString(5);

                            Surname.Text = surname;
                            Name.Text = name;
                            SecondName.Text = sName;
                            Adress.Text = adress;
                            Number.Text = number;
                            Email.Text = email;


                            button1.Visible = false;
                            EditButton.Visible = true;
                            tabControl1.SelectedIndex = 0;

                        }
                        else
                        {
                            MessageBox.Show("Запис не існує");
                        }
                    }
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Surname.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Прізвище");
            }
            else if (Name.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Ім'я");
            }
            else if (SecondName.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле По-батькові");
            }
            else if (Adress.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Адресу");
            }
            else if (Number.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Телефон");
            }
            else if (Surname.Text.Length > 50)
            {
                MessageBox.Show("Поле Прізвище не може перевищювати 50 символів");
            }
            else if (Name.Text.Length > 50)
            {
                MessageBox.Show("Поле Ім'я не може перевищювати 50 символів");
            }
            else if (SecondName.Text.Length > 50)
            {
                MessageBox.Show("Поле По-батькові не може перевищювати 50 символів");
            }
            else if (Adress.Text.Length > 50)
            {
                MessageBox.Show("Поле Адреса не може перевищювати 50 символів");
            }
            else if (Number.Text.Length > 10)
            {
                MessageBox.Show("Поле Номер не може перевищювати 10 символів");
            }
            else if (Email.Text.Length > 50)
            {
                MessageBox.Show("Поле Пошта не може перевищювати 50 символів");
            }
            else
            {
                
                bool isValid = isNumber(Number.Text);

                if (!isValid)
                {
                    MessageBox.Show("Номер телефона неверный.");
                    return;
                }
                MySqlCommand command = connection.CreateCommand();

                command = connection.CreateCommand();
                //SELECT Surname, Name, SName, Adress, Number, Email FROM parent
                command.CommandText = "UPDATE parent SET Surname = '" + Surname.Text +
                    "', Name = '" + Name.Text + "', SName = '" + SecondName.Text + "', Adress = '" + Adress.Text
                    + "', Number = '" + Number.Text + "', Email = '" + Email.Text + "' WHERE ID =  "
                    + Convert.ToInt32(textBox1.Text) + ";";

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Surname.Text = "";
                Name.Text = "";
                SecondName.Text = "";
                Adress.Text = "";
                Number.Text = "";
                Email.Text = "";

                button1.Visible = true;
                EditButton.Visible = false;
                LoadTable("SELECT * FROM parent");
            }
        }

        private bool isNumber(string number)
        {
            string pattern = @"^(099|098|066|050|039|096|097|063|080)\d{7}$";
            return Regex.IsMatch(number, pattern);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT COUNT(*) FROM pclind where ID_P = " + textBox2.Text;

            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if(count>0)
            {
                MessageBox.Show("До цього запису батька прив'язані діти");
            }
            else
            {
                command = connection.CreateCommand();

                command.CommandText = "SELECT COUNT(*) FROM pqueue where ID_P = " + textBox2.Text;

                connection.Open();
                count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                if( count>0)
                {
                    MessageBox.Show("До цього запису батька прив'язані діти з черги");
                }
                else
                {
                    command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM parent WHERE ID = " + textBox2.Text;

                    connection.Open();
                    command.ExecuteScalar();
                    connection.Close();
                    LoadTable("SELECT * FROM parent");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text != "" && IsNumericInput(textBox2.Text))
            {
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT COUNT(*) FROM parent where ID = " + textBox2.Text;

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                if(count > 0)
                {
                    button6.Enabled = true;
                }
                else
                {
                    button6.Enabled = false;
                }
            }
            else
            {
                button6.Enabled = false;
            }
        }
        private bool IsNumericInput(string input)
        {
            // Проверка, является ли введенный текст числом
            return int.TryParse(input, out _);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
            {
                string temp = " SELECT *FROM parent WHERE Surname LIKE '%" + textBox3.Text + "%'";
                LoadTable(temp);
            }
            else if(textBox3.Text == "")
            {
                string temp = " SELECT *FROM parent";
                LoadTable(temp);
            }
        }
    }
}
