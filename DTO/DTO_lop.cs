using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    public class DTO_lop
    {
        int id;
        string tenlop;
        int id_nganhhoc;
        public DTO_lop()
        {
        }
        public DTO_lop(DataRow dataRow)
        {
            this.Id = (int)dataRow["id"];
            this.Tenlop = dataRow["tenlop"].ToString();
            this.Id_nganhhoc = (int)dataRow["id_nganhhoc"];
        }

        public int Id { get => id; set => id = value; }
        public string Tenlop { get => tenlop; set => tenlop = value; }
        public int Id_nganhhoc { get => id_nganhhoc; set => id_nganhhoc = value; }
    }
}
