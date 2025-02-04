namespace quanlydiemsinhvien.GUI
{
    partial class Form_ketquahoctap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ketquahoctap));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_ketqua = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2_addthi2 = new System.Windows.Forms.Button();
            this.button_filterThi = new System.Windows.Forms.Button();
            this.dataGridView_thi = new System.Windows.Forms.DataGridView();
            this.button_addthi1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ketqua)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_thi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_ketqua);
            this.groupBox3.Location = new System.Drawing.Point(568, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 604);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // dataGridView_ketqua
            // 
            this.dataGridView_ketqua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ketqua.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_ketqua.Name = "dataGridView_ketqua";
            this.dataGridView_ketqua.Size = new System.Drawing.Size(592, 550);
            this.dataGridView_ketqua.TabIndex = 0;
            this.dataGridView_ketqua.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ketqua_CellEndEdit);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2_addthi2);
            this.groupBox2.Controls.Add(this.button_filterThi);
            this.groupBox2.Controls.Add(this.dataGridView_thi);
            this.groupBox2.Controls.Add(this.button_addthi1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 604);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button2_addthi2
            // 
            this.button2_addthi2.Location = new System.Drawing.Point(336, 575);
            this.button2_addthi2.Name = "button2_addthi2";
            this.button2_addthi2.Size = new System.Drawing.Size(97, 23);
            this.button2_addthi2.TabIndex = 3;
            this.button2_addthi2.Text = "Tạo bài thi lần 2 ";
            this.button2_addthi2.UseVisualStyleBackColor = true;
            this.button2_addthi2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_filterThi
            // 
            this.button_filterThi.Location = new System.Drawing.Point(7, 575);
            this.button_filterThi.Name = "button_filterThi";
            this.button_filterThi.Size = new System.Drawing.Size(55, 23);
            this.button_filterThi.TabIndex = 2;
            this.button_filterThi.Text = "Lọc";
            this.button_filterThi.UseVisualStyleBackColor = true;
            // 
            // dataGridView_thi
            // 
            this.dataGridView_thi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_thi.Location = new System.Drawing.Point(7, 19);
            this.dataGridView_thi.Name = "dataGridView_thi";
            this.dataGridView_thi.Size = new System.Drawing.Size(537, 550);
            this.dataGridView_thi.TabIndex = 0;
            this.dataGridView_thi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_thi_CellClick);
            this.dataGridView_thi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_thi_CellDoubleClick);
            // 
            // button_addthi1
            // 
            this.button_addthi1.Location = new System.Drawing.Point(439, 575);
            this.button_addthi1.Name = "button_addthi1";
            this.button_addthi1.Size = new System.Drawing.Size(105, 23);
            this.button_addthi1.TabIndex = 1;
            this.button_addthi1.Text = "Tạo bài thi lần 1";
            this.button_addthi1.UseVisualStyleBackColor = true;
            this.button_addthi1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_ketquahoctap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 628);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ketquahoctap";
            this.Text = "Form_ketquahoctap";
            this.Load += new System.EventHandler(this.Form_ketquahoctap_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ketqua)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_thi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_ketqua;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_thi;
        private System.Windows.Forms.Button button_addthi1;
        private System.Windows.Forms.Button button_filterThi;
        private System.Windows.Forms.Button button2_addthi2;
    }
}