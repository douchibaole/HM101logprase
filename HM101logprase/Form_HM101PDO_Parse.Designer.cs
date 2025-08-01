namespace SteelLogImporter
{
    partial class Form_HM101PDO_Parse
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(382, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "轧钢一线PDO解析程序正在运行！";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 95);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(1151, 379);
            this.richTextBoxLog.TabIndex = 4;
            this.richTextBoxLog.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form_HM101PDO_Parse
            // 
            this.ClientSize = new System.Drawing.Size(1158, 474);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 220);
            this.Name = "Form_HM101PDO_Parse";
            this.Text = "轧钢一线PDO解析工具";
            this.ResumeLayout(false);
            this.PerformLayout();


            this.Load += new System.EventHandler(this.Form1_Load);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

