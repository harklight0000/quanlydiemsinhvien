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
    public partial class Form_danhsachsinhvien : Form
    {
        public Form_danhsachsinhvien()
        {
            InitializeComponent();
            helper.ConfigureForm(this);
            helper.ConfigureDataGridView(dataGridView_lop, listColLop);
            helper.ConfigureDataGridView(dataGridView_sinhvien, listColSinhvien);
            groupBox2.Text = "Danh sách lớp";
            groupBox3.Text = "";
            LoadDgv_lop();
        }
        DTO_viewLop v_lop;
        DTO_lop lop = new DTO_lop() { Id = 0 };
        List<DTO.DTO_viewLop> listLop = new List<DTO.DTO_viewLop>();
        List<DTO_sinhvien> listSinhvien;
        string typeFormSinhvien;

        DTO_sinhvien sinhvien = new DTO_sinhvien();
        List<dgv_ColInfo> listColLop = new List<dgv_ColInfo>
        {
            new dgv_ColInfo {
               DataPropertyName = "tenlop",
               HeaderText = "Lớp",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "tenkhoa",
               HeaderText = "Khóa",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "tennganh",
               HeaderText = "Ngành",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "sosv",
               HeaderText = "Số sinh viên",
               ReadOnly = true },
        };
        List<dgv_ColInfo> listColSinhvien = new List<dgv_ColInfo>
        {
            new dgv_ColInfo {
               DataPropertyName = "tensinhvien",
               HeaderText = "Tên sinh viên",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "masinhvien",
               HeaderText = "Mã sinh viên",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "ngaysinh",
               HeaderText = "Ngày sinh",
               ReadOnly = true },
        };

        private void LoadDgv_lop()
        {
            listLop = BUS.BUS_view.GetInstance.GetAllViewLop();
            dataGridView_lop.DataSource = listLop;
        }
        private void LoadDgv_sinhvien()
        {
            lop.Id = v_lop.Id_lop;
            listSinhvien = DAL_sinhvien.GetInstance.GetByLop(lop);
            dataGridView_sinhvien.DataSource = listSinhvien;
        }

        private void dataGridView_lop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex == 0) { return; }
            v_lop = dataGridView_lop.CurrentRow.DataBoundItem as DTO_viewLop;
            lop.Id = v_lop.Id_lop;
            groupBox3.Text = $"Danh sách sinh viên lớp {v_lop.Tenlop} (ngành {v_lop.Tennganh})";
            LoadDgv_sinhvien();
            //LoadDgv_lop();
            lop.Id = v_lop.Id_lop;
            lop.Id_nganhhoc = v_lop.Id_nganh;
            lop.Tenlop = v_lop.Tenlop;
        }

        private void dataGridView_lop_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            v_lop = dataGridView_lop.CurrentRow.DataBoundItem as DTO_viewLop;
            lop.Id = v_lop.Id_lop;
            lop.Id_nganhhoc = v_lop.Id_nganh;
            lop.Tenlop = v_lop.Tenlop;
            helper.ShowFormDialog(this, new Form_addlop("edit", lop));
            LoadDgv_lop();
        }

        private void button_addlop_Click(object sender, EventArgs e)
        {
            helper.ShowFormDialog(this, new Form_addlop("add", null));
            LoadDgv_lop();
        }

        private void dataGridView_sinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button_addsinhvien_Click(object sender, EventArgs e)
        {
            if (lop.Id == 0) { return; }
            typeFormSinhvien = "add";
            sinhvien.Id_lophoc = lop.Id;
            //MessageBox.Show($"{typeFormSinhvien}-{lop.Tenlop}");
            helper.ShowFormDialog(this, new Form_addsinhvien(sinhvien, $"{typeFormSinhvien}-{lop.Tenlop}"));
            LoadDgv_sinhvien();
            LoadDgv_lop();
        }

        private void dataGridView_sinhvien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            typeFormSinhvien = "edit";
            sinhvien = dataGridView_sinhvien.CurrentRow.DataBoundItem as DTO_sinhvien;
            if (sinhvien == null) { return; }
            helper.ShowFormDialog(this, new Form_addsinhvien(sinhvien, $"{typeFormSinhvien}-{lop.Tenlop}"));
            LoadDgv_sinhvien();
        }
    }
}
