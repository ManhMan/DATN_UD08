﻿namespace _1_API.ViewModel.HoaDon
{
    public class CreateHoaDon
    {
        public Guid Id { get; set; }
        public Guid? IdMaGiamGia { get; set; }
        public Guid IdKH { get; set; }
        public Guid? IdNV { get; set; }
        public int TrangThai { get; set; }
        public decimal TongTien { get; set; }
        public string? DiaChi { get; set; }
    }
}
