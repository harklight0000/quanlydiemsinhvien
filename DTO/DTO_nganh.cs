using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    public class DTO_nganh
    {
        int id;
        string tennganhhoc;
        int id_khoahoc;

        public DTO_nganh()
        {
        }

        public DTO_nganh(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Tennganhhoc = row["tennganhhoc"].ToString();
            this.Id_khoahoc = (int)row["id_khoahoc"];
        }

        public int Id { get => id; set => id = value; }
        public string Tennganhhoc { get => tennganhhoc; set => tennganhhoc = value; }
        public int Id_khoahoc { get => id_khoahoc; set => id_khoahoc = value; }
    }
}
