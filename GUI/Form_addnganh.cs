using quanlydiemsinhvien.BUS;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlydiemsinhvien.GUI
{
    public partial class Form_addnganh : Form
    {
        DTO_nganh nganh;
        string type;
        List<DTO_khoa> l_khoa;
        public Form_addnganh(DTO_nganh _nganh, string _type)
        {
            InitializeComponent();
            helper.ConfigureForm(this);
            
            nganh = _nganh;
            
            type = _type;
            if (type == "edit")
            {
                l_khoa = BUS_khoa.GetInstance.GetAll()
                    .Where(y => y.Id == nganh.Id_khoahoc).ToList();

                helper.LoadComboBox(comboBox_khoa, l_khoa, "tenkhoa" , "id");
                textBox_tennganhhoc.Text = nganh.Tennganhhoc;
                button1.Text = "Cập nhật";
                button2.Text = "Xóa";
            }
            if (type == "add")
            {
                groupBox1.Text = "Thêm ngành học mới";
                l_khoa = BUS_khoa.GetInstance.GetAll().Where(y => y.Id == nganh.Id_khoahoc).ToList(); ;
                helper.LoadComboBox(comboBox_khoa, l_khoa, "tenkhoa", "id");
                button1.Hide();
                button2.Text = "Thêm";
            }
        }
        // button delete or add
        private void button2_Click(object sender, EventArgs e)
        {
            if (type == "add") //add action
            {
                if (string.IsNullOrWhiteSpace(textBox_tennganhhoc.Text))
                {
                    MessageBox.Show("Tên ngành học không được để trống");
                    return;
                }
                nganh.Tennganhhoc = textBox_tennganhhoc.Text;
                nganh.Id_khoahoc = (int)comboBox_khoa.SelectedValue;
                if (BUS_nganh.GetInstance.Add(nganh)) { MessageBox.Show(helper.MsgAddSuccess); this.Close(); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
            }
            else //delete action
            {
                if (BUS_nganh.GetInstance.Delete(nganh)) { MessageBox.Show(helper.MsgDelSuccess); this.Close(); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
            }
        }
        // button update
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_tennganhhoc.Text))
            {
                MessageBox.Show("Tên ngành học không được để trống"); return;
            }

            nganh.Tennganhhoc = textBox_tennganhhoc.Text;
            nganh.Id_khoahoc = (int)comboBox_khoa.SelectedValue;
            if (BUS_nganh.GetInstance.Edit(nganh)) { MessageBox.Show(helper.MsgEditSuccess); this.Close(); }
            else { MessageBox.Show(helper.MsgExecuteErr); }
        }
    }
}
