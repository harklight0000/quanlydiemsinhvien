using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.BUS
{
    public class BUS_mon
    {
        private static BUS_mon Instance;
        public static BUS_mon GetInstance { get { if (Instance == null) Instance = new BUS_mon(); return BUS_mon.Instance; } }
        public bool Add(DTO_mon x) { return DAL.DAL_mon.GetInstance.Insert(x); }
        public bool Edit(DTO_mon x) { return DAL.DAL_mon.GetInstance.Update(x); }
        public bool Delete(DTO_mon x) { return DAL.DAL_mon.GetInstance.Delete(x); }
        public List<DTO_mon> GetAll() { return DAL.DAL_mon.GetInstance.GetAll(); }
            
    }
}
