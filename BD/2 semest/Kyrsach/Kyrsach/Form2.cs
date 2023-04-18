using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;


namespace Kyrsach
{
    public partial class Form2 : Form
    {
        MySqlConnection connection = new MySqlConnection("User Id=root;Host=127.0.0.1;Database=kindergarten;Charset=utf8;");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            LoadTable("SELECT * FROM kindergartener");


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
        private void Add_Click(object sender, EventArgs e)
        {
            if (Surname.Text.Length == 0)
            {
                MessageBox.Show("Введіть Прізвище");
            }
            else if (FirstName.Text.Length == 0)
            {
                MessageBox.Show("Введіть Ім'я");
            }
            else if (SecondName.Text.Length == 0)
            {
                MessageBox.Show("Введіть По-Батькові");
            }
            else if (Day.Text.Length == 0)
            {
                MessageBox.Show("Введіть день");
            }
            else if (Year.Text.Length == 0)
            {
                MessageBox.Show("Введіть рік");
            }
            else if (Number.Text.Length == 0)
            {
                MessageBox.Show("Введіть телефон");
            }
            else if (Adress.Text.Length == 0)
            {
                MessageBox.Show("Введіть адресу");
            }
            else if (Surname.Text.Length > 50)
            {
                MessageBox.Show("Поле Прізвище не може перевищювати 50 символів");
            }
            else if (FirstName.Text.Length > 50)
            {
                MessageBox.Show("Поле Ім'я не може перевищювати 50 символів");
            }
            else if (SecondName.Text.Length > 50)
            {
                MessageBox.Show("Поле По-Батькові не може перевищювати 50 символів");
            }
            else if (Int32.Parse(Day.Text) < 1 || Int32.Parse(Day.Text) > 31)
            {
                MessageBox.Show("Некоректний день");
            }
            else if (Int32.Parse(Year.Text) < 1960 || Int32.Parse(Year.Text) > 2002)
            {
                MessageBox.Show("Некоректний рік");
            }
            else if (Number.Text.Length > 10)
            {
                MessageBox.Show("Поле Номер не може перевищювати 10 символів");
            }
            else if (Adress.Text.Length > 50)
            {
                MessageBox.Show("Поле Adress не може перевищювати 50 символів");
            }
            else
            {
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT MAX(ID) FROM kindergartener";

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                DateTime birthdate = new DateTime(Int32.Parse(Year.Text), Month.SelectedIndex+1, Int32.Parse(Day.Text));
                //MySqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO kindergartener (ID, Surname, Name, SName, Born, Adress, Number, Work) " +
                                      "VALUES (@ID, @Прізвище, @Ім_я, @По_батькові, @Дата_народження, @Адреса, @Телефон, @Сьогоднішня_дата)";

                command.Parameters.AddWithValue("@ID", count+1);
                command.Parameters.AddWithValue("@Прізвище", Surname.Text);
                command.Parameters.AddWithValue("@Ім_я", FirstName.Text);
                command.Parameters.AddWithValue("@По_батькові", SecondName.Text);
                command.Parameters.AddWithValue("@Дата_народження", birthdate);
                command.Parameters.AddWithValue("@Адреса", Adress.Text);
                command.Parameters.AddWithValue("@Телефон", Number.Text);
                command.Parameters.AddWithValue("@Сьогоднішня_дата", DateTime.Now.Date);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                connection.Close();

                LoadTable("SELECT * FROM kindergartener");
                Surname.Text = "";
                FirstName.Text = "";
                SecondName.Text = "";
                Year.Text = "";
                Day.Text = "";
                Adress.Text = "";
                Number.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecondName.Text = "";
            LoadTable("SELECT * FROM kindergartener");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT COUNT(*) FROM kindergartener";

            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            MessageBox.Show("Всього вихователів -" + count);
        }
        

        private void SurnameSearch_TextChanged(object sender, EventArgs e)
        {
            string temp = " SELECT* FROM kindergartener WHERE Surname LIKE '%"+SurnameSearch.Text+"%'";
            LoadTable(temp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadTable("SELECT * FROM kindergartener WHERE YEAR(CURDATE()) - YEAR(Born) BETWEEN 57 AND 60;");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT COUNT(*) FROM kindergartener where ID = " + Delete.Text;

            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if (Delete.Text.Length < 1)
            {
                MessageBox.Show("Введіть номер запису");
            }
            else if (count == 0)
            {
                MessageBox.Show("Такого запису не існує");
            }
            else
            {
                command = connection.CreateCommand();

                command.CommandText = "SELECT COUNT(*) FROM groups where ID_k = " + Delete.Text;

                connection.Open();
                count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                if(count == 0)
                {
                    command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM kindergartener WHERE ID = " + Delete.Text;

                    connection.Open();
                    command.ExecuteScalar();
                    connection.Close();
                    LoadTable("SELECT * FROM kindergartener");
                    Delete.Text = "";
                }
                else
                {
                    MessageBox.Show("Данний вихователь працює в групі. Заменіть його спочатку");
                }
            }

        }
    }
}
