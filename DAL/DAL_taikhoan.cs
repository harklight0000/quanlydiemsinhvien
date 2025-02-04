using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_taikhoan
    {
        private static DAL_taikhoan Instance;
        public static DAL_taikhoan GetInstance
        {
            get { if (Instance == null) Instance = new DAL_taikhoan(); return DAL_taikhoan.Instance; }
           
        }
        public List<DTO_taikhoan> GetAllTaiKhoan()
        {
            var list = new List<DTO_taikhoan>();
            string query = @"select * from taikhoan";
            DataTable dt = DAL_dataprovider.GetInstance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                var taikhoan = new DTO_taikhoan(dr);
                list.Add(taikhoan);
            }
            return list;
        }

        // Lấy tài khoản theo ID
        public DTO_taikhoan GetTaiKhoanById(int id)
        {
            string query = @"select * from taikhoan where id = @id";
            DataTable dt = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] { id });
            return dt.Rows.Count > 0 ? new DTO_taikhoan(dt.Rows[0]) : null;
        }

        // Thêm tài khoản
        public bool InsertTaiKhoan(DTO_taikhoan x)
        {
            string query = @"insert into taikhoan (TenDangNhap, MatKhau, Quyen) values (@TenDangNhap, @MatKhau, @Quyen)";
            int result = DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.TenDangNhap, x.Matkhau, x.Quyen });
            return result > 0;
        }

        // Cập nhật tài khoản
        public bool UpdateTaiKhoan(DTO_taikhoan x)
        {
            string query = @"update taikhoan set TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, Quyen = @Quyen where id = @id";
            int result = DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.TenDangNhap, x.Matkhau, x.Quyen, x.Id });
            return result > 0;
        }

        // Xóa tài khoản
        public bool DeleteTaiKhoan(int id)
        {
            string query = @"delete from taikhoan where id = @id";
            int result = DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }
        public DTO_taikhoan Login(DTO_taikhoan x)
        {
            string query = @"SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            DataTable dt = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] { x.TenDangNhap, x.Matkhau });
            if (dt.Rows.Count > 0)
            {
                return new DTO_taikhoan(dt.Rows[0]);
            }
            return null;
        }
    }
}
