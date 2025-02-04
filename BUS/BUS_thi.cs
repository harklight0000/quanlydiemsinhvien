using quanlydiemsinhvien.DAL;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.BUS
{
    public class BUS_thi
    {
        private static BUS_thi Instance;
        public static BUS_thi GetInstance {get {if (Instance == null) Instance = new BUS_thi(); return Instance; } }
        public bool InsertThilan1(DTO_thi x) { return DAL_thi.GetInstance.Insert1(x); }
        public bool InsertThilan2(DTO_thi x) { return DAL_thi.GetInstance.Insert2(x); }
        public string InsertThilan2_x(DTO_thi x) { return DAL_thi.GetInstance._Insert2(x); }

        public List<DTO_thi> GetAll() { return  DAL_thi.GetInstance.GetAll();}
        public bool Edit(DTO_thi x) {  return DAL_thi.GetInstance.Edit(x); }
        public bool Delete(DTO_thi x) {return DAL_thi.GetInstance.Delete(x); }

    }
}
