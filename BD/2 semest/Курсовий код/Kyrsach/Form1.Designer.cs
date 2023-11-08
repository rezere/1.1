namespace Kyrsach
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.kindergartenDataSet = new Kyrsach.kindergartenDataSet();
            this.kindergartenerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindergartenerTableAdapter = new Kyrsach.kindergartenDataSetTableAdapters.kindergartenerTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.GroupButton = new System.Windows.Forms.Button();
            this.TeachersButton = new System.Windows.Forms.Button();
            this.childrenButton = new System.Windows.Forms.Button();
            this.parentButton = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.kindergartenDataSet;
            this.bindingSource1.Position = 0;
            // 
            // kindergartenDataSet
            // 
            this.kindergartenDataSet.DataSetName = "kindergartenDataSet";
            this.kindergartenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kindergartenerBindingSource
            // 
            this.kindergartenerBindingSource.DataMember = "kindergartener";
            this.kindergartenerBindingSource.DataSource = this.bindingSource1;
            // 
            // kindergartenerTableAdapter
            // 
            this.kindergartenerTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизація";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(100, 96);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(71, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 65);
            this.button1.TabIndex = 3;
            this.button1.Text = "Авторизація";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GroupButton
            // 
            this.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupButton.Location = new System.Drawing.Point(12, 273);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.Size = new System.Drawing.Size(102, 31);
            this.GroupButton.TabIndex = 4;
            this.GroupButton.Text = "Групи";
            this.GroupButton.UseVisualStyleBackColor = true;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // TeachersButton
            // 
            this.TeachersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeachersButton.Location = new System.Drawing.Point(154, 273);
            this.TeachersButton.Name = "TeachersButton";
            this.TeachersButton.Size = new System.Drawing.Size(102, 31);
            this.TeachersButton.TabIndex = 5;
            this.TeachersButton.Text = "Вихователі";
            this.TeachersButton.UseVisualStyleBackColor = true;
            this.TeachersButton.Click += new System.EventHandler(this.TeachersButton_Click);
            // 
            // childrenButton
            // 
            this.childrenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.childrenButton.Location = new System.Drawing.Point(12, 322);
            this.childrenButton.Name = "childrenButton";
            this.childrenButton.Size = new System.Drawing.Size(102, 31);
            this.childrenButton.TabIndex = 6;
            this.childrenButton.Text = "Діти";
            this.childrenButton.UseVisualStyleBackColor = true;
            this.childrenButton.Click += new System.EventHandler(this.childrenButton_Click);
            // 
            // parentButton
            // 
            this.parentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parentButton.Location = new System.Drawing.Point(154, 322);
            this.parentButton.Name = "parentButton";
            this.parentButton.Size = new System.Drawing.Size(102, 31);
            this.parentButton.TabIndex = 7;
            this.parentButton.Text = "Батьки";
            this.parentButton.UseVisualStyleBackColor = true;
            this.parentButton.Click += new System.EventHandler(this.parentButton_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Location = new System.Drawing.Point(3, 412);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(111, 43);
            this.Save.TabIndex = 8;
            this.Save.Text = "Збереження БД";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Visible = false;
            this.Save.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadButton.Location = new System.Drawing.Point(154, 412);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(114, 43);
            this.LoadButton.TabIndex = 9;
            this.LoadButton.Text = "Завантаження БД";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Visible = false;
            this.LoadButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(268, 467);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.parentButton);
            this.Controls.Add(this.childrenButton);
            this.Controls.Add(this.TeachersButton);
            this.Controls.Add(this.GroupButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Авторизація";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergartenerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private kindergartenDataSet kindergartenDataSet;
        private System.Windows.Forms.BindingSource kindergartenerBindingSource;
        private kindergartenDataSetTableAdapters.kindergartenerTableAdapter kindergartenerTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button TeachersButton;
        private System.Windows.Forms.Button childrenButton;
        private System.Windows.Forms.Button parentButton;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button LoadButton;
    }
}

