using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    public class DTO_sinhvien
    {
        string masinhvien;
        string tensinhvien;
        DateTime ngaysinh;
        int id_lophoc;
        public DTO_sinhvien(DataRow dataRow)
        {
            this.Masinhvien = dataRow["masinhvien"].ToString();
            this.Tensinhvien = dataRow["tensinhvien"].ToString();
            this.Ngaysinh = (DateTime)dataRow["ngaysinh"];
            this.Id_lophoc = (int)dataRow["id_lophoc"];
        }
        public DTO_sinhvien()
        {
        }
        public string Masinhvien { get => masinhvien; set => masinhvien = value; }
        public string Tensinhvien { get => tensinhvien; set => tensinhvien = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public int Id_lophoc { get => id_lophoc; set => id_lophoc = value; }
    }
}
