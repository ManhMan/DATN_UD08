using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class SizeSanPham : Entity
    {
        public Guid IdSanPhamChiTiet { get; set; }
        public Guid IdSize { get; set; }
        public int SoLuong { get; set; }
        public Size? Size { get; set; }
        public SanPhamChiTiet? SanPhamChitiet { get; set; }
    }
}
