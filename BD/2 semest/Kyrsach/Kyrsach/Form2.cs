using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                string pattern = @"^(099|098|066|050|039|096|097|063|080)\d{7}$";

                bool isValid = Regex.IsMatch(Number.Text, pattern);

                if (!isValid)
                {
                    Console.WriteLine("Номер телефона неверный.");
                    return;
                }

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

        private void button5_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                string sql = "SELECT Surname, Name, SName, Born, Adress, Number FROM kindergartener WHERE ID = @groupName";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@groupName", edit.Text);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            //NameGroup = edit.Text;
                            string surname = rdr.GetString(0);
                            string name = rdr.GetString(1);
                            string sname = rdr.GetString(2);
                            DateTime date = rdr.GetDateTime(3);
                            string adress = rdr.GetString(4);
                            string number = rdr.GetString(5);



                            // Присваиваем значения текстбоксам:
                            Surname.Text = surname;
                            FirstName.Text = name;
                            SecondName.Text = sname;
                            Adress.Text = adress;
                            Number.Text = number;
                            Day.Text = date.Day.ToString();
                            Year.Text = date.Year.ToString();
                            Month.SelectedIndex = date.Month - 1;


                            tabControl1.SelectedIndex = 0;
                            button1.Visible = false;
                            EditButton.Visible = true;
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
                string pattern = @"^(099|098|066|050|039|096|097|063|080)\d{7}$";

                bool isValid = Regex.IsMatch(Number.Text, pattern);

                if (!isValid)
                {
                    Console.WriteLine("Номер телефона неверный.");
                    return;
                }
                MySqlCommand command = connection.CreateCommand();
                DateTime birthdate = new DateTime(Int32.Parse(Year.Text), Month.SelectedIndex + 1, Int32.Parse(Day.Text));
               

                command.CommandText = "UPDATE kindergartener SET Surname = @Прізвище, Name = @Ім_я, SName = @По_батькові, Born = @Дата_народження, Adress = @Адреса, Number = @Телефон WHERE ID = @ID";

                command.Parameters.AddWithValue("@ID", edit.Text);
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

        private void AgeSearch_TextChanged(object sender, EventArgs e)
        {
            if (AgeSearch.Text.Length > 0)
            {
                string temp = "SELECT k.Surname, k.Name, k.SName, k.Born, k.Adress, k.Number " +
                    "FROM groups g INNER JOIN kindergartener k ON g.ID_k = k.ID " +
                    "WHERE g.MinYear <= " + AgeSearch.Text + " AND g.MaxYear >= " + AgeSearch.Text + "; ";
                LoadTable(temp);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string temp;
            switch (comboBox1.SelectedIndex + 1)
            {
                case 1:
                    {
                        temp = "SELECT * FROM kindergartener WHERE DATEDIFF(CURDATE(), Work) <= 1825";
                        break;
                    }
                case 2:
                    {
                        temp = "SELECT * FROM kindergartener WHERE DATEDIFF(CURDATE(), Work) > 1825 AND DATEDIFF(CURDATE(), Work) <= 3650";
                        break;
                    }
                case 3:
                    {
                        temp = "SELECT * FROM kindergartener WHERE DATEDIFF(CURDATE(), Work) > 3650" +
                            " AND DATEDIFF(CURDATE(), Work) <= 5475";
                        break;
                    }
                case 4:
                    {
                        temp = "SELECT * FROM kindergartener WHERE DATEDIFF(CURDATE(), Work) > 5475";
                        break;
                    }
                    default:
                    {
                        temp = "SELECT * FROM kindergartener";
                        break;
                    }
        }
        LoadTable(temp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string value = "SELECT * FROM kindergartener WHERE YEAR(CURDATE()) - YEAR(Born) BETWEEN 57 AND 60;";
            MySqlCommand command = new MySqlCommand(value, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            DataTable childrenData = new DataTable();
            childrenData.Load(reader);
            connection.Close();
            string outputPath = "C:/Users/merkyr/Documents/zvitVosp.pdf";
            // Создание документа PDF
            Document document = new Document();
            // Создание писателя PDF
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

            // Открытие документа
            document.Open();

            // Добавление иконки садка
            string imagePath = "V:\\1.1\\BD\\2 semest\\Kyrsach\\Kyrsach\\obj\\Debug\\garden-icon.jpg";
            float logoWidth = 100f; // Укажите требуемую ширину логотипа
            float logoHeight = 100f; // Укажите требуемую высоту логотипа
            if (File.Exists(imagePath))
            {
                iTextSharp.text.Image gardenIcon = iTextSharp.text.Image.GetInstance(imagePath);
                gardenIcon.ScaleToFit(logoWidth, logoHeight);
                document.Add(gardenIcon);
            }

            // Добавление заголовка
            BaseFont font = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(font, 20, iTextSharp.text.Font.ITALIC);
            Paragraph title = new Paragraph("Звіт про дітей", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);
            document.Add(new Paragraph("\n"));
            // Добавление данных из таблицы "children"
            BaseFont cellFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font cellFontStyle = new iTextSharp.text.Font(cellFont, 9);
            PdfPTable table = new PdfPTable(childrenData.Columns.Count);
            for (int i = 0; i < childrenData.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(childrenData.Columns[i].ColumnName, cellFontStyle));
                table.AddCell(cell);
            }

            for (int row = 0; row < childrenData.Rows.Count; row++)
            {
                for (int column = 0; column < childrenData.Columns.Count; column++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(childrenData.Rows[row][column].ToString(), cellFontStyle));
                    table.AddCell(cell);
                }
            }
            document.Add(table);

            // Добавление даты
            Paragraph date = new Paragraph(DateTime.Now.ToString("dd.MM.yyyy"));
            date.Alignment = Element.ALIGN_RIGHT;
            document.Add(date);
            document.Add(new Paragraph("\n"));
            Paragraph directorInfo = new Paragraph("Прізвище директора: Войцехов М.О.", cellFontStyle);
            directorInfo.Alignment = Element.ALIGN_LEFT;
            document.Add(directorInfo);
            // Закрытие документа
            document.Close();
        }
    }
}
