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
    public partial class Form_ketquahoctap : Form
    {
        List<DTO_lop> list_lop = BUS_lop.GetInstance.GetAll();
        List<DTO_mon> list_mon = BUS_mon.GetInstance.GetAll();
        List<DTO_viewThi> list_viewthi;
        List<DTO_viewKetqua> list_viewKetqua;
        DTO_viewThi selectedViewThi = new DTO_viewThi();
        DTO_viewKetqua selectedViewKetqua = new DTO_viewKetqua();   
        DTO_ketqua ketqua = new DTO_ketqua();
        List<dgv_ColInfo> listColThi = new List<dgv_ColInfo>
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
               DataPropertyName = "tenmonhoc",
               HeaderText = "Tên môn học",
               ReadOnly = true,
                Width = 150},
            new dgv_ColInfo {
               DataPropertyName = "hinhthuc",
               HeaderText = "Hình thức",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "lanthi",
               HeaderText = "Lần thi",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "tenkhoa",
               HeaderText = "Khóa",
               ReadOnly = true },
        };
        
        //select KetQua.Diem as diem, KetQua.ID as id, SinhVien.TenSinhVien as tensv, SinhVien.MaSinhVien  masv, LopHoc.TenLop as lop , SinhVien.NgaySinh as ngaysinh 
        List<dgv_ColInfo> listColKetqua = new List<dgv_ColInfo>
        {
            new dgv_ColInfo {
               DataPropertyName = "tensv",
               HeaderText = "Họ tên",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "masv",
               HeaderText = "Mã sinh viên",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "ngaysinh",
               HeaderText = "Ngày sinh",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "lop",
               HeaderText = "Lớp",
               ReadOnly = true },
            new dgv_ColInfo {
               DataPropertyName = "diem",
               HeaderText = "Điểm",
               ReadOnly = false },
        };
        public Form_ketquahoctap()
        {
            InitializeComponent();

           
            helper.ConfigureForm(this);
          
            groupBox2.Text = "Danh sách";
            groupBox3.Text = "Kết quả";
            helper.ConfigureDataGridView(dataGridView_thi, listColThi);
            helper.ConfigureDataGridView(dataGridView_ketqua, listColKetqua);
            LoadDgvThi();

        }

        private void LoadDgvThi()
        { 
            list_viewthi = BUS_view.GetInstance.GetAllViewThi();
            dataGridView_thi.DataSource = list_viewthi;
        }
        private void LoadDgvKetqua(DTO_viewThi x)
        {
            list_viewKetqua = BUS_view.GetInstance.GetAllViewKetqua(x);
          
            
            dataGridView_ketqua.DataSource = list_viewKetqua;
        }

        private void Form_ketquahoctap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            helper.ShowFormDialog(this, new Form_addthi("add1", null));
            LoadDgvThi();
        }
        private void button2_Click(object sender, EventArgs e)
        {


            helper.ShowFormDialog(this, new Form_addthi("add2", null));
            LoadDgvThi();
        }
      
        private void dataGridView_thi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedViewThi = (DTO_viewThi)dataGridView_thi.CurrentRow.DataBoundItem;
            if (selectedViewThi.Lanthi == 1)
            {
                helper.ShowFormDialog(this, new Form_addthi("edit1", selectedViewThi));
            }
            if (selectedViewThi.Lanthi == 2)
            {
                helper.ShowFormDialog(this, new Form_addthi("edit2", selectedViewThi));
            }
            LoadDgvThi();


        }

        private void dataGridView_thi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedViewThi = (DTO_viewThi)dataGridView_thi.CurrentRow.DataBoundItem;
            if (selectedViewThi.Lanthi == 1) { groupBox3.Text = $"Bài thi môn {selectedViewThi.Tenmonhoc} {selectedViewThi.Hinhthuc} lần thi {selectedViewThi.Lanthi} lớp {selectedViewThi.Tenlop}"; }
            if(selectedViewThi.Lanthi == 2 ) { groupBox3.Text = $"Bài thi môn {selectedViewThi.Tenmonhoc} {selectedViewThi.Hinhthuc} lần thi {selectedViewThi.Lanthi}"; }
            LoadDgvKetqua(selectedViewThi);
        }

        private void dataGridView_ketqua_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                if (!double.TryParse(dataGridView_ketqua.Rows[e.RowIndex].Cells[4].Value.ToString(), out double number) || number < 0 || number > 10)
                {
                    dataGridView_ketqua.Rows[e.RowIndex].Cells[4].Value = 0;
                }
                else
                {
                    dataGridView_ketqua.Rows[e.RowIndex].Cells[4].Value = number;
                }
                selectedViewKetqua = (DTO_viewKetqua)dataGridView_ketqua.CurrentRow.DataBoundItem;
                ketqua.Id = selectedViewKetqua.Id;
                ketqua.Diem = selectedViewKetqua.Diem;
                BUS_ketqua.GetInstance.Update(ketqua);
                //DTO_ketqua selectedItem = (DTO_ketqua)dataGridView_ketqua.CurrentRow.DataBoundItem;
                //BUS_ketqua.Instance.Edit(selectedItem);
            }
        }
    }
   
}
