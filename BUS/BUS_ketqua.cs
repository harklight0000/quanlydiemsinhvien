using quanlydiemsinhvien.DAL;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.BUS
{
    public class BUS_ketqua
    {
        private static BUS_ketqua Instance;
        public static BUS_ketqua GetInstance { get { if (Instance == null) Instance = new BUS_ketqua(); return Instance; } }
        public bool Update(DTO_ketqua x) { return (DAL_ketqua.GetInstance.Update(x)); }
    }
}
