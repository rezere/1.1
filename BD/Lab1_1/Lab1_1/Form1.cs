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
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT Medic (m_code, Surname, Name, Patronymic, Specialty, Category) VALUES ("+ CheckCount()+1 + ", '"+ textBox1.Text + "', '" + 
                                                                                                                        textBox2.Text + "', '" + 
                                                                                                                        textBox3.Text + "', '" + 
                                                                                                                        textBox4.Text + "', '" +
                                                                                                                        textBox5.Text + "')";
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
            cmd.CommandText = "SELECT COUNT(m_code) FROM Medic";
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            count = (int)cmd.ExecuteScalar();
            sqlConnection1.Close();
            return count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.Text.Length < 1)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Medic WHERE m_code = " + Convert.ToInt32(textBox5.Text);
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}
