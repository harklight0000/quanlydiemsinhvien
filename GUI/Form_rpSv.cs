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
    public partial class Form_rpSv : Form
    {
        string path = "..\\..\\GUI\\Report_sv.rdlc";
        public Form_rpSv()
        {
            InitializeComponent();
            reportViewer1.Hide();
        }

        private void Form_rpSv_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DTO_sinhvien sv = new DTO_sinhvien()
            {
                Masinhvien = textBox1.Text
            };

            List<DTO_rpTtsv> datasv = BUS_view.GetInstance.GetRpTtsvs(sv);
            if (datasv.Count == 0)
            {
                MessageBox.Show("không tìm thấy sinh viên");
                return;
            }
            reportViewer1.Show();
            List<DTO_rpDiemSv> diem = BUS_view.GetInstance.getRpDiemSv(sv);
            DataTable _ttsv = ConvertToDataTable_Ttsv(datasv);
            DataTable _diem = ConvertToDataTable_DiemSv(diem);
            //MessageBox.Show(diem[0].Tenmonhoc);

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = path;

            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show($"File .rdlc không tồn tại tại: {path}");
                return;
            }

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_ttsv", _ttsv));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_diem", _diem));
            reportViewer1.RefreshReport();
        }
        public DataTable ConvertToDataTable_DiemSv(List<DTO_rpDiemSv> items)
        {
            DataTable dataTable = new DataTable();

            // Thêm các cột vào DataTable
            dataTable.Columns.Add("Diem", typeof(double));
            dataTable.Columns.Add("Lanthi", typeof(int));
            dataTable.Columns.Add("Hinhthuc", typeof(string));
            dataTable.Columns.Add("Tenmonhoc", typeof(string));

            // Duyệt qua danh sách và thêm từng bản ghi vào DataTable
            foreach (var item in items)
            {
                dataTable.Rows.Add(
                    item.Diem,
                    item.Lanthi,
                    item.Hinhthuc,
                    item.Tenmonhoc
                );
            }

            return dataTable;
        }
        public DataTable ConvertToDataTable_Ttsv(List<DTO_rpTtsv> items)
        {
            DataTable dataTable = new DataTable();

            // Thêm các cột vào DataTable
            dataTable.Columns.Add("Masinhvien", typeof(string));
            dataTable.Columns.Add("Tensinhvien", typeof(string));
            dataTable.Columns.Add("Tenlop", typeof(string));
            dataTable.Columns.Add("Tenkhoa", typeof(string));
            dataTable.Columns.Add("Tennganh", typeof(string));
            dataTable.Columns.Add("Ngaysinh", typeof(DateTime));

            // Duyệt qua danh sách và thêm từng bản ghi vào DataTable
            foreach (var item in items)
            {
                dataTable.Rows.Add(
                    item.Masinhvien,
                    item.Tensinhvien,
                    item.Tenlop,
                    item.Tenkhoa,
                    item.Tennganh,
                    item.Ngaysinh
                );
            }

            return dataTable;
        }
    }
}
