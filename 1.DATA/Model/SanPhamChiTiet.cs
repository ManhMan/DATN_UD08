﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class SanPhamChiTiet
    {
        public SanPhamChiTiet()
        {
            giohangChitiets = new HashSet<GioHangChiTiet>();
            hoadonChitiets = new HashSet<HoaDonChiTiet>();
            hinhAnhs = new HashSet<HinhAnh>();
            theLoaiSanPhams = new HashSet<TheLoaiSanPham>();
            SizeSanPhams = new HashSet<SizeSanPham>();
        }

        public Guid Id { get; set; }
        public Guid? IdSP { get; set; }
        public Guid? IdMauSac { get; set; }
        public string? TenSPChiTiet { get; set; }
        public string? MaSPChiTiet { get; set; }
        public DateTime? NgayTao { get; set; }

        public decimal? GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int? TrangThai { get; set; }


        public SanPham? sanPham { get; set; }
        public MauSac? mauSac { get; set; }

        public virtual ICollection<GioHangChiTiet> giohangChitiets { get; set; }
        public virtual ICollection<HoaDonChiTiet> hoadonChitiets { get; set; }
        public virtual ICollection<HinhAnh> hinhAnhs { get; set; }
        public virtual ICollection<TheLoaiSanPham> theLoaiSanPhams { get; set; }
        public virtual ICollection<SizeSanPham> SizeSanPhams { get; set; }
    }
}
