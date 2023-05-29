using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class HinhAnh
    {
        public Guid Id { get; set; }
        public Guid? IdSanPham { get; set; }
        public bool TrangThai { get; set; }
    }
}
