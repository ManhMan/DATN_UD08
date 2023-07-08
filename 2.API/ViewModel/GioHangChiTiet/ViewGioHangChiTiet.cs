namespace _2.API.ViewModel.GioHangChiTiet
{
    public class ViewGioHangChiTiet
    {
        public Guid Id { get; set; }
        public string AnhSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiHang { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
        public Guid idGiohang { get; set; }
        public Guid IdSPChitiet { get; set; }
        public Guid IdSize { get; set; }
    }
}
