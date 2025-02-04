namespace quanlydiemsinhvien.GUI
{
    partial class Form_danhsachsinhvien
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_addlop = new System.Windows.Forms.Button();
            this.dataGridView_lop = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_addsinhvien = new System.Windows.Forms.Button();
            this.dataGridView_sinhvien = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lop)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sinhvien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_addlop);
            this.groupBox2.Controls.Add(this.dataGridView_lop);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 604);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox1";
            // 
            // button_addlop
            // 
            this.button_addlop.Location = new System.Drawing.Point(486, 575);
            this.button_addlop.Name = "button_addlop";
            this.button_addlop.Size = new System.Drawing.Size(81, 23);
            this.button_addlop.TabIndex = 2;
            this.button_addlop.Text = "Thêm lớp mới";
            this.button_addlop.UseVisualStyleBackColor = true;
            this.button_addlop.Click += new System.EventHandler(this.button_addlop_Click);
            // 
            // dataGridView_lop
            // 
            this.dataGridView_lop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_lop.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_lop.Name = "dataGridView_lop";
            this.dataGridView_lop.Size = new System.Drawing.Size(561, 550);
            this.dataGridView_lop.TabIndex = 0;
            this.dataGridView_lop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_lop_CellClick);
            this.dataGridView_lop.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_lop_CellDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_addsinhvien);
            this.groupBox3.Controls.Add(this.dataGridView_sinhvien);
            this.groupBox3.Location = new System.Drawing.Point(591, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 604);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // button_addsinhvien
            // 
            this.button_addsinhvien.Location = new System.Drawing.Point(485, 575);
            this.button_addsinhvien.Name = "button_addsinhvien";
            this.button_addsinhvien.Size = new System.Drawing.Size(90, 23);
            this.button_addsinhvien.TabIndex = 15;
            this.button_addsinhvien.Text = "Thêm sinh viên";
            this.button_addsinhvien.UseVisualStyleBackColor = true;
            this.button_addsinhvien.Click += new System.EventHandler(this.button_addsinhvien_Click);
            // 
            // dataGridView_sinhvien
            // 
            this.dataGridView_sinhvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sinhvien.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_sinhvien.Name = "dataGridView_sinhvien";
            this.dataGridView_sinhvien.Size = new System.Drawing.Size(569, 550);
            this.dataGridView_sinhvien.TabIndex = 0;
            this.dataGridView_sinhvien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_sinhvien_CellClick);
            this.dataGridView_sinhvien.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_sinhvien_CellDoubleClick);
            // 
            // Form_danhsachsinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 628);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_danhsachsinhvien";
            this.Text = "Form_danhsachsinhvien";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_lop)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sinhvien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_lop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_addsinhvien;
        private System.Windows.Forms.DataGridView dataGridView_sinhvien;
        private System.Windows.Forms.Button button_addlop;
    }
}