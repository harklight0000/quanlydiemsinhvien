using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_khoa
    {
        private static DAL_khoa Instance;
        public static DAL_khoa GetInstance { get { if(Instance == null) Instance = new DAL_khoa(); return Instance; } }
        public List<DTO_khoa> GetAllKhoaHoc()
        {
            var list = new List<DTO_khoa>();
            string query = @"select * from khoahoc";
            DataTable dt = DAL_dataprovider.GetInstance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                var khoahoc = new DTO_khoa(dr);
                list.Add(khoahoc);
            }
            return list;
        }

        public List<DTO_khoa> GetKhoaHocById(DTO_khoa khoaHoc)
        {
            var list = new List<DTO_khoa>();
            string query = @" select * from khoahoc where id = @id";
            DataTable dt = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] { khoaHoc.Id });
            foreach (DataRow dr in dt.Rows)
            {
                var khoahoc = new DTO_khoa(dr);
                list.Add(khoahoc);
            }
            return list;
        }

        public DTO_khoa SelectByLopHoc(DTO_lop x)
        {
            string query = "SELECT * FROM khoahoc WHERE id = @id";
            DataTable dt = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] { x.Id });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                DTO_khoa khoahoc = new DTO_khoa
                {
                    Id = Convert.ToInt32(row["ID"]),
                    Tenkhoa = row["TenKhoa"].ToString(),
                };
                return khoahoc;
            }
            return null; 
        }
        //public DTO_khoahoc SelectByKyThi(DTO_kythi x)
        //{
        //    string query = "SELECT * FROM khoahoc join lophoc on khoahoc.id = lophoc.id_khoa join kythi on kythi.id_lop = lophoc.id where kythi.id = @x";
        //    DataTable dt = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] { x.ID });

        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow row = dt.Rows[0];
        //        DTO_khoahoc khoahoc = new DTO_khoahoc
        //        {
        //            ID = Convert.ToInt32(row["ID"]),
        //            TenKhoa = row["TenKhoa"].ToString(),
        //            // Gán các thuộc tính khác của DTO_khoahoc nếu có
        //        };
        //        return khoahoc;
        //    }
        //    return null; // Nếu không tìm thấy kết quả nào
        //}


        public bool InsertKhoaHoc(DTO_khoa khoaHoc)
        {
            string query = @"insert into khoahoc ( tenKhoa ) values ( @tenkhoa )";
            if (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { khoaHoc.Tenkhoa }) > 0) { return true; }
            else return false;
        }

        public bool UpdateKhoaHoc(DTO_khoa khoaHoc)
        {

            string query = @"UPDATE khoahoc SET tenkhoa = @tenkhoa WHERE id = @id";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { khoaHoc.Tenkhoa, khoaHoc.Id }) > 0);

        }
        public bool DeleteKhoaHoc(DTO_khoa khoaHoc)
        {
            string query = @"delete khoahoc where id = @id";
            if (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { khoaHoc.Id }) > 0) { return true; }
            else return false;
        } 
    }
}
