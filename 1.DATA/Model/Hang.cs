using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class Hang : Entity
    {
        public Hang()
        {
            sanPhams = new HashSet<SanPham>();
        }

        public string? TenHang { get; set; }
        public virtual ICollection<SanPham> sanPhams { get; set; }

    }
}
