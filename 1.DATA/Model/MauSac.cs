using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class MauSac
    {
        public MauSac()
        {
            sanphamChitiets = new HashSet<SanPhamChiTiet>();
        }
        public Guid Id { get; set; }
        public string? TenMau { get; set; }
        public virtual ICollection<SanPhamChiTiet> sanphamChitiets { get; set; }
    }
}
