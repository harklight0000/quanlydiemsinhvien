using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    internal class DTO_view
    {
    }
    public class DTO_viewLop
    {
        string tenlop;
        int id_lop;
        string  tenkhoa;
        string tennganh;
        int sosv;
        int id_nganh;
        public DTO_viewLop()
        {
        }

        public DTO_viewLop(DataRow dataRow)
        {
            this.Tenlop = dataRow["tenlop"].ToString();
            this.Id_lop = (int)dataRow["id_lop"];
            this.Tenkhoa = dataRow["tenkhoa"].ToString();
            this.Tennganh = dataRow["tennganh"].ToString();
            this.Sosv = (int)dataRow["sosv"];
            this.Id_nganh = (int)dataRow["nganh_id"];
        }

        public string Tenlop { get => tenlop; set => tenlop = value; }
        public int Id_lop { get => id_lop; set => id_lop = value; }
        public string Tenkhoa { get => tenkhoa; set => tenkhoa = value; }
        public string Tennganh { get => tennganh; set => tennganh = value; }
        public int Sosv { get => sosv; set => sosv = value; }
        public int Id_nganh { get => id_nganh; set => id_nganh = value; }
    }

    public class DTO_viewThi
    {
        int id;
        string mamonhoc;
        int id_lophoc;
        DateTime ngaythi;
        string hinhthuc;
        int lanthi;
        string tenmonhoc;
        string tenlop;
        string tennganhhoc;
        string tenkhoa;

        public DTO_viewThi()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Mamonhoc { get => mamonhoc; set => mamonhoc = value; }
        public int Id_lophoc { get => id_lophoc; set => id_lophoc = value; }
        public DateTime Ngaythi { get => ngaythi; set => ngaythi = value; }
        public string Hinhthuc { get => hinhthuc; set => hinhthuc = value; }
        public int Lanthi { get => lanthi; set => lanthi = value; }
        public string Tenmonhoc { get => tenmonhoc; set => tenmonhoc = value; }
        public string Tenlop { get => tenlop; set => tenlop = value; }
        public string Tennganhhoc { get => tennganhhoc; set => tennganhhoc = value; }
        public string Tenkhoa { get => tenkhoa; set => tenkhoa = value; }
    }

    ///select KetQua.Diem as diem, KetQua.ID as id, SinhVien.TenSinhVien as tensv, SinhVien.MaSinhVien  masv, LopHoc.TenLop as lop
    ///

    public class DTO_viewKetqua
    {
        float diem;
        int id;
        string tensv;
        string masv;
        string lop;
        DateTime ngaysinh;
        public DTO_viewKetqua()
        {
        }

        public float Diem { get => diem; set => diem = value; }
        public int Id { get => id; set => id = value; }
        public string Tensv { get => tensv; set => tensv = value; }
        public string Masv { get => masv; set => masv = value; }
        public string Lop { get => lop; set => lop = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
    }
    public class DTO_rpTtsv
    {
        public DTO_rpTtsv()
        {
        }
        string masinhvien;
        string tensinhvien;
        string tenlop;
        string tenkhoa;
        string tennganh;
        DateTime ngaysinh;

        public string Masinhvien { get => masinhvien; set => masinhvien = value; }
        public string Tensinhvien { get => tensinhvien; set => tensinhvien = value; }
        public string Tenlop { get => tenlop; set => tenlop = value; }
        public string Tenkhoa { get => tenkhoa; set => tenkhoa = value; }
        public string Tennganh { get => tennganh; set => tennganh = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
    }
    public class DTO_rpDiemSv
    {
        double diem;
        int lanthi;
        string hinhthuc; 
        string tenmonhoc;

        public DTO_rpDiemSv()
        {
        }

        public double Diem { get => diem; set => diem = value; }
        public int Lanthi { get => lanthi; set => lanthi = value; }
        public string Hinhthuc { get => hinhthuc; set => hinhthuc = value; }
        public string Tenmonhoc { get => tenmonhoc; set => tenmonhoc = value; }
    }


}
