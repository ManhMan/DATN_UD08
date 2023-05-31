using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class ChiTietPhieuNhap
    {
        public Guid Id { get; set; }
        public Guid? IdPhieuNhap { get; set; }
        public Guid? IdSPCT { get; set; }
        public Guid? IdSize { get; set; }
        public decimal GiaNhap { get; set; }
        public int SoLuong { get; set; }
        public PhieuNhap? phieuNhap { get; set; }
        public SanPhamChiTiet? sanPhamChiTiet { get; set; }
        public Size? size { get; set; }
    }
}
