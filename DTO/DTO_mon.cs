using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    public class DTO_mon
    {
        string mamonhoc;
        string tenmonhoc;
        int sogioth;
        int sogiolt;
        int hocky;
        int id_nganhhoc;
        public DTO_mon() { }
        public DTO_mon(DataRow dr)
        {
            this.Mamonhoc = dr["mamonhoc"].ToString();
            this.Tenmonhoc = dr["tenmonhoc"].ToString();
            this.Sogioth = (int)dr["sogioth"];
            this.Sogiolt = (int)dr["sogiolt"];
            this.Hocky = (int)dr["hocky"];
            this.Id_nganhhoc = (int)dr["id_nganhhoc"];
        }

        public string Mamonhoc { get => mamonhoc; set => mamonhoc = value; }
        public string Tenmonhoc { get => tenmonhoc; set => tenmonhoc = value; }
        public int Sogioth { get => sogioth; set => sogioth = value; }
        public int Sogiolt { get => sogiolt; set => sogiolt = value; }
        public int Hocky { get => hocky; set => hocky = value; }
        public int Id_nganhhoc { get => id_nganhhoc; set => id_nganhhoc = value; }
    }
}
