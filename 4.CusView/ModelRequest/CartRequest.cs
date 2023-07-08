using _1_API.ViewModel.SanphamChitiet;
using _2.API.ViewModel.GioHangChiTiet;

namespace _4.CusView.ModelRequest
{
    public class CartRequest
    {
        public string? message { get; set; }
        public int error { get; set; }
        public List<ViewGioHangChiTiet>? data { get; set; }
        public int numberOfItems { get; set; }
        public decimal totalPriceOfItems { get; set; }
    }
}
