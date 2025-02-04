using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    public class DTO_khoa
    {
        int id;
        string tenkhoa;

        public DTO_khoa()
        {
        }

        public DTO_khoa(DataRow row)
        {
            this.id = (int)row["id"];
            this.tenkhoa = row["tenkhoa"].ToString();
        }

        public int Id { get => id; set => id = value; }
        public string Tenkhoa { get => tenkhoa; set => tenkhoa = value; }
    }
}
