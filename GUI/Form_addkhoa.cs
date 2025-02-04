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
    public partial class Form_addkhoa : Form
    {
        DTO_khoa khoa;
        string type;

        public Form_addkhoa(DTO_khoa _khoa, string _type)
        {
            helper.ConfigureForm(this);
            InitializeComponent();
            khoa = _khoa ?? new DTO_khoa();
            type = _type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == "edit")
            {
                if (string.IsNullOrWhiteSpace(textBox_ten.Text))
                {
                    MessageBox.Show("Lỗi trống input");
                    return;
                }
                khoa.Tenkhoa = textBox_ten.Text;
                if (BUS_khoa.GetInstance.Edit(khoa))
                {
                    MessageBox.Show(helper.MsgEditSuccess);
                }
                else
                {
                    MessageBox.Show(helper.MsgExecuteErr);
                }
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (type == "add")
            {
                if (string.IsNullOrWhiteSpace(textBox_ten.Text))
                {
                    MessageBox.Show("Lỗi trống input");
                    return;
                }
                khoa.Tenkhoa = textBox_ten.Text;
                if (BUS_khoa.GetInstance.Add(khoa))
                {
                    MessageBox.Show(helper.MsgAddSuccess);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(helper.MsgExecuteErr);
                }
            }
            else if (type == "edit")
            {
                if (BUS_khoa.GetInstance.Delete(khoa))
                {
                    MessageBox.Show(helper.MsgDelSuccess);
                }
                else
                {
                    MessageBox.Show(helper.MsgExecuteErr);
                }
                this.Close();
            }
        }

        private void Form_addkhoa_Load(object sender, EventArgs e)
        {
            if (type == "edit")
            {
                textBox_ten.Text = khoa.Tenkhoa;
                button1.Text = "Sửa";
                button2.Text = "Xóa";
            }
            else
            {
                button1.Hide();
                button2.Text = "Thêm";
            }
        }
    }
}
