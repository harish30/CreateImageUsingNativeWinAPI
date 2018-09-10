namespace TestImageCreation
{
    partial class Form1
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
            if (disposing && ( components != null ))
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
            this.PictureBoxTest = new System.Windows.Forms.PictureBox();
            this.FolderBox = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTest)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxTest
            // 
            this.PictureBoxTest.Location = new System.Drawing.Point(12, 122);
            this.PictureBoxTest.Name = "PictureBoxTest";
            this.PictureBoxTest.Size = new System.Drawing.Size(747, 303);
            this.PictureBoxTest.TabIndex = 1;
            this.PictureBoxTest.TabStop = false;
            // 
            // FolderBox
            // 
            this.FolderBox.Location = new System.Drawing.Point(12, 77);
            this.FolderBox.Name = "FolderBox";
            this.FolderBox.Size = new System.Drawing.Size(623, 20);
            this.FolderBox.TabIndex = 2;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(661, 77);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 3;
            this.Browse.Text = "Browse...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.FolderBox);
            this.Controls.Add(this.PictureBoxTest);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxTest;
        private System.Windows.Forms.TextBox FolderBox;
        private System.Windows.Forms.Button Browse;
    }
}

