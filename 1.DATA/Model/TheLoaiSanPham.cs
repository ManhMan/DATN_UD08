using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class TheLoaiSanPham : Entity
    {
        public Guid IdTheLoai { get; set; }
        public Guid IdChiTietSP { get; set; }
        public TheLoai? theLoai { get; set; }
        public SanPhamChiTiet? sanphamChitiet { get; set; }
    }
}
