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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection1 =
    new SqlConnection("Data Source=DESKTOP-TLF53UJ\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");

        SqlDataAdapter adapter;

        DataTable table;
        public Form1()
        {
            InitializeComponent();
            Patient newForm = new Patient();
            newForm.Show();
            Appeal Form = new Appeal();
            Form.Show();
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
            adapter = new SqlDataAdapter("SELECT *FROM Medic", sqlConnection1);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 
                || textBox3.Text.Length < 1
                || textBox4.Text.Length < 1
                || textBox5.Text.Length < 1)
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
            else if (textBox4.Text.Length > 20)
            {
                MessageBox.Show("Специальность не может превышать 20 символов!");
            }
            else if (textBox5.Text.Length > 20)
            {
                MessageBox.Show("Категория не может превышать 20 символов!");
            }
            else
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                int count = CheckCount() + 1;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT Medic (m_code, Surname, Name, Patronymic, Specialty, Category) VALUES ("+ count + ", '"+ textBox1.Text + "', '" + 
                                                                                                                        textBox2.Text + "', '" + 
                                                                                                                        textBox3.Text + "', '" + 
                                                                                                                        textBox4.Text + "', '" +
                                                                                                                        textBox5.Text + "')";
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
            cmd.CommandText = "SELECT COUNT(m_code) FROM Medic";
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
            if (check())
            {
                
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE FROM Appeal WHERE m_code = " + Convert.ToInt32(textBox6.Text);
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
            }

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Medic WHERE m_code = " + Convert.ToInt32(textBox6.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();

            Clear();
            LoadTable();
        }

        private bool check()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT Surname FROM Medic WHERE m_code = " + Convert.ToInt32(textBox6.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            string str = cmd.ExecuteScalar().ToString();
            sqlConnection1.Close();
            if (str != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Количество врачей - " + CheckCount());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length < 1)
            {
                MessageBox.Show("Введите специальность для поиска");
            }
            else
            {
                this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
                sqlConnection1.Open();
                string sql = "SELECT *FROM Medic where Specialty = '" + textBox7.Text + "'" ;
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
                cmd.CommandText = "SELECT Surname FROM Medic where m_code = " + Convert.ToInt32(textBox8.Text);
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
                    string sql = "SELECT *FROM Medic where m_code = " + textBox8.Text;
                    adapter = new SqlDataAdapter(sql, sqlConnection1);
                    table = new DataTable();

                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT Surname FROM Medic where m_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox1.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT Name FROM Medic where m_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox2.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT Patronymic FROM Medic where m_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox3.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT Specialty FROM Medic where m_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox4.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT Category FROM Medic where m_code = " + Convert.ToInt32(textBox8.Text);
                    cmd.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    textBox5.Text = cmd.ExecuteScalar().ToString();
                    sqlConnection1.Close();


                    button6.Enabled = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Medic WHERE m_code = " + Convert.ToInt32(textBox8.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT Medic (m_code, Surname, Name, Patronymic, Specialty, Category) VALUES (" + Convert.ToInt32(textBox8.Text) + ", '" + textBox1.Text + "', '" +
                                                                                                                                    textBox2.Text + "', '" +
                                                                                                                                    textBox3.Text + "', '" +
                                                                                                                                    textBox4.Text + "', '" +
                                                                                                                                    textBox5.Text + "')";
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
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
            sqlConnection1.Open();
            string sql = "SELECT count(*) as 'Количество', Specialty as 'Специальность' from Medic group by Specialty";
            adapter = new SqlDataAdapter(sql, sqlConnection1);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
            sqlConnection1.Open();
            string sql = "SELECT sum(Appeal.Cost), Medic.Surname, Medic.Name, Medic.Patronymic from Appeal, Medic where " +
                "Medic.m_code = Appeal.m_code and Medic.m_code = (select Medic.m_code from Medic where Medic.Surname = '"+ textBox9.Text + "') group by Medic.Surname, Medic.Name, Medic.Patronymic";
            adapter = new SqlDataAdapter(sql, sqlConnection1);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
            sqlConnection1.Open();
            string sql = "SELECT  Medic.Surname, Medic.Name, Medic.Patronymic, count(Patient.p_code) as 'Всего больных' from Medic, Appeal, Patient " +
                "where Medic.m_code = Appeal.m_code and Patient.p_code = Appeal.p_code GROUP BY Medic.Surname, Medic.Name, Medic.Patronymic";
            adapter = new SqlDataAdapter(sql, sqlConnection1);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
            sqlConnection1.Open();
            string sql = "SELECT  Medic.Surname, Medic.Name, Medic.Patronymic, count(Patient.p_code) as 'Всего больных' from Medic, Appeal, Patient " +
                "where Medic.m_code = Appeal.m_code and Patient.p_code = Appeal.p_code GROUP BY Medic.Surname, Medic.Name, Medic.Patronymic";
            adapter = new SqlDataAdapter(sql, sqlConnection1);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.patientTableAdapter.Fill(this.hospitalDataSet.Patient);
            sqlConnection1.Open();
            string sql = "SELECT  Medic.Surname, Medic.Name, Medic.Patronymic, sum(Appeal.Cost) as 'Заработано' from Appeal, Medic " +
                "where Medic.m_code = Appeal.m_code group by Medic.Surname, Medic.Name, Medic.Patronymic having sum(Appeal.Cost) > 2000";
            adapter = new SqlDataAdapter(sql, sqlConnection1);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
        }
    }
}
