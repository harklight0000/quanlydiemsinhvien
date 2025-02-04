namespace quanlydiemsinhvien.GUI
{
    partial class Form_chuongtrinhdaotao
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_addkhoa = new System.Windows.Forms.Button();
            this.dataGridView_khoa = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_addmon = new System.Windows.Forms.Button();
            this.dataGridView_mon = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_addnganh = new System.Windows.Forms.Button();
            this.dataGridView_nganh = new System.Windows.Forms.DataGridView();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_khoa)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mon)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_nganh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_addkhoa);
            this.groupBox4.Controls.Add(this.dataGridView_khoa);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(308, 604);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // button_addkhoa
            // 
            this.button_addkhoa.Location = new System.Drawing.Point(205, 575);
            this.button_addkhoa.Name = "button_addkhoa";
            this.button_addkhoa.Size = new System.Drawing.Size(97, 23);
            this.button_addkhoa.TabIndex = 1;
            this.button_addkhoa.Text = "Thêm khóa";
            this.button_addkhoa.UseVisualStyleBackColor = true;
            this.button_addkhoa.Click += new System.EventHandler(this.button_addkhoa_Click);
            // 
            // dataGridView_khoa
            // 
            this.dataGridView_khoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_khoa.Location = new System.Drawing.Point(7, 17);
            this.dataGridView_khoa.Name = "dataGridView_khoa";
            this.dataGridView_khoa.Size = new System.Drawing.Size(295, 552);
            this.dataGridView_khoa.TabIndex = 0;
            this.dataGridView_khoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_khoa_CellClick);
            this.dataGridView_khoa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_khoa_CellDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_addmon);
            this.groupBox3.Controls.Add(this.dataGridView_mon);
            this.groupBox3.Location = new System.Drawing.Point(621, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(551, 604);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // button_addmon
            // 
            this.button_addmon.Location = new System.Drawing.Point(457, 575);
            this.button_addmon.Name = "button_addmon";
            this.button_addmon.Size = new System.Drawing.Size(88, 23);
            this.button_addmon.TabIndex = 2;
            this.button_addmon.Text = "Thêm môn học";
            this.button_addmon.UseVisualStyleBackColor = true;
            this.button_addmon.Click += new System.EventHandler(this.button_addmon_Click);
            // 
            // dataGridView_mon
            // 
            this.dataGridView_mon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_mon.Location = new System.Drawing.Point(6, 17);
            this.dataGridView_mon.Name = "dataGridView_mon";
            this.dataGridView_mon.Size = new System.Drawing.Size(539, 552);
            this.dataGridView_mon.TabIndex = 1;
            this.dataGridView_mon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_mon_CellClick);
            this.dataGridView_mon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_mon_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_addnganh);
            this.groupBox2.Controls.Add(this.dataGridView_nganh);
            this.groupBox2.Location = new System.Drawing.Point(326, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 604);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button_addnganh
            // 
            this.button_addnganh.Location = new System.Drawing.Point(186, 575);
            this.button_addnganh.Name = "button_addnganh";
            this.button_addnganh.Size = new System.Drawing.Size(97, 23);
            this.button_addnganh.TabIndex = 1;
            this.button_addnganh.Text = "Thêm ngành học";
            this.button_addnganh.UseVisualStyleBackColor = true;
            this.button_addnganh.Click += new System.EventHandler(this.button_addnganh_Click);
            // 
            // dataGridView_nganh
            // 
            this.dataGridView_nganh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_nganh.Location = new System.Drawing.Point(7, 17);
            this.dataGridView_nganh.Name = "dataGridView_nganh";
            this.dataGridView_nganh.Size = new System.Drawing.Size(276, 552);
            this.dataGridView_nganh.TabIndex = 0;
            this.dataGridView_nganh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_nganh_CellClick);
            this.dataGridView_nganh.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_nganh_CellDoubleClick);
            // 
            // Form_chuongtrinhdaotao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 628);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_chuongtrinhdaotao";
            this.Load += new System.EventHandler(this.ctdt_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_khoa)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_nganh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_mon;
        private System.Windows.Forms.DataGridView dataGridView_nganh;
        private System.Windows.Forms.Button button_addmon;
        private System.Windows.Forms.Button button_addnganh;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_addkhoa;
        private System.Windows.Forms.DataGridView dataGridView_khoa;
    }
}