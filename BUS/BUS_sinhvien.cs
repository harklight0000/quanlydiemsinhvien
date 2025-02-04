using quanlydiemsinhvien.DAL;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.BUS
{
    public class BUS_sinhvien
    {
        private static BUS_sinhvien Instance;
        public static BUS_sinhvien GetInstance { get { if (Instance == null) Instance = new BUS_sinhvien(); return BUS_sinhvien.Instance; } }
        public bool Add(DTO_sinhvien x) { return DAL_sinhvien.GetInstance.Insert(x); }
        public bool Edit(DTO_sinhvien x) { return DAL_sinhvien.GetInstance.Update(x); }
        public bool Delete(DTO_sinhvien x) { return DAL_sinhvien.GetInstance.Delete(x); }

    }
}
