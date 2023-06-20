using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class MauSac : Entity
    {
        public MauSac()
        {
            sanphamChitiets = new HashSet<SanPhamChiTiet>();
        }
        public string? TenMau { get; set; }
        public virtual ICollection<SanPhamChiTiet> sanphamChitiets { get; set; }
    }
}
