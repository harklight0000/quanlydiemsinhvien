namespace quanlydiemsinhvien.GUI
{
    partial class Form_addlop
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox_ten = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox_khoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_nganh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox_ten);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(6, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(289, 49);
            this.panel5.TabIndex = 9;
            // 
            // textBox_ten
            // 
            this.textBox_ten.Location = new System.Drawing.Point(6, 24);
            this.textBox_ten.Name = "textBox_ten";
            this.textBox_ten.Size = new System.Drawing.Size(272, 20);
            this.textBox_ten.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox_khoa);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(6, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 49);
            this.panel3.TabIndex = 11;
            // 
            // comboBox_khoa
            // 
            this.comboBox_khoa.FormattingEnabled = true;
            this.comboBox_khoa.Location = new System.Drawing.Point(6, 24);
            this.comboBox_khoa.Name = "comboBox_khoa";
            this.comboBox_khoa.Size = new System.Drawing.Size(272, 21);
            this.comboBox_khoa.TabIndex = 2;
            this.comboBox_khoa.SelectionChangeCommitted += new System.EventHandler(this.comboBox_khoa_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khóa:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox_nganh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 49);
            this.panel1.TabIndex = 12;
            // 
            // comboBox_nganh
            // 
            this.comboBox_nganh.FormattingEnabled = true;
            this.comboBox_nganh.Location = new System.Drawing.Point(6, 24);
            this.comboBox_nganh.Name = "comboBox_nganh";
            this.comboBox_nganh.Size = new System.Drawing.Size(272, 21);
            this.comboBox_nganh.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngành:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 405);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm lớp mới";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(294, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_addlop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 429);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_addlop";
            this.Text = "Form_lopA";
            this.Load += new System.EventHandler(this.Form_lopA_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox_ten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox_khoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox_nganh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}