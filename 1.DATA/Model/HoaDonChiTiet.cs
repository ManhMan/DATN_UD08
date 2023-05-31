using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class HoaDonChiTiet
    {
        public Guid? IdSPChitiet { get; set; }
        public Guid? IdHoaDon { get; set; }
        public Guid? IdSize { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaBan { get; set; }
        public SanPhamChiTiet? sanphamChitiet { get; set; }
        public HoaDon? hoaDon { get; set; }
        public Size? size { get; set; }
    }
}
