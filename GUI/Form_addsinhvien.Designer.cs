namespace quanlydiemsinhvien.GUI
{
    partial class Form_addsinhvien
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox_tensv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_masv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker_ngaysinh = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox_masv);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(6, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(281, 49);
            this.panel5.TabIndex = 10;
            // 
            // textBox_tensv
            // 
            this.textBox_tensv.Location = new System.Drawing.Point(6, 26);
            this.textBox_tensv.Name = "textBox_tensv";
            this.textBox_tensv.Size = new System.Drawing.Size(272, 20);
            this.textBox_tensv.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã sinh viên:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_tensv);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 49);
            this.panel1.TabIndex = 11;
            // 
            // textBox_masv
            // 
            this.textBox_masv.Location = new System.Drawing.Point(6, 24);
            this.textBox_masv.Name = "textBox_masv";
            this.textBox_masv.Size = new System.Drawing.Size(272, 20);
            this.textBox_masv.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ tên:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePicker_ngaysinh);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(6, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 49);
            this.panel2.TabIndex = 12;
            // 
            // dateTimePicker_ngaysinh
            // 
            this.dateTimePicker_ngaysinh.Location = new System.Drawing.Point(6, 25);
            this.dateTimePicker_ngaysinh.Name = "dateTimePicker_ngaysinh";
            this.dateTimePicker_ngaysinh.Size = new System.Drawing.Size(272, 20);
            this.dateTimePicker_ngaysinh.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày sinh:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(281, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 405);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form_addsinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 429);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_addsinhvien";
            this.Text = "Form_addsinhvien";
            this.Load += new System.EventHandler(this.Form_addsinhvien_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox_tensv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_masv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ngaysinh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}