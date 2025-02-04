using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_nganh
    {
        private static DAL_nganh Instance;
        public static DAL_nganh GetInstance { get { if (Instance == null) Instance = new DAL_nganh(); return Instance; } }
        public List<DTO_nganh> GetAll()
        {
            var list = new List<DTO_nganh>();
            string query = @"select * from nganhhoc";
            var dt = DAL_dataprovider.GetInstance.ExecuteQuery(query);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                var nganh = new DTO_nganh(dr);
                list.Add(nganh);
            }
            return list;
        }
        public bool Insert(DTO_nganh x)
        {
            string query = @"insert into nganhhoc ( tennganhhoc, id_khoahoc ) values ( @tennganhhoc , @id_khoahoc ) ";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Tennganhhoc, x.Id_khoahoc }) > 0);
        }

        public bool Update(DTO_nganh x)
        {
            string query = @"UPDATE nganhhoc SET tennganhhoc = @tennganhhoc , @id_khoahoc  = id_khoahoc WHERE id = @id";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Tennganhhoc, x.Id_khoahoc , x.Id }) > 0);
        }
        public bool Delete(DTO_nganh x)
        {
            string query = @"delete from nganhhoc where id = @id";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Id }) > 0) ;
           
        }
    }
}
