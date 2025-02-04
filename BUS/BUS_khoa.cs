using quanlydiemsinhvien.DAL;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.BUS
{
    public class BUS_khoa
    {
        private static BUS_khoa Instance;
        public static BUS_khoa GetInstance { get { if (Instance == null) Instance = new BUS_khoa(); return BUS_khoa.Instance; } }
        public bool Add(DTO_khoa x) { return DAL_khoa.GetInstance.InsertKhoaHoc(x); }

        public bool Edit(DTO_khoa x) { return DAL_khoa.GetInstance.UpdateKhoaHoc(x); }
        public bool Delete(DTO_khoa x) { return DAL_khoa.GetInstance.DeleteKhoaHoc(x); }
        public List<DTO_khoa> GetAll() { return DAL_khoa.GetInstance.GetAllKhoaHoc(); }
    }
}
