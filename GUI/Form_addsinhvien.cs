using quanlydiemsinhvien.BUS;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlydiemsinhvien.GUI
{
    public partial class Form_addsinhvien : Form
    {
        DTO_sinhvien sinhvien;
        string TypeForm;
        string[] line;
        public Form_addsinhvien(DTO_sinhvien x, string type)
        {
            TypeForm = type;
            line = TypeForm.Split('-');
            sinhvien = x;
            InitializeComponent();
            helper.ConfigureForm(this);
            if (line[0] == "add")
            {
                groupBox1.Text = $"Thêm sinh viên lớp {line[1]}";
              
                button1.Hide();
                button2.Text = "Thêm";
            }
            else
            {
                
                groupBox1.Text = $"Cập nhật thông tin sinh viên lớp {line[1]}";
                //groupBox1.Text = $"Cập nhật thông tin sinh viên";

                textBox_masv.Text = sinhvien.Masinhvien;
                textBox_tensv.Text = sinhvien.Tensinhvien;
                dateTimePicker_ngaysinh.Value = sinhvien.Ngaysinh;
                button1.Text = "Cập nhật";
                button2.Text = "Xóa";

                textBox_masv.Enabled = false;
            }
        }

        private void Form_addsinhvien_Load(object sender, EventArgs e)
        {

        }
        // button delete or add
        private void button2_Click(object sender, EventArgs e)
        {
            if (line[0] == "add") //add action
            {
                if (string.IsNullOrWhiteSpace(textBox_tensv.Text) || string.IsNullOrWhiteSpace(textBox_masv.Text))
                {
                    MessageBox.Show("Tên sinh viên và mã sinh viên không được để trống");
                    return;
                }
                sinhvien.Tensinhvien = textBox_tensv.Text;
                sinhvien.Masinhvien = textBox_masv.Text;
                sinhvien.Ngaysinh = dateTimePicker_ngaysinh.Value;
                if (BUS_sinhvien.GetInstance.Add(sinhvien)) { MessageBox.Show(helper.MsgAddSuccess); this.Close(); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
            }
            else //delete action
            {
                if (BUS_sinhvien.GetInstance.Delete(sinhvien)) { MessageBox.Show(helper.MsgDelSuccess); this.Close(); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //action edit
            if (string.IsNullOrWhiteSpace(textBox_tensv.Text) || string.IsNullOrWhiteSpace(textBox_masv.Text))
            {
                MessageBox.Show("Tên sinh viên và mã sinh viên không được để trống");
                return;
            }
            sinhvien.Tensinhvien = textBox_tensv.Text;
            sinhvien.Masinhvien = textBox_masv.Text;
            sinhvien.Ngaysinh = dateTimePicker_ngaysinh.Value;
            if (BUS_sinhvien.GetInstance.Edit(sinhvien)) { MessageBox.Show(helper.MsgEditSuccess); this.Close(); }
            else { MessageBox.Show(helper.MsgExecuteErr); }
        }
    }
}
