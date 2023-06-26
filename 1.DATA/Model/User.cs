using Microsoft.AspNetCore.Identity;

namespace _1.DATA.Model
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            hoaDons = new HashSet<HoaDon>();
            PhieuNhaps = new HashSet<PhieuNhap>();
        }

        public Guid? IdGuiBaoCao { get; set; }
        public string? Ten { get; set; }
        public string? MaNV { get; set; }
        public string? AnhNhanVien { get; set; }
        public bool? GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public int? TrangThai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public virtual ICollection<HoaDon> hoaDons { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}