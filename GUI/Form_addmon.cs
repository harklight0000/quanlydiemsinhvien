using quanlydiemsinhvien.BUS;
using quanlydiemsinhvien.DAL;
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
    public partial class Form_addmon : Form
    {
        string typeform;
        DTO_mon mon = new DTO_mon();
        //List<DTO_nganh> l_nganh;
        DTO_nganh nganh;
                  
        public Form_addmon( DTO_mon _mon , string type)
        {
            InitializeComponent();
            helper.ConfigureForm(this);
            typeform = type;
            mon = _mon;
            //mon.Id_nganhhoc = x.id;
            nganh = BUS_nganh.GetInstance.GetAll().Where(y => y.Id == mon.Id_nganhhoc).First();
            textBox_tennganhhoc.Enabled = false;
            if (type == "edit")
            {
                groupBox1.Text = "Cập nhật thông tin môn học"; 
                //textBox_tennganhhoc.Text = x.tennganhhoc;
                textBox_tennganhhoc.Text = nganh.Tennganhhoc;

                textBox_tenmonhoc.Text = _mon.Tenmonhoc;
                textBox_mamonhoc.Text = _mon.Mamonhoc;
                numericUpDown_sogiolt.Value = _mon.Sogiolt;
                numericUpDown_sogioth.Value = _mon.Sogioth;
                numericUpDown_hocky.Value = _mon.Hocky;

                button1.Text = "Cập nhật";
                button2.Text = "Xóa";
            }
            else
            {
                textBox_tennganhhoc.Text = nganh.Tennganhhoc;
                textBox_tennganhhoc.Enabled = false;
                groupBox1.Text = "Thêm môn học mới";

                button1.Hide();
                button2.Text = "Thêm";
            }

        }
        // update
        private void button1_Click(object sender, EventArgs e)
        {
            if (typeform == "edit")
            {
                if (string.IsNullOrWhiteSpace(textBox_tenmonhoc.Text) || string.IsNullOrWhiteSpace(textBox_mamonhoc.Text))
                {
                    MessageBox.Show("Tên môn học và mã môn học không được để trống");
                    return;
                }
                mon.Tenmonhoc = textBox_tenmonhoc.Text;
                mon.Mamonhoc = textBox_mamonhoc.Text;
                mon.Sogiolt = (int)numericUpDown_sogiolt.Value;
                mon.Sogioth = (int)numericUpDown_sogioth.Value;
                mon.Hocky = (int)numericUpDown_hocky.Value;
                if (BUS_mon.GetInstance.Edit(mon)) { MessageBox.Show(helper.MsgEditSuccess); this.Close(); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
            }
        }
        //delete or add
        private void button2_Click(object sender, EventArgs e)
        {
            if (typeform == "add")
            {
                if (string.IsNullOrWhiteSpace(textBox_tenmonhoc.Text) || string.IsNullOrWhiteSpace(textBox_mamonhoc.Text))
                {
                    MessageBox.Show("Tên môn học và mã môn học không được để trống");
                    return;
                }
                mon.Tenmonhoc = textBox_tenmonhoc.Text;
                mon.Mamonhoc = textBox_mamonhoc.Text;
                mon.Sogiolt = (int)numericUpDown_sogiolt.Value;
                mon.Sogioth = (int)numericUpDown_sogioth.Value;
                mon.Hocky = (int)numericUpDown_hocky.Value;
                if (BUS_mon.GetInstance.Add(mon)) { MessageBox.Show(helper.MsgAddSuccess); this.Close(); }
                else { MessageBox.Show(helper.MsgExecuteErr); }
            }
            else
            {
                mon.Mamonhoc = textBox_mamonhoc.Text;
                if (BUS_mon.GetInstance.Delete(mon)) { MessageBox.Show(helper.MsgDelSuccess); this.Close(); }
                else
                {
                    MessageBox.Show(helper.MsgExecuteErr);
                }
            }
        }
    }
}
