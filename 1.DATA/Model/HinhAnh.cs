using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class HinhAnh : Entity
    {
        public Guid IdSPCT { get; set; }
        public string? LinkAnh { get; set; }
        public bool? TrangThai { get; set; }
        public SanPhamChiTiet? sanPhamChiTiet { get; set; }
    }
}
