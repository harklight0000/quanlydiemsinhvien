using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_sinhvien
    {
        private static DAL_sinhvien Instance;
        public static DAL_sinhvien GetInstance { get { if (Instance == null) Instance = new DAL_sinhvien(); return Instance; } private set => Instance = value; }
        public List<DTO_sinhvien> GetByLop(DTO_lop lop)
        {
            List<DTO_sinhvien> list = new List<DTO_sinhvien>();
            string query = "select * from sinhvien where id_lophoc = @x";
            DataTable dataTable = DAL_dataprovider.GetInstance.ExecuteQuery(query, new object[] {lop.Id});
            foreach (DataRow item in dataTable.Rows)
            {
                DTO_sinhvien sv = new DTO_sinhvien(item);
                list.Add(sv);
            }
            return list;
        }
        public bool Insert(DTO_sinhvien x)
        {
            string query = @"insert into sinhvien ( tensinhvien , masinhvien , ngaysinh , id_lophoc ) values ( @tensinhvien , @masinhvien , @ngaysinh  , @id_lophoc ) ";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Tensinhvien, x.Masinhvien , x.Ngaysinh ,x.Id_lophoc }) > 0);
        }
        public bool Update(DTO_sinhvien x)
        {
            string query = @"update  sinhvien  set  tensinhvien = @tensinhvien , ngaysinh = @ngaysinh , id_lophoc = @id_lophoc where masinhvien = @masinhvien";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Tensinhvien, x.Ngaysinh, x.Id_lophoc , x.Masinhvien }) > 0);
        }
        public bool Delete(DTO_sinhvien x)
        {
            string query = @"delete from sinhvien where masinhvien = @masinhvien";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Masinhvien }) > 0);
        }

    }
}
