using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DTO
{
    public class DTO_thi
    {
        int? id;
        string mamonhoc;
        int? id_lophoc;
        DateTime? ngaythi;
        string hinhthuc;
        int? lanthi;

        public DTO_thi()
        {
        }

        public DTO_thi(DataRow dataRow)
        {
            this.Id = dataRow["id"] != DBNull.Value ? (int?)dataRow["id"] : null;
            this.Mamonhoc = dataRow["mamonhoc"] != DBNull.Value ? dataRow["mamonhoc"].ToString() : string.Empty;
            this.Id_lophoc = dataRow["id_lophoc"] != DBNull.Value ? (int?)dataRow["id_lophoc"] : null;
            this.Ngaythi = dataRow["ngaythi"] != DBNull.Value ? (DateTime?)dataRow["ngaythi"] : null;
            this.Hinhthuc = dataRow["hinhthuc"] != DBNull.Value ? dataRow["hinhthuc"].ToString() : string.Empty;
            this.Lanthi = dataRow["lanthi"] != DBNull.Value ? (int?)dataRow["lanthi"] : null;
        }

        public int? Id { get => id; set => id = value; }
        public string Mamonhoc { get => mamonhoc; set => mamonhoc = value; }
        public int? Id_lophoc { get => id_lophoc; set => id_lophoc = value; }
        public DateTime? Ngaythi { get => ngaythi; set => ngaythi = value; }
        public string Hinhthuc { get => hinhthuc; set => hinhthuc = value; }
        public int? Lanthi { get => lanthi; set => lanthi = value; }

    }
}
