using quanlydiemsinhvien.DAL;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.BUS
{
    public class BUS_taikhoan
    {
        private static BUS_taikhoan Instance;
        public static BUS_taikhoan GetInstance { get { if (Instance == null) Instance = new BUS_taikhoan(); return BUS_taikhoan.Instance; } }
       
        private BUS_taikhoan() { }
        public DTO_taikhoan Login(DTO_taikhoan x) { return DAL_taikhoan.GetInstance.Login(x); }
      
    }
}
