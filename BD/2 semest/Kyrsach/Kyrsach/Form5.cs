using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrsach
{
    public partial class Form5 : Form
    {
        MySqlConnection connection = new MySqlConnection("User Id=root;Host=127.0.0.1;Database=kindergarten;Charset=utf8;");

        public Form5()
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
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Father = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Mother = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Parent = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Group = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Adress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Year = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Month = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Day = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Surname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(646, 390);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(754, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(377, 390);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.Parent);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.Group);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.Adress);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.Year);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.Month);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.Day);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.SName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.Name);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.Surname);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(369, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Father);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Mother);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(21, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 87);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 58);
            this.button1.TabIndex = 19;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Father
            // 
            this.Father.FormattingEnabled = true;
            this.Father.Items.AddRange(new object[] {
            "Січень",
            "Лютий",
            "Березень",
            "Квітень",
            "Травень",
            "Червень",
            "Липень ",
            "Серпень",
            "Вересень",
            "Жовтень",
            "Листопад",
            "Грудень"});
            this.Father.Location = new System.Drawing.Point(56, 50);
            this.Father.Name = "Father";
            this.Father.Size = new System.Drawing.Size(137, 21);
            this.Father.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Батько";
            // 
            // Mother
            // 
            this.Mother.FormattingEnabled = true;
            this.Mother.Items.AddRange(new object[] {
            "Січень",
            "Лютий",
            "Березень",
            "Квітень",
            "Травень",
            "Червень",
            "Липень ",
            "Серпень",
            "Вересень",
            "Жовтень",
            "Листопад",
            "Грудень"});
            this.Mother.Location = new System.Drawing.Point(56, 13);
            this.Mother.Name = "Mother";
            this.Mother.Size = new System.Drawing.Size(137, 21);
            this.Mother.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Мати";
            // 
            // Parent
            // 
            this.Parent.AutoSize = true;
            this.Parent.Location = new System.Drawing.Point(21, 247);
            this.Parent.Name = "Parent";
            this.Parent.Size = new System.Drawing.Size(102, 17);
            this.Parent.TabIndex = 17;
            this.Parent.TabStop = true;
            this.Parent.Text = "Батьки є в базі";
            this.Parent.UseVisualStyleBackColor = true;
            this.Parent.Click += new System.EventHandler(this.Parent_Click_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 224);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(130, 17);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Батьків немає в базі";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click_1);
            // 
            // Group
            // 
            this.Group.FormattingEnabled = true;
            this.Group.Location = new System.Drawing.Point(125, 188);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(121, 21);
            this.Group.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Група";
            // 
            // Adress
            // 
            this.Adress.Location = new System.Drawing.Point(125, 154);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(153, 20);
            this.Adress.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Адреса";
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(294, 121);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(49, 20);
            this.Year.TabIndex = 11;
            this.Year.TextChanged += new System.EventHandler(this.Year_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Рік";
            // 
            // Month
            // 
            this.Month.FormattingEnabled = true;
            this.Month.Items.AddRange(new object[] {
            "Січень",
            "Лютий",
            "Березень",
            "Квітень",
            "Травень",
            "Червень",
            "Липень ",
            "Серпень",
            "Вересень",
            "Жовтень",
            "Листопад",
            "Грудень"});
            this.Month.Location = new System.Drawing.Point(139, 121);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(121, 21);
            this.Month.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Місяць";
            // 
            // Day
            // 
            this.Day.Location = new System.Drawing.Point(51, 120);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(34, 20);
            this.Day.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "День";
            // 
            // SName
            // 
            this.SName.Location = new System.Drawing.Point(125, 83);
            this.SName.Name = "SName";
            this.SName.Size = new System.Drawing.Size(153, 20);
            this.SName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "По батькові";
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(125, 51);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(153, 20);
            this.Name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ім\'я";
            // 
            // Surname
            // 
            this.Surname.Location = new System.Drawing.Point(125, 17);
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(153, 20);
            this.Surname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Прізвище";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(369, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            this.ClientSize = new System.Drawing.Size(1187, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            //this.Name = "Form5";
            this.Text = "Діти";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox Name;
        private Label label2;
        private TextBox Surname;
        private Label label1;
        private TabPage tabPage2;
        private TextBox SName;
        private Label label3;
        private Label label5;
        private TextBox Day;
        private Label label4;
        private ComboBox Month;
        private Label label6;
        private TextBox Year;
        private TextBox Adress;
        private Label label7;
        private Label label8;
        private ComboBox Group;
        private RadioButton radioButton1;
        private RadioButton Parent;

        private void Parent_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            string query = "SELECT CONCAT(Surname, ' ', LEFT(Name, 1), '.', " +
               "LEFT(SName, 1), '.') AS Surname, Name, SName FROM parent";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Mother.DisplayMember = "Surname";
            Mother.ValueMember = "Name";
            Mother.DataSource = dt;

            string query2 = "SELECT CONCAT(Surname, ' ', LEFT(Name, 1), '.', " +
               "LEFT(SName, 1), '.') AS Surname, Name, SName FROM parent";
            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            Father.DisplayMember = "Surname";
            Father.ValueMember = "Name";
            Father.DataSource = dt2;
        }

        private void radioButton1_Click_1(object sender, EventArgs e)
        {
            Form4 example = new Form4();
            example.Show();
        }

        private GroupBox groupBox1;
        private Label label9;
        private ComboBox Mother;
        private ComboBox Father;
        private Label label10;
        private Button button1;

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Surname.Text.Length == 0)
            {
                MessageBox.Show("Введіть Прізвище");
            }
            else if (Name.Text.Length == 0)
            {
                MessageBox.Show("Введіть Ім'я");
            }
            else if (SName.Text.Length == 0)
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
            else if (Adress.Text.Length == 0)
            {
                MessageBox.Show("Введіть адресу");
            }
            else if (Surname.Text.Length > 50)
            {
                MessageBox.Show("Поле Прізвище не може перевищювати 50 символів");
            }
            else if (Name.Text.Length > 50)
            {
                MessageBox.Show("Поле Ім'я не може перевищювати 50 символів");
            }
            else if (SName.Text.Length > 50)
            {
                MessageBox.Show("Поле По-Батькові не може перевищювати 50 символів");
            }
            else if (int.Parse(Day.Text) < 1 || int.Parse(Day.Text) > 31)
            {
                MessageBox.Show("Некоректний день");
            }
            else if (int.Parse(Year.Text) < 2018 || int.Parse(Year.Text) > 2023)
            {
                MessageBox.Show("Некоректний рік");
            }
            else if (Adress.Text.Length > 50)
            {
                MessageBox.Show("Поле Adress не може перевищювати 50 символів");
            }
            else
            {
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT COUNT(*) FROM children";

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                DateTime birthdate = new DateTime(Int32.Parse(Year.Text), Month.SelectedIndex + 1, Int32.Parse(Day.Text));

                command.CommandText = "INSERT INTO children (ID_c, Surname, Name, SName, Born, Adress, G_Name) " +
                                      "VALUES (@ID, @Прізвище, @Ім_я, @По_батькові, @Дата_народження, @Адреса, @Група)";

                command.Parameters.AddWithValue("@ID", count + 1);
                command.Parameters.AddWithValue("@Прізвище", Surname.Text);
                command.Parameters.AddWithValue("@Ім_я", Name.Text);
                command.Parameters.AddWithValue("@По_батькові", SName.Text);
                command.Parameters.AddWithValue("@Дата_народження", birthdate);
                command.Parameters.AddWithValue("@Адреса", Adress.Text);
                command.Parameters.AddWithValue("@Група", Group.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                connection.Close();

                if (Mother.Text != "" && Father.Text != "")
                {
                    command.CommandText = "SELECT COUNT(*) FROM pclind";

                    connection.Open();
                    int mothercount = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO pclind (ID_PC, ID_P, ID_C) " +
                                          "VALUES (@ID, @Code, @Ім_я)";

                    command.Parameters.AddWithValue("@ID", mothercount + 1);
                    command.Parameters.AddWithValue("@Code", Mother.SelectedIndex+1);
                    command.Parameters.AddWithValue("@Ім_я", count + 1);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    command.CommandText = "SELECT COUNT(*) FROM pclind";

                    connection.Open();
                    mothercount = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO pclind (ID_PC, ID_P, ID_C) " +
                                          "VALUES (@ID, @Code, @Ім_я)";

                    command.Parameters.AddWithValue("@ID", mothercount + 1);
                    command.Parameters.AddWithValue("@Code", Father.SelectedIndex+1);
                    command.Parameters.AddWithValue("@Ім_я", count + 1);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void Year_TextChanged(object sender, EventArgs e)
        {
            Group.Items.Clear();
            DateTime date = DateTime.Now;
            connection.Open();
            int temp = date.Year - int.Parse(Year.Text);
            // SQL запит
            string sql = @"SELECT g.Name, g.MaxClindren FROM groups g INNER JOIN 
            children c ON g.Name = c.G_Name WHERE "+
                temp + " BETWEEN g.MinYear AND g.MaxYear GROUP BY g.Name, g.MaxClindren " +
                "HAVING COUNT(*) < g.MaxClindren;";

            // створення об'єкта команди та передача SQL запиту та з'єднання
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            // виконання запиту та отримання результату
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Group.Items.Add(reader.GetString("Name"));
                }
            }

            // закриття з'єднання
            connection.Close();
        }
    }
}