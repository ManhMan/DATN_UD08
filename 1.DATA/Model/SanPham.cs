using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class SanPham : Entity
    {
        public SanPham()
        {
            sanphamChitiets = new HashSet<SanPhamChiTiet>();
        }
        public string? Ten { get; set; }
        public Guid IdHang { get; set; }
        public int TrangThai { get; set; }
        public Hang? hang { get; set; }
        public virtual ICollection<SanPhamChiTiet> sanphamChitiets { get; set; }
    }
}
