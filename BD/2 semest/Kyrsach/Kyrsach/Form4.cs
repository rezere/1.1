using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Surname.Text.Length == 0)
            {
                MessageBox.Show("Заповніть поле Прізвище");
            }
            else if(Name.Text.Length == 0)
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
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT COUNT(*) FROM parent";

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO parent (ID, Surname, Name, SName, Adress, Number, Email) " +
                    "VALUES (@ID, @Surname, @Name, @SName, @Adress, @Number, @Email)";
                command.Parameters.AddWithValue("@ID", count);
                command.Parameters.AddWithValue("@Surname", Surname.Text);
                command.Parameters.AddWithValue("@Name", Name.Text);
                command.Parameters.AddWithValue("@SName", SecondName.Text);
                command.Parameters.AddWithValue("@Adress", Adress.Text);
                command.Parameters.AddWithValue("@Number", Number.Text);
                command.Parameters.AddWithValue("@Email", Email.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            Surname.Text = "";
            Name.Text = "";
            SecondName.Text = "";
            Adress.Text = "";
            Number.Text = "";
            Email.Text = "";


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
    }
}
