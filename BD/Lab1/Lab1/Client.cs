using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hospitalDataSet1.medic". При необходимости она может быть перемещена или удалена.
            this.medicTableAdapter1.Fill(this.hospitalDataSet1.medic);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.appeal". При необходимости она может быть перемещена или удалена.
            this.appealTableAdapter.Fill(this.dataSet1.appeal);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.dataSet1.client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.medic". При необходимости она может быть перемещена или удалена.
            this.medicTableAdapter.Fill(this.dataSet1.medic);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
