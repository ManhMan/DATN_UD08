﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class HoaDon
    {
        public HoaDon()
        {
            hoadonChitiets = new HashSet<HoaDonChiTiet>();
        }

        public Guid Id { get; set; }
        public Guid? IdMaGiamGia { get; set; }
        public Guid? IdKH { get; set; }
        public Guid? IdNV { get; set; }
        public int? TrangThai { get; set; }
        public decimal? TongTien { get; set; }
        public string? DiaChi { get; set; }
        public string? GhiChu { get; set; }

        public MaGiamGia? maGiamGia { get; set; }
        public KhachHang? khachHang { get; set; }
        public NhanVien? nhanVien { get; set; }
        public virtual ICollection<HoaDonChiTiet> hoadonChitiets { get; set; }
    }
}
