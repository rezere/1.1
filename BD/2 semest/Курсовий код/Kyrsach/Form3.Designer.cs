namespace Kyrsach
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindergartenDataSet1 = new Kyrsach.kindergartenDataSet1();
            this.kindergartenDataSet = new Kyrsach.kindergartenDataSet();
            this.kindergartenerTableAdapter = new Kyrsach.kindergartenDataSetTableAdapters.kindergartenerTableAdapter();
            this.kindergartenerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupTableAdapter = new Kyrsach.kindergartenDataSet1TableAdapters.groupTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.EditButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Edu = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Rozklad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxAge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MinAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SearchName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.ZapMax = new System.Windows.Forms.TextBox();
            this.ZapMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(772, 390);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataMember = "group";
            this.groupBindingSource.DataSource = this.kindergartenDataSet1;
            // 
            // kindergartenDataSet1
            // 
            this.kindergartenDataSet1.DataSetName = "kindergartenDataSet1";
            this.kindergartenDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // kindergartenerBindingSource
            // 
            this.kindergartenerBindingSource.DataMember = "kindergartener";
            this.kindergartenerBindingSource.DataSource = this.kindergartenDataSet;
            // 
            // groupTableAdapter
            // 
            this.groupTableAdapter.ClearBeforeFill = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(790, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 390);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.EditButton);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Edu);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.Rozklad);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.MaxAge);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.MinAge);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.MaxCount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.NameBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Додавання";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditButton.Location = new System.Drawing.Point(23, 216);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(166, 58);
            this.EditButton.TabIndex = 13;
            this.EditButton.Text = "Редагувати";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Visible = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(232, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 58);
            this.button1.TabIndex = 12;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Edu
            // 
            this.Edu.FormattingEnabled = true;
            this.Edu.Items.AddRange(new object[] {
            "Денна",
            "Вечірня"});
            this.Edu.Location = new System.Drawing.Point(107, 160);
            this.Edu.Name = "Edu";
            this.Edu.Size = new System.Drawing.Size(155, 21);
            this.Edu.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Вихователь";
            // 
            // Rozklad
            // 
            this.Rozklad.FormattingEnabled = true;
            this.Rozklad.Items.AddRange(new object[] {
            "Денна",
            "Вечірня"});
            this.Rozklad.Location = new System.Drawing.Point(107, 125);
            this.Rozklad.Name = "Rozklad";
            this.Rozklad.Size = new System.Drawing.Size(155, 21);
            this.Rozklad.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Розклад";
            // 
            // MaxAge
            // 
            this.MaxAge.Location = new System.Drawing.Point(232, 90);
            this.MaxAge.Name = "MaxAge";
            this.MaxAge.Size = new System.Drawing.Size(30, 20);
            this.MaxAge.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Макс вік";
            // 
            // MinAge
            // 
            this.MinAge.Location = new System.Drawing.Point(107, 90);
            this.MinAge.Name = "MinAge";
            this.MinAge.Size = new System.Drawing.Size(30, 20);
            this.MinAge.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Мін вік";
            // 
            // MaxCount
            // 
            this.MaxCount.Location = new System.Drawing.Point(107, 55);
            this.MaxCount.Name = "MaxCount";
            this.MaxCount.Size = new System.Drawing.Size(155, 20);
            this.MaxCount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Кількість";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(107, 19);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(155, 20);
            this.NameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.edit);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(377, 364);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Редагування";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(215, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(134, 42);
            this.button5.TabIndex = 2;
            this.button5.Text = "Редагувати";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(98, 13);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(111, 20);
            this.edit.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Назва групи";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.Delete);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(377, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Видалення";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.button4.Location = new System.Drawing.Point(226, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 41);
            this.button4.TabIndex = 2;
            this.button4.Text = "Видалити";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(100, 15);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(120, 20);
            this.Delete.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Назва групи";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.SearchName);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.ZapMax);
            this.tabPage3.Controls.Add(this.ZapMin);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(377, 364);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Запит";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(208, 227);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(101, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(185, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Назва групи для інф-ції про батьків";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(208, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Назва групи для інформації про дітей";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(234, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(108, 58);
            this.button7.TabIndex = 8;
            this.button7.Text = "Всього груп та дітей";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(120, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 58);
            this.button6.TabIndex = 7;
            this.button6.Text = "К-ть дітей в кожній змінні";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // SearchName
            // 
            this.SearchName.Location = new System.Drawing.Point(85, 156);
            this.SearchName.Name = "SearchName";
            this.SearchName.Size = new System.Drawing.Size(101, 20);
            this.SearchName.TabIndex = 6;
            this.SearchName.TextChanged += new System.EventHandler(this.SearchName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Назва групи";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(120, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 58);
            this.button3.TabIndex = 4;
            this.button3.Text = "Групи цього віку";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ZapMax
            // 
            this.ZapMax.Location = new System.Drawing.Point(85, 72);
            this.ZapMax.Name = "ZapMax";
            this.ZapMax.Size = new System.Drawing.Size(29, 20);
            this.ZapMax.TabIndex = 3;
            // 
            // ZapMin
            // 
            this.ZapMin.Location = new System.Drawing.Point(34, 72);
            this.ZapMin.Name = "ZapMin";
            this.ZapMin.Size = new System.Drawing.Size(29, 20);
            this.ZapMin.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Вік";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 52);
            this.button2.TabIndex = 0;
            this.button2.Text = "Всі записи";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1187, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Групи";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private kindergartenDataSet kindergartenDataSet;
        private kindergartenDataSetTableAdapters.kindergartenerTableAdapter kindergartenerTableAdapter;
        private System.Windows.Forms.BindingSource kindergartenerBindingSource;
        private kindergartenDataSet1 kindergartenDataSet1;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private kindergartenDataSet1TableAdapters.groupTableAdapter groupTableAdapter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox MaxCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MinAge;
        private System.Windows.Forms.TextBox MaxAge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Rozklad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Edu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ZapMax;
        private System.Windows.Forms.TextBox ZapMin;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SearchName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Delete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox edit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
    }
}