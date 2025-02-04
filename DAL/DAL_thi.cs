using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_thi
    {
        private static DAL_thi Instance;
        public static DAL_thi GetInstance {get{ if (Instance == null) Instance = new DAL_thi(); return Instance; } }
        //USP_InsertThiLan1   @i_idlop INT,   @i_mamonhoc NVARCHAR(100),   @i_hinhthuc NVARCHAR(100),   @i_ngaythi DATE 
        public bool Insert1(DTO_thi x)
        {
            string query = $"USP_InsertThiLan1 @i_idlop , @i_mamonhoc , @i_hinhthuc , @i_ngaythi";
            return DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] {x.Id_lophoc, x.Mamonhoc, x.Hinhthuc, x.Ngaythi}) > 0;
        }
        //USP_InsertThiLan2 @i_mamonhoc NVARCHAR(100),  @i_hinhthuc NVARCHAR(100),  @i_ngaythi DATE
        public bool Insert2(DTO_thi x)
        {
            string query = $"USP_InsertThiLan2 @i_mamonhoc , @i_hinhthuc , @i_ngaythi";
            return DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Mamonhoc, x.Hinhthuc, x.Ngaythi }) > 0;
        }
        public string _Insert2(DTO_thi x)
        {
            string query = $"USP_InsertThiLan2 @i_mamonhoc , @i_hinhthuc , @i_ngaythi";
            return DAL_dataprovider.GetInstance.ExecuteNonQuery2(query, new object[] { x.Mamonhoc, x.Hinhthuc, x.Ngaythi });
        }
        public List<DTO_thi> GetAll()
        {
            List<DTO_thi> list = new List<DTO_thi>();
            string query = $"select * from thi";
            DataTable dataTable = DAL_dataprovider.GetInstance.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows) { DTO_thi x = new DTO_thi(row); list.Add(x); }
            return list;
        }
        public bool Delete(DTO_thi x)
        {
            string query = $"delete from thi where id = @id";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Id }) > 0);

        }
        public bool Edit(DTO_thi x)
        {
            string query = $"update thi set  MaMonHoc = @MaMonHoc , ID_LopHoc = @ID_LopHoc , NgayThi = @NgayThi , HinhThuc = @HinhThuc where id = @id ";
            return (DAL_dataprovider.GetInstance.ExecuteNonQuery(query, new object[] { x.Mamonhoc, x.Id_lophoc, x.Ngaythi, x.Hinhthuc, x.Id }) > 0);
        }

   }


}
