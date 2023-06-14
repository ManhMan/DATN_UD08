using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class Size : Entity
    {
        public Size()
        {
            SizeSanPhams = new HashSet<SizeSanPham>();
            giohangChitiets = new HashSet<GioHangChiTiet>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }
        public float KichCo { get; set; }
        public virtual ICollection<SizeSanPham> SizeSanPhams { get; set; }
        public virtual ICollection<GioHangChiTiet> giohangChitiets { get; set; }
        public virtual ICollection<HoaDonChiTiet> hoadonChitiets { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
