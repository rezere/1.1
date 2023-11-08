using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.IO;

namespace Kyrsach
{
    public partial class Form1 : Form
    {
        public static string user;
        private string adminPass = "123", eduPass = "111";
        public Form1()
        {
            InitializeComponent();
            GroupButton.Visible = false;
            parentButton.Visible = false;
            TeachersButton.Visible = false;
            childrenButton.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void TeachersButton_Click(object sender, EventArgs e)
        {
            Form2 example = new Form2();
            example.Show();
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            Form3 example = new Form3();
            example.Show();
        }

        private void childrenButton_Click(object sender, EventArgs e)
        {
            Form5 example = new Form5();
            example.Show();
        }

        private void parentButton_Click(object sender, EventArgs e)
        {
            Form4 example = new Form4();
            example.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string backupFolderPath = @"C:/Users/merkyr/Documents/"; // Шлях до папки, де зберігатиметься бекап
            string mysqlDumpPath = @"C:\xampp\mysql\bin\mysqldump.exe"; // Шлях до виконуваного файлу mysqldump.exe

            string server = "localhost"; // Адреса сервера MySQL
            string database = "kindergarten"; // Назва бази даних
            string uid = "root"; // Ім'я користувача MySQL
            string password = ""; // Пароль користувача MySQL

            string backupFileName = $"{database}_Save.sql"; // Генерація унікального імені для бекапу
            string backupFilePath = Path.Combine(backupFolderPath, backupFileName); // Повний шлях до файлу бекапу

            // Створення команди для виконання mysqldump
            string command = $"--user={uid} --password={password} --host={server} --protocol=tcp --port=3306 --default-character-set=utf8 --single-transaction=TRUE --routines --result-file=\"{backupFilePath}\" --databases {database}";

            // Створення процесу та виконання команди mysqldump
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = mysqlDumpPath,
                Arguments = command,
                RedirectStandardInput = false,
                RedirectStandardOutput = false,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                process.WaitForExit();
            }

            MessageBox.Show("Бекап бази даних успішно створено.");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string mysqlPath = @"C:/xampp/mysql/bin/mysql.exe"; // Шлях до папки, де знаходиться виконуваний файл mysql.exe
            string server = "localhost"; // Адреса сервера MySQL
            string database = "kindergarten"; // Назва бази даних
            string uid = "root"; // Ім'я користувача MySQL
            string password = ""; // Пароль користувача MySQL

            string backupFilePath = @"C:/Users/merkyr/Documents/kindergarten_Save.sql"; // Шлях до файлу резервної копії

            // Створення команди для виконання mysql
            string command = $"--user={uid} --password={password} --host={server} --protocol=tcp --port=3306 --default-character-set=utf8 --comments --database {database} < \"{backupFilePath}\"";

            // Створення процесу та виконання команди mysql
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = mysqlPath,
                Arguments = command,
                RedirectStandardInput = false,
                RedirectStandardOutput = false,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                process.WaitForExit();
            }
            MessageBox.Show("Базу даних успішно відновлено з резервної копії.");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (password.Text.Length == 0)
            {
                user = "parent";
                GroupButton.Visible = true;
                parentButton.Visible = false;
                TeachersButton.Visible = false;
                childrenButton.Visible = true;
            }
            else if(password.Text == adminPass)
            {
                user = "admin";
                GroupButton.Visible = true;
                parentButton.Visible = true;
                TeachersButton.Visible = true;
                childrenButton.Visible = true;
                Save.Visible = true;
                LoadButton.Visible = true;
                //Form5 example = new Form5();
                //example.Show();
            }
            else if(password.Text == eduPass)
            {
                user = "educ";
                GroupButton.Visible = true;
                parentButton.Visible = true;
                TeachersButton.Visible = false;
                childrenButton.Visible = true;
            }
            else
            {
                MessageBox.Show("Данный пароль не верный");
            }
            password.Text = "";
        }
    }
}
