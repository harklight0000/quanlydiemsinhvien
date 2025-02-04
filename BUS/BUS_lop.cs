using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlydiemsinhvien.DAL;
using quanlydiemsinhvien.DTO;
namespace quanlydiemsinhvien.BUS
{
    public class BUS_lop
    {
        private static BUS_lop Instance;
        public static BUS_lop GetInstance { get { if (Instance == null) Instance = new BUS_lop(); return BUS_lop.Instance; } }
        public bool Add(DTO_lop x) { return DAL.DAL_lop.GetInstance.Insert(x); }
        public bool Edit(DTO_lop x) { return DAL.DAL_lop.GetInstance.Update(x); }
        public bool Delete(DTO_lop x) { return DAL.DAL_lop.GetInstance.Delete(x); }
        public List<DTO_lop> GetAll() { return DAL.DAL_lop.GetInstance.GetAll(); }

    }
}
