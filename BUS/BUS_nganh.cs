using quanlydiemsinhvien.DAL;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.BUS
{
    public class BUS_nganh
    {
        private static BUS_nganh Instance;
        public static BUS_nganh GetInstance { get { if (Instance == null) Instance = new BUS_nganh(); return BUS_nganh.Instance; } }
        public bool Add(DTO_nganh x) { return DAL_nganh.GetInstance.Insert(x); }
        public bool Edit(DTO_nganh x) { return DAL_nganh.GetInstance.Update(x); }
        public bool Delete(DTO_nganh x) { return DAL_nganh.GetInstance.Delete(x); }
        public List<DTO_nganh> GetAll() { return DAL_nganh.GetInstance.GetAll(); }
    }
}
