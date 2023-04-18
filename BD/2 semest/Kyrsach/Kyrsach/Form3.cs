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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kyrsach
{
    public partial class Form3 : Form
    {
        MySqlConnection connection = new MySqlConnection("User Id=root;Host=127.0.0.1;Database=kindergarten;Charset=utf8;");
        public Form3()
        {
            InitializeComponent();
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
        private void Form3_Load(object sender, EventArgs e)
        {
            string query = "SELECT CONCAT(Surname, ' ', LEFT(Name, 1), '.', " +
                "LEFT(SName, 1), '.') AS Surname, Name, SName FROM kindergartener";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Edu.DisplayMember = "Surname";
            Edu.ValueMember = "Name";
            Edu.DataSource = dt;


            LoadTable("SELECT groups.Name, groups.MaxClindren, groups.MinYear, groups.MaxYear, " +
                "groups.Schedule, " +
                "CONCAT(kindergartener.Surname, ' ', SUBSTR(kindergartener.Name, 1, 1), '.', " +
                "SUBSTR(kindergartener.SName, 1, 1), '.') AS Surname " +
                "FROM groups INNER JOIN kindergartener ON groups.ID_k = kindergartener.ID");
        }

        private void Add_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameBox.Text.Length == 0)
            {
                MessageBox.Show("Введіть назву групи");
            }
            else if (MaxCount.Text.Length == 0)
            {
                MessageBox.Show("Введіть максимальну кількість в групі");
            }
            else if (MinAge.Text.Length == 0)
            {
                MessageBox.Show("Введіть мінімальний вік");
            }
            else if (MaxAge.Text.Length == 0)
            {
                MessageBox.Show("Введіть максимальний вік");
            }
            else
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO groups (Name, MaxClindren, MinYear, MaxYear, Schedule, ID_k) VALUES (@Name, @MaxClindren, @MinYear, @MaxYear, @Schedule, @ID_k)";
                command.Parameters.AddWithValue("@Name", NameBox.Text);
                command.Parameters.AddWithValue("@MaxClindren", Int32.Parse(MaxCount.Text));
                command.Parameters.AddWithValue("@MinYear", Int32.Parse(MinAge.Text));
                command.Parameters.AddWithValue("@MaxYear", Int32.Parse(MaxAge.Text));
                command.Parameters.AddWithValue("@Schedule", Rozklad.Text);
                command.Parameters.AddWithValue("@ID_k", Edu.SelectedIndex + 1);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                LoadTable("SELECT groups.Name, groups.MaxClindren, groups.MinYear, groups.MaxYear, " +
               "groups.Schedule, " +
               "CONCAT(kindergartener.Surname, ' ', SUBSTR(kindergartener.Name, 1, 1), '.', " +
               "SUBSTR(kindergartener.SName, 1, 1), '.') AS Surname " +
               "FROM groups INNER JOIN kindergartener ON groups.ID_k = kindergartener.ID");
                Clear();
            }
        }

        void Clear()
        {
            NameBox.Text = "";
            MaxCount.Text = "";
            MinAge.Text = "";
            MaxAge.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadTable("SELECT groups.Name, groups.MaxClindren, groups.MinYear, groups.MaxYear, " +
              "groups.Schedule, " +
              "CONCAT(kindergartener.Surname, ' ', SUBSTR(kindergartener.Name, 1, 1), '.', " +
              "SUBSTR(kindergartener.SName, 1, 1), '.') AS Surname " +
              "FROM groups INNER JOIN kindergartener ON groups.ID_k = kindergartener.ID");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(ZapMin.Text.Length == 0)
            {
                MessageBox.Show("Введіть мінімальний вік");
            }
            else if (ZapMax.Text.Length == 0)
            {
                MessageBox.Show("Введіть максимальний вік");
            }
            else if(Int32.Parse(ZapMax.Text)< Int32.Parse(ZapMin.Text))
            {
                MessageBox.Show("Мінімальний вік не може бути більше");
            }
            else
            {
                LoadTable("SELECT groups.Name, groups.MaxClindren, groups.MinYear, groups.MaxYear, " +
              "groups.Schedule, " +
              "CONCAT(kindergartener.Surname, ' ', SUBSTR(kindergartener.Name, 1, 1), '.', " +
              "SUBSTR(kindergartener.SName, 1, 1), '.') AS Surname " +
              "FROM groups INNER JOIN kindergartener ON groups.ID_k = kindergartener.ID " +
                    "WHERE groups.MinYear = " + Int32.Parse(ZapMin.Text) + " AND groups.MaxYear = " + Int32.Parse(ZapMax.Text) + "; ");
            }
        }

        private void SearchName_TextChanged(object sender, EventArgs e)
        {
            LoadTable("SELECT groups.Name, groups.MaxClindren, groups.MinYear, groups.MaxYear, " +
              "groups.Schedule, " +
              "CONCAT(kindergartener.Surname, ' ', SUBSTR(kindergartener.Name, 1, 1), '.', " +
              "SUBSTR(kindergartener.SName, 1, 1), '.') AS Surname " +
              "FROM groups INNER JOIN kindergartener ON groups.ID_k = kindergartener.ID " +
                    "WHERE groups.Name LIKE '%" + SearchName.Text + "%'; ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT COUNT(*) FROM groups where Name = '" + Delete.Text+ "'";

            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            if (Delete.Text.Length < 1)
            {
                MessageBox.Show("Введіть назву групи");
            }
            else if (count == 0)
            {
                MessageBox.Show("Такої групи не існує");
            }
            else
            {
                command = connection.CreateCommand();

                command.CommandText = "SELECT COUNT(*) FROM children where G_Name = '" + Delete.Text+"'";

                connection.Open();
                count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                if (count == 0)
                {
                    command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM groups WHERE Name = '" + Delete.Text + "'";

                    connection.Open();
                    command.ExecuteScalar();
                    connection.Close();
                    LoadTable("SELECT groups.Name, groups.MaxClindren, groups.MinYear, groups.MaxYear, " +
                "groups.Schedule, " +
                "CONCAT(kindergartener.Surname, ' ', SUBSTR(kindergartener.Name, 1, 1), '.', " +
                "SUBSTR(kindergartener.SName, 1, 1), '.') AS Surname " +
                "FROM groups INNER JOIN kindergartener ON groups.ID_k = kindergartener.ID");
                    Delete.Text = "";
                }
                else
                {
                    MessageBox.Show("Не можливо видалити, бо в цій группі є діти");
                }
            }
        }
    }
}
