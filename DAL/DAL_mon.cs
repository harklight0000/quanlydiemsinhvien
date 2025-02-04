using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_mon
    {
        private static DAL_mon Instance;
        public static DAL_mon GetInstance { get { if (Instance == null) Instance = new DAL_mon(); return DAL_mon.Instance; } }
        public bool Insert(DTO_mon x) { 
            string query = @"insert into monhoc ( mamonhoc , tenmonhoc ,  hocky , sogiolt , sogioth , id_nganhhoc ) values ( @mamonhoc , @tenmonhoc  , @hocky , @sogiolt  , @sogioth  , @id_nganhhoc ) ";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] {x.Mamonhoc, x.Tenmonhoc, x.Hocky, x.Sogiolt, x.Sogioth ,x.Id_nganhhoc}) > 0) ; 
        }
        public bool Update(DTO_mon x) 
        { 
            string query = @"UPDATE monhoc SET tenmonhoc = @tenmonhoc  , hocky = @hocky ,  sogiolt = @sogiolt , sogioth  = @sogioth , id_nganhhoc = @id_nganhhoc WHERE mamonhoc = @mamonhoc";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] {x.Tenmonhoc, x.Hocky, x.Sogiolt,x.Sogioth, x.Id_nganhhoc, x.Mamonhoc}) > 0); 
        }
        public bool Delete(DTO_mon x) 
        {
            string query = @"delete from monhoc where mamonhoc = @mamonhoc";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] {x.Mamonhoc}) > 0); 
        }
        public List<DTO.DTO_mon> GetAll() 
        {
            var list = new List<DTO_mon>();
            string query = @"select * from monhoc";
            var dt = DAL_dataprovider.GetInstance.ExecuteQuery(query);
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                var x = new DTO_mon(dr);
                list.Add(x);
            }
            return list;
           
        }
    }
}
