using Microsoft.Reporting.WinForms;
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
    public partial class Form_rpThi1 : Form
    {
        public Form_rpThi1(List<DTO_viewThi> _thi, List<DTO_viewKetqua> _kq)
        {
            InitializeComponent();

            DataTable thi = ToDataTable_Thi(_thi);
            DataTable kq = ToDataTable_Ketqua(_kq); 

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            string path = "..\\..\\GUI\\Report_thi1.rdlc";
            reportViewer1.LocalReport.ReportPath = path;
            //reportViewer1.LocalReport.ReportPath = "C:\\Users\\ukyo\\Desktop\\New folder\\quanlydiemsinhvien\\GUI\\Report_thi1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_thi", thi));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_ketqua", kq));
        }

        private void Form_rp_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public DataTable ToDataTable_Ketqua(List<DTO_viewKetqua> items)
        {
            DataTable dataTable = new DataTable(typeof(DTO_viewKetqua).Name);

            // Thêm các cột vào DataTable
            dataTable.Columns.Add("diem", typeof(double));
            dataTable.Columns.Add("tensv", typeof(string));
            dataTable.Columns.Add("masv", typeof(string));
            dataTable.Columns.Add("ngaysinh", typeof(DateTime));

            // Thêm các hàng vào DataTable
            foreach (var item in items)
            {
                DataRow row = dataTable.NewRow();
                row["diem"] = item.Diem;
                row["tensv"] = item.Tensv;
                row["masv"] = item.Masv;
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


    }
}


//public Form_reportketquathi(DTO_kythi x)
//{
//    InitializeComponent();

//    ketqua = BUS_ketqua.Instance.GetAllWithKetQua(x);
//    sinhvien = BUS_sinhvien.Instance.GetSinhVienByKyThi(x);
//    //DTO_lophoc dTO_Lophoc = new DTO_lophoc() { ID = x.id };
//    //MessageBox.Show(dTO_Lophoc.ID.ToString());
//    khoahoc = BUS_khoahoc.Instance.GetByKyThi(x);
//    //MessageBox.Show(khoahoc.TenKhoa);
//    foreach (DTO_sinhvien sv in sinhvien)
//    {
//        foreach (DTO_ketqua kq in ketqua)
//        {
//            if (sv.TenSinhVien == kq.SinhVien)
//            {
//                fullketqua fkq = new fullketqua();
//                fkq.tensinhvien = sv.TenSinhVien;
//                fkq.diem = kq.Diem.ToString();
//                fkq.ngaysinh = sv.NgaySinh;
//                fkq.masinhvien = sv.MaSinhVien;
//                listfullketqua.Add(fkq);
//            }
//        }
//    }

//    DataTable dataTableDiem = ConvertToDataTableFullketqua(listfullketqua);
//    DataTable infokithi = ConvertToDataTableFullKyThi(x, khoahoc);

//    reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
//    reportViewer1.LocalReport.ReportPath = "D:\\winform_quanlydiemsinhvien\\GUI\\Report_ketquathi.rdlc";
//    reportViewer1.LocalReport.DataSources.Clear();
//    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_ketquathi1", dataTableDiem));
//    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_ketquathi2", infokithi));


//}

//List<fullketqua> listfullketqua = new List<fullketqua>();
//List<DTO_ketqua> ketqua;
//List<DTO_sinhvien> sinhvien;
//DTO_khoahoc khoahoc;

//private DataTable ConvertToDataTableFullketqua(List<fullketqua> items)
//{
//    DataTable dataTable = new DataTable(typeof(fullketqua).Name);

//    dataTable.Columns.Add("tensinhvien", typeof(string));
//    dataTable.Columns.Add("diem", typeof(string));
//    dataTable.Columns.Add("ngaysinh", typeof(DateTime));
//    dataTable.Columns.Add("masinhvien", typeof(string));

//    foreach (var item in items)
//    {
//        var row = dataTable.NewRow();
//        row["tensinhvien"] = item.tensinhvien;
//        row["diem"] = item.diem;
//        row["ngaysinh"] = item.ngaysinh;
//        row["masinhvien"] = item.masinhvien;
//        //row["lop"] = item.lop;
//        dataTable.Rows.Add(row);
//    }

//    return dataTable;
//}