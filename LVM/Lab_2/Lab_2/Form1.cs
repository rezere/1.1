namespace Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Regist mainForm = new Regist();
            mainForm.Show();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}