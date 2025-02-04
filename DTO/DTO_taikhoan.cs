using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    public class DTO_taikhoan
    {
        int id;
        string tendangnhap;
        string matkhau;
        string quyen;
        string ghichu;

        public DTO_taikhoan()
        {
        }

        public DTO_taikhoan(DataRow row)
        {
            this.Id = (int)row["id"];
            this.TenDangNhap = row["tendangnhap"].ToString();
            this.Matkhau = row["matkhau"].ToString();
            this.Quyen = row["quyen"].ToString();
            this.Ghichu = row["ghichu"].ToString();
        }

        public int Id { get => id; set => id = value; }
        public string TenDangNhap { get => tendangnhap; set => tendangnhap = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
    }
}
