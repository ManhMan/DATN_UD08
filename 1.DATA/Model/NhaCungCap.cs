using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class NhaCungCap
    {
        public NhaCungCap() { phieuNhaps = new HashSet<PhieuNhap>(); }
        public Guid Id { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public int? TrangThai { get; set; }
        public ICollection<PhieuNhap> phieuNhaps { get; set; }
    }
}
