namespace Lab_2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureEmblem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmblem)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEmblem
            // 
            this.pictureEmblem.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureEmblem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEmblem.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureEmblem.ErrorImage")));
            this.pictureEmblem.Image = ((System.Drawing.Image)(resources.GetObject("pictureEmblem.Image")));
            this.pictureEmblem.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureEmblem.InitialImage")));
            this.pictureEmblem.Location = new System.Drawing.Point(0, 0);
            this.pictureEmblem.Name = "pictureEmblem";
            this.pictureEmblem.Size = new System.Drawing.Size(1398, 677);
            this.pictureEmblem.TabIndex = 0;
            this.pictureEmblem.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1398, 677);
            this.Controls.Add(this.pictureEmblem);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmblem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public PictureBox pictureEmblem;
    }
}