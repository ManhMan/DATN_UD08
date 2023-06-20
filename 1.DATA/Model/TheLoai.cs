using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class TheLoai : Entity
    {
        public TheLoai()
        {
            theloaiSanPhams = new HashSet<TheLoaiSanPham>();
        }

        public string? TenTheLoai { get; set; }
        public virtual ICollection<TheLoaiSanPham> theloaiSanPhams { get; set; }
    }
}
