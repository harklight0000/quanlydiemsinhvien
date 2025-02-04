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
    public partial class Form_addlop : Form
    {
        public Form_addlop(string _type, DTO_lop _lop)
        {
            InitializeComponent();
            helper.ConfigureForm(this);
            this.type = _type;
            if (_lop != null) { lop = _lop; }

        }
        DTO_lop lop;
        List<DTO_khoa> khoaList = BUS.BUS_khoa.GetInstance.GetAll();
        List<DTO_nganh> nganhList  = BUS.BUS_nganh.GetInstance.GetAll();
        List<DTO_nganh> filteredNganh;
        DTO_nganh selectedNganh;
        DTO_khoa selectedKhoa;
        DTO_lop selectedLop = new DTO_lop();
        DTO_nganh nganh;
        DTO_khoa khoa;
        string type;

        //1 = edit, 2 = del or edit 
        private void Form_lopA_Load(object sender, EventArgs e)
        {
            if(type == "add")
            {         
                helper.LoadComboBox(comboBox_khoa, khoaList, "tenkhoa", "id");
                button2.Text = "Thêm lớp mới";
                button1.Hide(); 
            }
            if(type == "edit")
            {
                button1.Text = "Sửa";
                button2.Text = "Xóa";
                groupBox1.Text = "Cập nhật thông tin lớp";
                comboBox_khoa.Enabled = false;
                comboBox_nganh.Enabled = false;
                nganh = nganhList.FirstOrDefault(n => n.Id == lop.Id_nganhhoc);
                khoa = khoaList.FirstOrDefault(k => k.Id == nganh.Id_khoahoc);
                comboBox_nganh.Text = nganh.Tennganhhoc;
                comboBox_khoa.Text = khoa.Tenkhoa;
                textBox_ten.Text = lop.Tenlop;
            }
            

        }

        private void comboBox_khoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedKhoa = (DTO_khoa)comboBox_khoa.SelectedItem;
            filteredNganh = nganhList.Where(x => x.Id_khoahoc == selectedKhoa.Id).ToList();
            helper.LoadComboBox(comboBox_nganh, filteredNganh, "tennganhhoc", "id");
        }
       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //edit 
        private void button1_Click(object sender, EventArgs e)
        {
            if(type == "edit")
            {
                lop.Tenlop = textBox_ten.Text;
                if (BUS_lop.GetInstance.Edit(lop)) { MessageBox.Show(helper.MsgEditSuccess); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
                this.Close();
            }
        }

        //add or delete  button2 
        private void button2_Click(object sender, EventArgs e)
        {
            if (type == "add")
            {
                if (string.IsNullOrWhiteSpace(textBox_ten.Text))
                {    MessageBox.Show("Tên lớp không được để trống");  return; }
                selectedNganh = (DTO_nganh)comboBox_nganh.SelectedItem;
                selectedLop.Tenlop = textBox_ten.Text;
                selectedLop.Id_nganhhoc = selectedNganh.Id;
                if (BUS.BUS_lop.GetInstance.Add(selectedLop)) { MessageBox.Show(helper.MsgAddSuccess); this.Close(); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
            }
            if (type == "edit")
            {
                if (BUS_lop.GetInstance.Delete(lop)) { MessageBox.Show(helper.MsgDelSuccess); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
                this.Close();
            }
        }
    }
}
