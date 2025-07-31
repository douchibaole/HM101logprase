namespace SteelLogImporter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(350, 25);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(368, 10);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(93, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "浏览...";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 39);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(98, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "解析PDO";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(473, 84);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnImport);
            this.Name = "Form1";
            this.Text = "轧钢一线PDO解析工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnImport;
    }
}

