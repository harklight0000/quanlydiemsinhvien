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
    public partial class Form_rpThi2 : Form
    {
        public Form_rpThi2(List<DTO_viewThi> _thi, List<DTO_viewKetqua> _kq)
        {
            InitializeComponent();
            //MessageBox.Show(_kq[0].Lop)
            DataTable thi = ToDataTable_Thi(_thi);
            DataTable kq = ToDataTable_Ketqua(_kq);

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "..\\..\\GUI\\Report_thi2.rdlc";

            //reportViewer1.LocalReport.ReportPath = "C:\\Users\\ukyo\\Desktop\\New folder\\quanlydiemsinhvien\\GUI\\Report_thi2.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_thi", thi));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_ketqua", kq));
        }
        public DataTable ToDataTable_Ketqua(List<DTO_viewKetqua> items)
        {
            DataTable dataTable = new DataTable(typeof(DTO_viewKetqua).Name);

            // Thêm các cột vào DataTable
            dataTable.Columns.Add("diem", typeof(double));
            dataTable.Columns.Add("tensv", typeof(string));
            dataTable.Columns.Add("masv", typeof(string));
            dataTable.Columns.Add("tenlop", typeof(string));
            dataTable.Columns.Add("ngaysinh", typeof(DateTime));

            // Thêm các hàng vào DataTable
            foreach (var item in items)
            {
                DataRow row = dataTable.NewRow();
                row["diem"] = item.Diem;
                row["tensv"] = item.Tensv;
                row["masv"] = item.Masv;
                row["tenlop"] = item.Lop;
                row["ngaysinh"] = item.Ngaysinh;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable ToDataTable_Thi(List<DTO_viewThi> items)
        {
            DataTable dataTable = new DataTable(typeof(DTO_viewThi).Name);

            // Thêm các cột vào DataTable

            dataTable.Columns.Add("mamonhoc", typeof(string));
            dataTable.Columns.Add("tenmonhoc", typeof(string));
            dataTable.Columns.Add("ngaythi", typeof(DateTime));
            dataTable.Columns.Add("hinhthuc", typeof(string));
            dataTable.Columns.Add("lanthi", typeof(int));
            dataTable.Columns.Add("tenlop", typeof(string));

            dataTable.Columns.Add("tennganhhoc", typeof(string));
            dataTable.Columns.Add("tenkhoa", typeof(string));

            // Thêm các hàng vào DataTable
            foreach (var item in items)
            {
                DataRow row = dataTable.NewRow();

                row["mamonhoc"] = item.Mamonhoc.ToUpper();
                row["tenmonhoc"] = item.Tenmonhoc.ToUpper();
                row["ngaythi"] = item.Ngaythi;
                row["hinhthuc"] = item.Hinhthuc;
                row["lanthi"] = item.Lanthi;
                row["tenlop"] = item.Tenlop.ToUpper();

                row["tennganhhoc"] = item.Tennganhhoc;
                row["tenkhoa"] = item.Tenkhoa;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private void Form_rpThi2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
