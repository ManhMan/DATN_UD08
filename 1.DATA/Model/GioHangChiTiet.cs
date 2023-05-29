using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class GioHangChiTiet
    {
        public Guid Id { get; set; }
        public Guid IdSPChitiet { get; set; }
        public Guid? IdGioHang { get; set; }
        public Guid? IdSize { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }
        public SanphamChitiet? sanphamChitiet { get; set; }
        public GioHang? gioHang { get; set; }
        public Size size { get; set; }
    }
}
