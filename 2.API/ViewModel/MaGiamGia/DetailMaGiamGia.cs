﻿namespace _1_API.ViewModel.MaGiamGia
{
    public class DetailMaGiamGia
    {
        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public DateTime? NgayBatdau { get; set; }
        public DateTime? NgayKetthuc { get; set; }
        public int? SoLuong { get; set; }
        public int? TrangThai { get; set; }
        public int? PhanTramGiam { get; set; }
    }
}
