using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Lab1_1
{
    public partial class Patient : Form
    {
        SqlConnection sqlConnection1 =
    new SqlConnection("Data Source=DESKTOP-TLF53UJ\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");

        SqlDataAdapter adapter;

        DataTable table;
        public Patient()
        {
            InitializeComponent();
        }

        private void patientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospitalDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTable();

        }
        void LoadTable()
        {
            this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
            sqlConnection1.Open();
            adapter = new SqlDataAdapter("SELECT *FROM Patient", sqlConnection1);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1 
                || textBox2.Text.Length < 1 
                || textBox3.Text.Length < 1
                || textBox4.Text.Length < 1
                || textBox5.Text.Length < 1
                || textBox8.Text.Length < 1)


            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else if(textBox1.Text.Length > 30)
            {
                MessageBox.Show("Фамилия не может превышать 30 символов!");
            }
            else if (textBox2.Text.Length > 30)
            {
                MessageBox.Show("Имя не может превышать 30 символов!");
            }
            else if (textBox3.Text.Length > 30)
            {
                MessageBox.Show("Отчество не может превышать 30 символов!");
            }
            else if (textBox4.Text.Length > 2)
            {
                MessageBox.Show("День не может превышать 2 символа!");
            }
            else if (textBox5.Text.Length > 2)
            {
                MessageBox.Show("Месяц не может превышать 2 символа!");
            }
            else if (textBox8.Text.Length > 4)
            {
                MessageBox.Show("Месяц не может превышать 4 символа!");
            }
            else
            {
                string date = textBox8.Text + "-" + textBox5.Text + "-" + textBox4.Text;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT Patient (p_code, Surname, Name, Patronymic, DateOfBorn) VALUES ("+ CheckCount()+1 + ", '"+ textBox1.Text + "', '" + 
                                                                                                                        textBox2.Text + "', '" + 
                                                                                                                        textBox3.Text + "', CAST('"+ date + "' as datetime))";
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                LoadTable();
            }

        }

        private int CheckCount()
        {
            int count = -1;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT COUNT(p_code) FROM Patient";
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            count = (int)cmd.ExecuteScalar();
            sqlConnection1.Close();
            return count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox6.Text.Length < 1)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            if (Convert.ToInt32(textBox6.Text) > CheckCount() 
                || Convert.ToInt32(textBox6.Text) < 1 
                || CheckCount() == 0)
            {
                MessageBox.Show("Записи с таким номером нет");
            }
            else
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE FROM Patient WHERE p_code = " + Convert.ToInt32(textBox5.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Количество пациентов - " + CheckCount());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length < 1 || textBox9.Text.Length < 1)
            {
                MessageBox.Show("Введите даты для поиска");
            }
            else if(Convert.ToInt32(textBox7.Text) < 1920 
                    || Convert.ToInt32(textBox7.Text) > DateTime.Now.Year
                    || Convert.ToInt32(textBox9.Text) < Convert.ToInt32(textBox7.Text)
                    || Convert.ToInt32(textBox9.Text) > DateTime.Now.Year)
            {
                MessageBox.Show("Введите правильно дату");
            }
            else
            {
                this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
                sqlConnection1.Open();
                string sql = "SELECT *FROM Patient where YEAR(DateOfBorn) BETWEEN " + Convert.ToInt32(textBox7.Text) + " AND " + Convert.ToInt32(textBox9.Text);
                adapter = new SqlDataAdapter(sql, sqlConnection1);
                table = new DataTable();

                adapter.Fill(table);
                dataGridView1.DataSource = table;
                sqlConnection1.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox10.Text.Length < 1)
            {
                MessageBox.Show("Введите Фамилию для поиска");
            }
            else
            {
                this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
                sqlConnection1.Open();
                string sql = "SELECT *FROM Patient where Surname = '" + textBox10.Text + "'";
                adapter = new SqlDataAdapter(sql, sqlConnection1);
                table = new DataTable();

                adapter.Fill(table);
                dataGridView1.DataSource = table;
                sqlConnection1.Close();
            }
        }
        private void Edit()
        {
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT Surname FROM Patient where p_code = " + Convert.ToInt32(textBox11.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            if (cmd.ExecuteScalar() == null)
            {
                sqlConnection1.Close();
                button7.Enabled = false;
                return;
            }
            else
            {
                sqlConnection1.Close();

                this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
                sqlConnection1.Open();
                string sql = "SELECT *FROM Patient where p_code = " + textBox11.Text;
                adapter = new SqlDataAdapter(sql, sqlConnection1);
                table = new DataTable();

                adapter.Fill(table);
                dataGridView1.DataSource = table;
                sqlConnection1.Close();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT Surname FROM Patient where p_code = " + Convert.ToInt32(textBox11.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                textBox1.Text = cmd.ExecuteScalar().ToString();
                sqlConnection1.Close();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT Name FROM Patient where p_code = " + Convert.ToInt32(textBox11.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                textBox2.Text = cmd.ExecuteScalar().ToString();
                sqlConnection1.Close();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT Patronymic FROM Patient where p_code = " + Convert.ToInt32(textBox11.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                textBox3.Text = cmd.ExecuteScalar().ToString();
                sqlConnection1.Close();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT DAY(DateOfBorn) FROM Patient where p_code = " + Convert.ToInt32(textBox11.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                textBox4.Text = cmd.ExecuteScalar().ToString();
                sqlConnection1.Close();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT MONTH(DateOfBorn) FROM Patient where p_code = " + Convert.ToInt32(textBox11.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                textBox5.Text = cmd.ExecuteScalar().ToString();
                sqlConnection1.Close();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT YEAR(DateOfBorn) FROM Patient where p_code = " + Convert.ToInt32(textBox11.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                textBox8.Text = cmd.ExecuteScalar().ToString();
                sqlConnection1.Close();

                button7.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string date = textBox8.Text + "-" + textBox5.Text + "-" + textBox4.Text;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Patient WHERE p_code = " + Convert.ToInt32(textBox11.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT Patient (p_code, Surname, Name, Patronymic, DateOfBorn) VALUES (" + Convert.ToInt32(textBox11.Text) + ", '" + textBox1.Text + "', '" +
                                                                                                                        textBox2.Text + "', '" +
                                                                                                                        textBox3.Text + "', CAST('" + date + "' as datetime))";
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            LoadTable();
            button7.Enabled = false;
        }
    }
}
