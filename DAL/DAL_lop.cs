using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlydiemsinhvien.DTO;
namespace quanlydiemsinhvien.DAL
{
    public class DAL_lop
    {
        private static DAL_lop Instance;
        public static DAL_lop GetInstance { get { if (Instance == null) Instance = new DAL_lop(); return Instance; } }
        public List<DTO_lop> GetAll()
        {
            var list = new List<DTO_lop>();
            string query = @"select * from lophoc";
            var dt = DAL_dataprovider.GetInstance.ExecuteQuery(query);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                var lop = new DTO_lop(dr);
                list.Add(lop);
            }
            return list;
        }
        public bool Insert(DTO_lop x)
        {
            string query = @"insert into lophoc ( tenlop, id_nganhhoc ) values ( @tenlop , @id_nganhhoc ) ";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Tenlop, x.Id_nganhhoc }) > 0);
        }
        public bool Update(DTO_lop x)
        {
            string query = @"UPDATE lophoc SET tenlop = @tenlop , @id_nganhhoc  = id_nganhhoc WHERE id = @id";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Tenlop, x.Id_nganhhoc, x.Id }) > 0);
        }
        public bool Delete(DTO_lop x)
        {
            string query = @"delete from lophoc where id = @id";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Id }) > 0);

        }
    }
}
