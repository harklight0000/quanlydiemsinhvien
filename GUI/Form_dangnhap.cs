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
    public partial class Form_dangnhap : Form
    {
        public Form_dangnhap()
        {
            InitializeComponent();
            helper.ConfigureForm(this);
        }

        private void Form_dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void button_dangnhap_Click(object sender, EventArgs e)
        {
            string _tendangnhap = textBox_tendangnhap.Text;
            string _matkhau = textBox_matkhau.Text;
            var x = new DTO_taikhoan();
            x.TenDangNhap = _tendangnhap;
            x.Matkhau = _matkhau;
            DTO_taikhoan taikhoan = BUS_taikhoan.GetInstance.Login(x);

            //if (taikhoan == null) { MessageBox.Show("sai tai khoan or mat khau"); }
            //else { helper.ShowForm(this, new Form1()); }

            helper.ShowForm(this, new Form1());
        }
    }
}
