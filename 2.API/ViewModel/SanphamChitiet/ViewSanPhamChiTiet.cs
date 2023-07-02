using _1.DATA.Model;
using _1_API.ViewModel.SizeSanPham;
using System.ComponentModel.DataAnnotations;

namespace _1_API.ViewModel.SanphamChitiet
{
    public class ViewSanPhamChiTiet
    {
        public Guid Id { get; set; }
        public decimal? GiaBan { get; set; }
        public string? TrangThai { get; set; }
        public string? TenMauSac { get; set; }
        public string? MaSPChiTiet { get; set; }
        public string? TenSPChiTiet { get; set; }
        public string? AnhDaiDien { get; set; }
    }
    public class ViewChiTietSanPhamChiTiet
    {
        public Guid idsqct { get; set; }
        public decimal giaban { get; set; }
        public string? ten { get; set; }
        public string? mausac { get; set; }
        public List<SizeSanPhamModel>? lstsize { get; set; }
        public List<ListImage>? lstanh { get; set; }
    }
    public class ListImage
    {
        public string? linkAnh { get; set; }
    }
}
