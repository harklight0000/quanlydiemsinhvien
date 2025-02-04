using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    public class DTO_ketqua
    {
        int id;
        string masinhvien;
        int id_thi;
        float diem;

        public DTO_ketqua()
        {
        }

        public DTO_ketqua(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Masinhvien = row["masinhvien"].ToString();
            this.Id_thi = (int)row["id_thi"];
            this.Diem = (float)Convert.ToDouble(row["diem"]);
        }

        public int Id { get => id; set => id = value; }
        public string Masinhvien { get => masinhvien; set => masinhvien = value; }
        public int Id_thi { get => id_thi; set => id_thi = value; }
        public float Diem { get => diem; set => diem = value; }
    }
}
