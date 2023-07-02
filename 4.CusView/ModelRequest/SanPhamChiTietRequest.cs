using _1_API.ViewModel.SanphamChitiet;

namespace _4.CusView.ModelRequest
{
    public class SanPhamChiTietRequest
    {
        public string? message { get; set; }
        public int error { get; set; }
        public List<ViewSanPhamChiTiet>? data { get; set; }

    }
    public class ChiTietSanPhamChiTietRequest
    {
        public string? message { get; set; }
        public int error { get; set; }
        public ViewChiTietSanPhamChiTiet? data { get; set; }
    }
}
