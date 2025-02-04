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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            helper.ConfigureForm(this);
            helper.LoadTabcontrol(tabPage1, new Form_ketquahoctap(), "Kết quả học tập");
            helper.LoadTabcontrol(tabPage2, new Form_danhsachsinhvien(), "Danh sách sinh viên");
            helper.LoadTabcontrol(tabPage3, new Form_chuongtrinhdaotao(), "Chương trình đào tạo");
            helper.LoadTabcontrol(tabPage4, new Form_rpSv(), "Tra cứu điểm sinh viên");

            //helper.LoadTabcontrol(tabPage4, new Form_danhsachsinhvien(), "Danh sách sinh viên");


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            TabPage currentTab = tabControl1.SelectedTab;

          
            if (currentTab == tabPage1)
            {
                helper.LoadTabcontrol(tabPage1, new Form_ketquahoctap(), "Kết quả học tập");
            }
            else if (currentTab == tabPage2)
            {
                helper.LoadTabcontrol(tabPage2, new Form_danhsachsinhvien(), "Danh sách sinh viên");
            }
            else if (currentTab == tabPage3)
            {
                helper.LoadTabcontrol(tabPage3, new Form_chuongtrinhdaotao(), "Chương trình đào tạo");
            }
            else if (currentTab == tabPage4)
            {
                helper.LoadTabcontrol(tabPage4, new Form_rpSv(), "Tra cứu điểm sinh viên");

            }

        }
    }

}
