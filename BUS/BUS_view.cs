using quanlydiemsinhvien.DAL;
using quanlydiemsinhvien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.BUS
{
    public class BUS_view
    {
        private static BUS_view Instance;
        public static BUS_view GetInstance { get { if (Instance == null) Instance = new BUS_view(); return BUS_view.Instance; } }
        public List<DTO_viewLop> GetAllViewLop() { return DAL.DAL_view.GetInstance.GetAllViewLop(); }
        public List<DTO_viewThi> GetAllViewThi() { return DAL_view.GetInstance.GetAllViewThi(); }
        public List<DTO_viewKetqua> GetAllViewKetqua(DTO_viewThi x) { return DAL_view.GetInstance.GetAllViewKetqua(x); }
        public List<DTO_rpDiemSv> getRpDiemSv(DTO_sinhvien x) { return DAL_view.GetInstance.getRpdiemsv(x); }
        public    List<DTO_rpTtsv> GetRpTtsvs(DTO_sinhvien x) { return DAL_view.GetInstance.getrpTts(x); }   
    }
}
