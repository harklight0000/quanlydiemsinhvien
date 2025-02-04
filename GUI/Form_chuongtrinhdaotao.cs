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
    public partial class Form_chuongtrinhdaotao : Form
    {
        DTO_nganh nganh;
        DTO_khoa khoa;
        DTO_mon mon;
        List<DTO_nganh> l_nganh = BUS_nganh.GetInstance.GetAll();
        List<DTO_khoa> l_khoa = BUS_khoa.GetInstance.GetAll();
        List<DTO_mon> l_mon = BUS_mon.GetInstance.GetAll();
        List<DTO_mon> filteredMon;
        List<DTO_nganh> filteredNganh;
        List<dgv_ColInfo> listColKhoa = new List<dgv_ColInfo>
        {
            new dgv_ColInfo {
               DataPropertyName = "tenkhoa",
               HeaderText = "Khóa",
               ReadOnly = true }
        };
        List<dgv_ColInfo> listColNganh = new List<dgv_ColInfo>
        {
            new dgv_ColInfo {
               DataPropertyName = "tennganhhoc",
               HeaderText = "Tên ngành học",
               ReadOnly = true },
        };
        List<dgv_ColInfo> listColMon = new List<dgv_ColInfo>
        {
            new dgv_ColInfo {
               DataPropertyName = "mamonhoc",
               HeaderText = "Mã môn học",
               ReadOnly = true },
             new dgv_ColInfo {
               DataPropertyName = "tenmonhoc",
               HeaderText = "Tên môn học",
               ReadOnly = true },
             new dgv_ColInfo {
               DataPropertyName = "hocky",
               HeaderText = "Học kỳ",
               ReadOnly = true }
        }; 
        void loadDgvKhoa()
        {
            l_khoa = BUS_khoa.GetInstance.GetAll();
            dataGridView_khoa.DataSource = l_khoa;    
        }
        void loadDgvNganh()
        {
            l_nganh = BUS_nganh.GetInstance.GetAll();
            filteredNganh = l_nganh.Where(x => x.Id_khoahoc == khoa.Id).ToList();
            dataGridView_nganh.DataSource = filteredNganh;
        }
    
        void loadDgvMon()
        {
            if(nganh == null) { return; }
            l_mon = BUS_mon.GetInstance.GetAll();
            filteredMon = l_mon.Where(x => x.Id_nganhhoc == nganh.Id).ToList();
            dataGridView_mon.DataSource = filteredMon;        
        }
        public Form_chuongtrinhdaotao()
        {
            InitializeComponent();
            helper.ConfigureForm(this);
        }

        private void ctdt_Load(object sender, EventArgs e)
        {
            groupBox4.Text = "Danh sách khóa";
            groupBox2.Text = "Danh sách ngành học";
            groupBox3.Text = "Danh sách môn học";
            helper.ConfigureDataGridView(dataGridView_khoa, listColKhoa);
            helper.ConfigureDataGridView(dataGridView_nganh, listColNganh);
            helper.ConfigureDataGridView(dataGridView_mon, listColMon);
            loadDgvKhoa();
        }
        private void dataGridView_khoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           khoa = dataGridView_khoa.CurrentRow.DataBoundItem as DTO_khoa;
           loadDgvNganh();
           dataGridView_mon.DataSource = null;
            groupBox2.Text = $"Danh sách ngành học (khóa {khoa.Tenkhoa})";
            groupBox3.Text = "Danh sách môn học";
        }

        private void dataGridView_khoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            khoa = dataGridView_khoa.CurrentRow.DataBoundItem as DTO_khoa;
            //MessageBox.Show(khoa.Tenkhoa.ToString());
            helper.ShowFormDialog(this, new Form_addkhoa(khoa, "edit"));
            loadDgvKhoa();
        }

        private void button_addkhoa_Click(object sender, EventArgs e)
        {
            helper.ShowFormDialog(this, new Form_addkhoa(null, "add"));
            loadDgvKhoa();
        }

        private void dataGridView_nganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nganh = dataGridView_nganh.CurrentRow.DataBoundItem as DTO_nganh;
            groupBox3.Text = $"Danh sách môn học(ngành {nganh.Tennganhhoc})";
            if (nganh == null) {  return; }  
            loadDgvMon();
        }

        private void dataGridView_nganh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            nganh = dataGridView_nganh.CurrentRow.DataBoundItem as DTO_nganh;

            if (nganh == null) { return; }
            helper.ShowFormDialog(this, new Form_addnganh(nganh, "edit"));          
            loadDgvNganh();
            loadDgvMon();
        }

        private void button_addnganh_Click(object sender, EventArgs e)
        {
            khoa = dataGridView_khoa.CurrentRow.DataBoundItem as DTO_khoa;
            nganh = new DTO_nganh() { Id_khoahoc = khoa.Id };
            //MessageBox.Show(nganh.Id_khoahoc.ToString());
            helper.ShowFormDialog(this, new Form_addnganh(nganh, "add"));
            loadDgvNganh();
            loadDgvMon();
        }

        private void dataGridView_mon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView_mon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mon = dataGridView_mon.CurrentRow.DataBoundItem as DTO_mon;
            if (mon == null) return;
            helper.ShowFormDialog(this, new Form_addmon(mon, "edit"));
        }

        private void button_addmon_Click(object sender, EventArgs e)
        {
            if(nganh == null) return;
            nganh = dataGridView_nganh.CurrentRow.DataBoundItem as DTO_nganh;
            mon = new DTO_mon() { Id_nganhhoc = nganh.Id };
            helper.ShowFormDialog(this, new Form_addmon(mon, "add"));
            loadDgvMon();
        }     
    }
}
