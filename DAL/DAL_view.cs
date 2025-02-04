using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_view
    {
        public static DAL_view Instance;
        public static DAL_view GetInstance { get { if (Instance == null) Instance = new DAL_view(); return DAL_view.Instance; } }
        public List<DTO_viewLop> GetAllViewLop()
        {
            var list = new List<DTO_viewLop>();
            string query = @"
              select LopHoc.TenLop as tenlop , LopHoc.ID as id_lop, KhoaHoc.TenKhoa as tenkhoa , NganhHoc.TenNganhHoc as tennganh , nganhhoc.id as nganh_id ,  COUNT(SinhVien.ID_LopHoc) as sosv
              from LopHoc join NganhHoc on LopHoc.ID_NganhHoc = NganhHoc.ID 
              join KhoaHoc on NganhHoc.ID_KhoaHoc = KhoaHoc.ID 
              left join SinhVien on SinhVien.ID_LopHoc = LopHoc.ID 
              GROUP BY LopHoc.TenLop, LopHoc.ID , KhoaHoc.TenKhoa, NganhHoc.TenNganhHoc , nganhhoc.id;";
            var dt = DAL_dataprovider.GetInstance.ExecuteQuery(query);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                var lop = new DTO_viewLop(dr);
                list.Add(lop);
            }
            return list;
        }


        public List<DTO_viewThi> GetAllViewThi()
        {
            var list = new List<DTO_viewThi>();
            string query = @"
            select 
            Thi.ID as id, 
            LopHoc.TenLop as tenlop, 
            MonHoc.TenMonHoc as tenmonhoc, 
            Thi.LanThi as lanthi, 
            Thi.NgayThi as ngaythi , 
            MonHoc.MaMonHoc as mamonhoc , 
            LopHoc.ID as id_lophoc ,
            Thi.HinhThuc as hinhthuc,
            NganhHoc.TenNganhHoc as tennganhoc,
            KhoaHoc.TenKhoa as tenkhoa
            from Thi left join LopHoc on Thi.ID_LopHoc = LopHoc.ID 
            join MonHoc on Thi.MaMonHoc = MonHoc.MaMonHoc 
            join NganhHoc on NganhHoc.ID = MonHoc.ID_NganhHoc 
            join KhoaHoc on KhoaHoc.ID = NganhHoc.ID_KhoaHoc";
      
            var dt = DAL_dataprovider.GetInstance.ExecuteQuery(query);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                var data = new DTO_viewThi
                {
                    Id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0,
                    Mamonhoc = dr["mamonhoc"] != DBNull.Value ? dr["mamonhoc"].ToString() : "Không xác định",
                    Id_lophoc = dr["id_lophoc"] != DBNull.Value ? Convert.ToInt32(dr["id_lophoc"]) : 0,
                    Ngaythi = dr["ngaythi"] != DBNull.Value ? Convert.ToDateTime(dr["ngaythi"]) : DateTime.MinValue,
                    Hinhthuc = dr["hinhthuc"] != DBNull.Value ? dr["hinhthuc"].ToString() : "Không xác định",
                    Lanthi = dr["lanthi"] != DBNull.Value ? Convert.ToInt32(dr["lanthi"]) : 0,
                    Tenmonhoc = dr["tenmonhoc"] != DBNull.Value ? dr["tenmonhoc"].ToString() : "Không xác định",
                    Tenlop = dr["tenlop"] != DBNull.Value ? dr["tenlop"].ToString() : "Không xác định",
                    Tennganhhoc = dr["tennganhoc"] != DBNull.Value ? dr["tennganhoc"].ToString() : "Không xác định",
                    Tenkhoa = dr["tenkhoa"] != DBNull.Value ? dr["tenkhoa"].ToString() : "Không xác định"

                };
                list.Add(data);
            }
            return list;
        }






        public List<DTO_viewKetqua> GetAllViewKetqua(DTO_viewThi x)
        {
            List<DTO_viewKetqua> list = new List<DTO_viewKetqua>();

            string query = @"select KetQua.Diem as diem, KetQua.ID as id, SinhVien.TenSinhVien as tensv, SinhVien.MaSinhVien  masv, LopHoc.TenLop as lop , SinhVien.NgaySinh as ngaysinh 
                from Thi join KetQua on	KetQua.ID_Thi= Thi.id 
                        join SinhVien on SinhVien.MaSinhVien = KetQua.MaSinhVien 
                        join LopHoc on LopHoc.ID = SinhVien.ID_LopHoc where Thi.ID = @id";
            var data = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] {x.Id});
            foreach (System.Data.DataRow dr in data.Rows)
            {
                var _dt = new DTO_viewKetqua()
                {
                    Lop = dr["lop"] != DBNull.Value ? dr["lop"].ToString() : "Không xác định",
                    Id = dr["id"] != DBNull.Value ? Convert.ToInt32(dr["id"]) : 0,
                    Diem = dr["diem"] != DBNull.Value ? Convert.ToSingle(dr["diem"]) : 0.0f,
                    Masv = dr["masv"].ToString(),
                    Tensv = dr["tensv"].ToString(),
                    Ngaysinh = dr["ngaysinh"] != DBNull.Value ? Convert.ToDateTime(dr["ngaysinh"]) : DateTime.MinValue
                };

                list.Add(_dt);

            }
            return list;
        }

        public List<DTO_rpTtsv> getrpTts(DTO_sinhvien x)
        {
            List<DTO_rpTtsv> result = new List<DTO_rpTtsv>();
            string query = @" select SinhVien.MaSinhVien as masinhvien ,
    SinhVien.TenSinhVien as tensinhvien, 
    SinhVien.NgaySinh as ngaysinh , 
    LopHoc.TenLop as tenlop,  
    NganhHoc.TenNganhHoc as tennganh, 
    KhoaHoc.TenKhoa as tenkhoa from SinhVien join LopHoc on LopHoc.ID = SinhVien.ID_LopHoc join NganhHoc on NganhHoc.ID = LopHoc.ID_NganhHoc join KhoaHoc on KhoaHoc.ID = NganhHoc.ID_KhoaHoc where SinhVien.MaSinhVien = @msv";

            var data = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] { x.Masinhvien });
            foreach (System.Data.DataRow item in data.Rows)
            {
                DTO_rpTtsv y = new DTO_rpTtsv()
                {
                    Masinhvien = item["masinhvien"].ToString(),
                    Tensinhvien = item["tensinhvien"].ToString(),
                    Ngaysinh = item["ngaysinh"] != DBNull.Value ? Convert.ToDateTime(item["ngaysinh"]) : DateTime.MinValue,
                    Tenlop = item["tenlop"].ToString(),
                    Tennganh = item["tennganh"].ToString(),
                    Tenkhoa = item["tenkhoa"].ToString()
                };
                result.Add(y);
            }
            return result;
        }

        public List<DTO_rpDiemSv> getRpdiemsv(DTO_sinhvien x)
        {
            List<DTO_rpDiemSv> result = new List<DTO_rpDiemSv>();
            string query = @"
 select  MonHoc.TenMonHoc as tenmonhoc , 
 Thi.HinhThuc as hinhthuc,
 Thi.LanThi as lanthi,
 KetQua.Diem as diem from KetQua join SinhVien on KetQua.MaSinhVien = SinhVien.MaSinhVien join Thi on Thi.ID = KetQua.ID_Thi join MonHoc on Thi.MaMonHoc = MonHoc.MaMonHoc where KetQua.MaSinhVien = @msv ";

            var data = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] { x.Masinhvien });
            foreach (System.Data.DataRow item in data.Rows)
            {
                DTO_rpDiemSv y = new DTO_rpDiemSv()
                {
                    Diem = item["diem"] != DBNull.Value ? Convert.ToDouble(item["diem"]) : 0.0,
                    Lanthi = item["lanthi"] != DBNull.Value ? Convert.ToInt32(item["lanthi"]) : 0,
                    Hinhthuc = item["hinhthuc"].ToString(),
                    Tenmonhoc = item["tenmonhoc"].ToString()
                };
                result.Add(y);
            }
            return result;
        }

    }
}
