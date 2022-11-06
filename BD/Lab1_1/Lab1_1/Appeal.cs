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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Lab1_1
{
    public partial class Appeal : Form
    {
        SqlConnection sqlConnection1 =
    new SqlConnection("Data Source=DESKTOP-TLF53UJ\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");

        SqlDataAdapter adapter;

        DataTable table;
        public Appeal()
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
            adapter = new SqlDataAdapter("SELECT *FROM Appeal", sqlConnection1);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 
                || textBox3.Text.Length < 1
                || textBox4.Text.Length < 1)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else if (textBox3.Text.Length > 50)
            {
                MessageBox.Show("Диагноз не может превышать 50 символов!");
            }
            else
            {
                string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT Appeal (a_code, m_code, p_code, DateOfApp, Diagnosis, Cost) VALUES (" + CheckCount() + 1 + ", " + textBox1.Text + ", " +
                                                                                                                        textBox2.Text + ", CAST('" + date + "' as datetime),'"
                                                                                                                        + textBox3.Text + "', " + float.Parse(textBox3.Text) + ")";
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                LoadTable();
                Clear();
            }

        }

        private int CheckCount()
        {
            int count = -1;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT COUNT(a_code) FROM Appeal";
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
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Appeal WHERE a_code = " + Convert.ToInt32(textBox6.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Количество записей - " + CheckCount());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length < 1)
            {
                MessageBox.Show("Введите год для поиска");
            }
            else if (Convert.ToInt32(textBox7.Text) < 1930 || Convert.ToInt32(textBox7.Text)>DateTime.Now.Year)
            {
                MessageBox.Show("Не верный год");
            }
            else
            {
                this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
                sqlConnection1.Open();
                string sql = "SELECT count(*) as 'Количество', MONTH(DateOfApp) as 'месяц' from Appeal where year(DateOfApp) = " + Convert.ToInt32(textBox7.Text)  + " group by month(DateOfApp)";
                adapter = new SqlDataAdapter(sql, sqlConnection1);
                table = new DataTable();

                adapter.Fill(table);
                dataGridView1.DataSource = table;
                sqlConnection1.Close();
            }
            Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length > 0)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT m_code FROM Appeal where a_code = " + Convert.ToInt32(textBox8.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    sqlConnection1.Close();
                    button6.Enabled = false;
                    return;
                }
                else
                {
                    sqlConnection1.Close();

                    this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
                    sqlConnection1.Open();
                    string sql = "SELECT *FROM Appeal where a_code = " + textBox8.Text;
                    adapter = new SqlDataAdapter(sql, sqlConnection1);
                    table = new DataTable();

                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT m_code FROM Appeal where a_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox1.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT p_code FROM Appeal where a_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox2.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT Diagnosis FROM Appeal where a_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox3.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT Cost FROM Appeal where a_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox4.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();

                    button6.Enabled = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string date;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT YEAR(DateOfApp) FROM Appeal where a_code = " + Convert.ToInt32(textBox8.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            date = cmd.ExecuteScalar().ToString() + "-";
            sqlConnection1.Close();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT MONTH(DateOfApp) FROM Appeal where a_code = " + Convert.ToInt32(textBox8.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            date += cmd.ExecuteScalar().ToString() + "-";
            sqlConnection1.Close();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT DAY(DateOfApp) FROM Appeal where a_code = " + Convert.ToInt32(textBox8.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            date += cmd.ExecuteScalar().ToString();
            sqlConnection1.Close();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Appeal WHERE a_code = " + Convert.ToInt32(textBox8.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT Appeal (a_code, m_code, p_code, DateOfApp, Diagnosis, Cost) VALUES (" + CheckCount() + 1 + ", '" + textBox1.Text + "', '" +
                                                                                                                        textBox2.Text + "', CAST('" + date + "' as datetime),'"
                                                                                                                        + textBox3.Text + "', '" + float.Parse(textBox3.Text) + "')";
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            LoadTable();
            button6.Enabled = false;
            Clear();
        }
       void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            //textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }
    }
}
