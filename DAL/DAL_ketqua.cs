using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_ketqua
    {
        private static DAL_ketqua Instance;
        public static DAL_ketqua GetInstance { get { if (Instance == null) Instance = new DAL_ketqua(); return Instance; } }
        public bool Update(DTO_ketqua x)
        {
            string query = @"UPDATE ketqua SET diem = @diem WHERE id = @id";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Diem, x.Id }) > 0);
        }
        //int id;
        //string masinhvien;
        //int id_thi;
        //float diem;
    }
}
