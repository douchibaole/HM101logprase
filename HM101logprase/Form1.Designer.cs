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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(66, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "轧钢一线PDO解析程序正在运行！";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(517, 162);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "轧钢一线PDO解析工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
    }
}

