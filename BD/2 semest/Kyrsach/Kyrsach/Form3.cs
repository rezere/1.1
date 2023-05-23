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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace Kyrsach
{
    public partial class Form3 : Form
    {
        MySqlConnection connection = new MySqlConnection("User Id=root;Host=127.0.0.1;Database=kindergarten;Charset=utf8;");
        string NameGroup;
        public Form3()
        {
            InitializeComponent();
            if (Form1.user == "parent")
            {
                tabControl1.Visible = false;

            }
            else if (Form1.user == "educ")
            {
                tabPage1.Enabled = false;
                tabPage1.Hide();

                tabPage2.Enabled = false;
                tabPage2.Hide();

                tabPage4.Enabled = false;
                tabPage4.Hide();

                label7.Enabled = false;
                ZapMin.Enabled = false;
                ZapMax.Enabled = false;
                button3.Enabled = false;

            }
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
            if (Form1.user == "educ")
            {
                tabPage1.Enabled = false;
                tabPage1.Hide();

                tabPage2.Enabled = false;
                tabPage2.Hide();
                tabPage4.Enabled = false;
                tabPage4.Hide();
            }
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
                List<int> parentIds = new List<int>();
                MySqlCommand command;
                using (connection)
                {
                    string query = "SELECT ID FROM kindergartener";

                    command = new MySqlCommand(query, connection);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int parentId = reader.GetInt32("ID");
                            parentIds.Add(parentId);
                        }
                    }

                    connection.Close();
                }
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO groups (Name, MaxClindren, MinYear, MaxYear, Schedule, ID_k) VALUES (@Name, @MaxClindren, @MinYear, @MaxYear, @Schedule, @ID_k)";
                command.Parameters.AddWithValue("@Name", NameBox.Text);
                command.Parameters.AddWithValue("@MaxClindren", Int32.Parse(MaxCount.Text));
                command.Parameters.AddWithValue("@MinYear", Int32.Parse(MinAge.Text));
                command.Parameters.AddWithValue("@MaxYear", Int32.Parse(MaxAge.Text));
                command.Parameters.AddWithValue("@Schedule", Rozklad.Text);
                command.Parameters.AddWithValue("@ID_k", parentIds[Edu.SelectedIndex]);

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
            if (!IsNumericInput(edit.Text))
            {
                MessageBox.Show("Номер запису повинен складатися з цифр");
                return;
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (!IsNumericInput(edit.Text))
            {
                MessageBox.Show("Номер запису повинен складатися з цифр");
                return;
            }
            

            using (connection)
            {
                connection.Open();
                string sql = "SELECT Name, MaxClindren, MinYear, MaxYear, Schedule, ID_k FROM groups WHERE Name = @groupName";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@groupName", edit.Text);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            NameGroup = edit.Text;
                            string name = rdr.GetString(0);
                            int maxClindren = rdr.GetInt32(1);
                            int minYear = rdr.GetInt32(2);
                            int maxYear = rdr.GetInt32(3);
                            string schedule = rdr.GetString(4);
                            int id_k = rdr.GetInt32(5);

                            // Присваиваем значения текстбоксам:
                            NameBox.Text = name;
                            MaxCount.Text = maxClindren.ToString();
                            MinAge.Text = minYear.ToString();
                            MaxAge.Text = maxYear.ToString();
                            string searchText = schedule;
                            int index = Rozklad.FindStringExact(searchText);
                            if (index != -1) // Если найдено совпадение
                            {
                                Rozklad.SelectedIndex = index; // Выбрать элемент в комбобоксе
                            }

                            Edu.SelectedIndex = id_k-1;
                            tabControl1.SelectedIndex = 0;
                            button1.Visible = false;
                            EditButton.Visible = true;
                        }
                        else
                        {
                            NameGroup = "";
                            MessageBox.Show("Запис не існує");
                        }
                    }
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
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
                MySqlCommand command;
                if (NameBox.Text != NameGroup)
                {
                    command = connection.CreateCommand();
                    command.CommandText = "UPDATE children SET G_Name = '" + NameBox.Text + "' WHERE Name = '" + NameGroup + "';";

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                command = connection.CreateCommand();
                command.CommandText = "UPDATE groups SET Name = '" + NameBox.Text +"', MaxClindren = " + MaxCount.Text + ", MinYear = " + MinAge.Text + ", MaxYear = " + MaxAge.Text + ", Schedule = '" + Rozklad.Text + "', ID_k = " + (Edu.SelectedIndex + 1) + " WHERE Name = '" + NameGroup + "';";

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                
                NameGroup = "";
                LoadTable("SELECT groups.Name, groups.MaxClindren, groups.MinYear, groups.MaxYear, " +
               "groups.Schedule, " +
               "CONCAT(kindergartener.Surname, ' ', SUBSTR(kindergartener.Name, 1, 1), '.', " +
               "SUBSTR(kindergartener.SName, 1, 1), '.') AS Surname " +
               "FROM groups INNER JOIN kindergartener ON groups.ID_k = kindergartener.ID");
                Clear();
                button1.Visible = true;
                EditButton.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string temp = "SELECT g.Schedule, COUNT(c.ID_c) as ChildrenCount " +
                "FROM groups g LEFT JOIN children c ON c.G_Name = g.Name GROUP BY g.Schedule; ";
            LoadTable(temp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string temp = "SELECT COUNT(DISTINCT g.Name) as 'К-ть груп', COUNT(c.ID_c) as 'К-ть дітей' " +
                "FROM groups g LEFT JOIN children c ON c.G_Name = g.Name;";
            LoadTable(temp);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string temp = "SELECT *FROM children WHERE G_Name LIKE '%" + textBox1.Text + "%'; ";
            LoadTable(temp);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string temp = "SELECT p.Surname, p.Name, p.SName, p.Adress, p.Number," +
                " p.Email FROM children d JOIN pclind pc ON d.ID_c = pc.ID_C " +
                "JOIN parent p ON p.ID = pc.ID_P WHERE d.G_Name LIKE '%" + textBox1.Text + "%'; ";
            LoadTable(temp);
        }
        private bool IsNumericInput(string input)
        {
            // Проверка, является ли введенный текст числом
            return int.TryParse(input, out _);
        }
    }
}
