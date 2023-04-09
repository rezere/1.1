namespace Kyrsach
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bornDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kindergartenerBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.kindergartenerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindergartenDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindergartenDataSet = new Kyrsach.kindergartenDataSet();
            this.kindergartenerTableAdapter = new Kyrsach.kindergartenDataSetTableAdapters.kindergartenerTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Add = new System.Windows.Forms.Button();
            this.Number = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Adress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Year = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Month = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Day = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SecondName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Surname = new System.Windows.Forms.TextBox();
            this.SurnameText = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.SurnameSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.kindergartenerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.surnameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.sNameDataGridViewTextBoxColumn,
            this.bornDataGridViewTextBoxColumn,
            this.adressDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.workDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.kindergartenerBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(794, 381);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // surnameDataGridViewTextBoxColumn
            // 
            this.surnameDataGridViewTextBoxColumn.DataPropertyName = "Surname";
            this.surnameDataGridViewTextBoxColumn.HeaderText = "Surname";
            this.surnameDataGridViewTextBoxColumn.Name = "surnameDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // sNameDataGridViewTextBoxColumn
            // 
            this.sNameDataGridViewTextBoxColumn.DataPropertyName = "SName";
            this.sNameDataGridViewTextBoxColumn.HeaderText = "SName";
            this.sNameDataGridViewTextBoxColumn.Name = "sNameDataGridViewTextBoxColumn";
            // 
            // bornDataGridViewTextBoxColumn
            // 
            this.bornDataGridViewTextBoxColumn.DataPropertyName = "Born";
            this.bornDataGridViewTextBoxColumn.HeaderText = "Born";
            this.bornDataGridViewTextBoxColumn.Name = "bornDataGridViewTextBoxColumn";
            // 
            // adressDataGridViewTextBoxColumn
            // 
            this.adressDataGridViewTextBoxColumn.DataPropertyName = "Adress";
            this.adressDataGridViewTextBoxColumn.HeaderText = "Adress";
            this.adressDataGridViewTextBoxColumn.Name = "adressDataGridViewTextBoxColumn";
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            // 
            // workDataGridViewTextBoxColumn
            // 
            this.workDataGridViewTextBoxColumn.DataPropertyName = "Work";
            this.workDataGridViewTextBoxColumn.HeaderText = "Work";
            this.workDataGridViewTextBoxColumn.Name = "workDataGridViewTextBoxColumn";
            // 
            // kindergartenerBindingSource2
            // 
            this.kindergartenerBindingSource2.DataMember = "kindergartener";
            this.kindergartenerBindingSource2.DataSource = this.kindergartenerBindingSource;
            // 
            // kindergartenerBindingSource
            // 
            this.kindergartenerBindingSource.DataSource = this.kindergartenDataSetBindingSource;
            this.kindergartenerBindingSource.Position = 0;
            // 
            // kindergartenDataSetBindingSource
            // 
            this.kindergartenDataSetBindingSource.DataSource = this.kindergartenDataSet;
            this.kindergartenDataSetBindingSource.Position = 0;
            // 
            // kindergartenDataSet
            // 
            this.kindergartenDataSet.DataSetName = "kindergartenDataSet";
            this.kindergartenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kindergartenerTableAdapter
            // 
            this.kindergartenerTableAdapter.ClearBeforeFill = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(834, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(341, 381);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Add);
            this.tabPage1.Controls.Add(this.Number);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.Adress);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.Year);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.Month);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.Day);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.SecondName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.FirstName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Surname);
            this.tabPage1.Controls.Add(this.SurnameText);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(333, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add.Location = new System.Drawing.Point(209, 264);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(118, 58);
            this.Add.TabIndex = 16;
            this.Add.Text = "Додати";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(84, 222);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(188, 20);
            this.Number.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Телефон";
            // 
            // Adress
            // 
            this.Adress.Location = new System.Drawing.Point(84, 192);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(188, 20);
            this.Adress.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Адреса";
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(46, 159);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(37, 20);
            this.Year.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Рік";
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
            this.Month.Location = new System.Drawing.Point(146, 122);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(121, 21);
            this.Month.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Місяць";
            // 
            // Day
            // 
            this.Day.Location = new System.Drawing.Point(46, 123);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(37, 20);
            this.Day.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "День";
            // 
            // SecondName
            // 
            this.SecondName.Location = new System.Drawing.Point(84, 84);
            this.SecondName.Name = "SecondName";
            this.SecondName.Size = new System.Drawing.Size(188, 20);
            this.SecondName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "По батькові";
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(84, 50);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(188, 20);
            this.FirstName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ім\'я";
            // 
            // Surname
            // 
            this.Surname.Location = new System.Drawing.Point(84, 20);
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(188, 20);
            this.Surname.TabIndex = 1;
            // 
            // SurnameText
            // 
            this.SurnameText.AutoSize = true;
            this.SurnameText.Location = new System.Drawing.Point(6, 23);
            this.SurnameText.Name = "SurnameText";
            this.SurnameText.Size = new System.Drawing.Size(56, 13);
            this.SurnameText.TabIndex = 0;
            this.SurnameText.Text = "Прізвище";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(333, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.SurnameSearch);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(333, 355);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SurnameSearch
            // 
            this.SurnameSearch.Location = new System.Drawing.Point(78, 89);
            this.SurnameSearch.Name = "SurnameSearch";
            this.SurnameSearch.Size = new System.Drawing.Size(146, 20);
            this.SurnameSearch.TabIndex = 3;
            this.SurnameSearch.TextChanged += new System.EventHandler(this.SurnameSearch_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Прізвище";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(177, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 61);
            this.button2.TabIndex = 1;
            this.button2.Text = "Загальна кількість вихователів";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Виведення всіх вихователів";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kindergartenerBindingSource1
            // 
            this.kindergartenerBindingSource1.DataMember = "kindergartener";
            this.kindergartenerBindingSource1.DataSource = this.kindergartenerBindingSource;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(6, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 61);
            this.button3.TabIndex = 4;
            this.button3.Text = "Предпенсійний вік";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Вихователі";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource kindergartenDataSetBindingSource;
        private kindergartenDataSet kindergartenDataSet;
        private System.Windows.Forms.BindingSource kindergartenerBindingSource;
        private kindergartenDataSetTableAdapters.kindergartenerTableAdapter kindergartenerTableAdapter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label SurnameText;
        private System.Windows.Forms.TextBox Surname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox SecondName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Month;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Day;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Year;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Adress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Number;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bornDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource kindergartenerBindingSource2;
        private System.Windows.Forms.BindingSource kindergartenerBindingSource1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SurnameSearch;
        private System.Windows.Forms.Button button3;
    }
}