namespace quanlydiemsinhvien.GUI
{
    partial class Form_dangnhap
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
            this.textBox_tendangnhap = new System.Windows.Forms.TextBox();
            this.textBox_matkhau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_dangnhap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_tendangnhap
            // 
            this.textBox_tendangnhap.Location = new System.Drawing.Point(522, 149);
            this.textBox_tendangnhap.MaxLength = 20;
            this.textBox_tendangnhap.Name = "textBox_tendangnhap";
            this.textBox_tendangnhap.Size = new System.Drawing.Size(187, 20);
            this.textBox_tendangnhap.TabIndex = 4;
            // 
            // textBox_matkhau
            // 
            this.textBox_matkhau.Location = new System.Drawing.Point(522, 188);
            this.textBox_matkhau.MaxLength = 20;
            this.textBox_matkhau.Name = "textBox_matkhau";
            this.textBox_matkhau.PasswordChar = '*';
            this.textBox_matkhau.Size = new System.Drawing.Size(187, 20);
            this.textBox_matkhau.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(519, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mật khẩu";
            // 
            // button_dangnhap
            // 
            this.button_dangnhap.Location = new System.Drawing.Point(522, 214);
            this.button_dangnhap.Name = "button_dangnhap";
            this.button_dangnhap.Size = new System.Drawing.Size(187, 23);
            this.button_dangnhap.TabIndex = 8;
            this.button_dangnhap.Text = "Đăng nhập ";
            this.button_dangnhap.UseVisualStyleBackColor = true;
            this.button_dangnhap.Click += new System.EventHandler(this.button_dangnhap_Click);
            // 
            // Form_dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.button_dangnhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_matkhau);
            this.Controls.Add(this.textBox_tendangnhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_dangnhap";
            this.Text = "Form_dangnhap";
            this.Load += new System.EventHandler(this.Form_dangnhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_tendangnhap;
        private System.Windows.Forms.TextBox textBox_matkhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_dangnhap;
    }
}