using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class PhieuNhap : Entity
    {
        public PhieuNhap()
        {
            chiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }
        public Guid? IdNhaCungCap { get; set; }
        public string? MaPhieuNhap { get; set; }
        public int? TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public NhaCungCap? nhaCungCap { get; set; }
        public User? nhanVien { get; set; }
        public ICollection<ChiTietPhieuNhap> chiTietPhieuNhaps { get; set; }
    }
}
