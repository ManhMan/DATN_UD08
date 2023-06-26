using _1.DATA.Configuration;
using _1.DATA.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.DatabaseContext
{
    public class BeeSneakerShopDbContext : IdentityDbContext<User,Role,Guid>
    {
        public BeeSneakerShopDbContext()
        {

        }
        public BeeSneakerShopDbContext(DbContextOptions<BeeSneakerShopDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // sửa cái này
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=DESKTOP-T4L1DE8\\SQLEXPRESS;Database=DATN_UD08_Database;Trusted_Connection=True;"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GiohangChitietConfiguration());
            modelBuilder.ApplyConfiguration(new GioHangConfiguration());
            modelBuilder.ApplyConfiguration(new HangConfiguration());
            modelBuilder.ApplyConfiguration(new HinhAnhConfiguration());
            modelBuilder.ApplyConfiguration(new HoadonChitietConfiguration());
            modelBuilder.ApplyConfiguration(new HoadonConfiguration());
            modelBuilder.ApplyConfiguration(new KhachhangConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new MagiamgiaConfiguration());
            modelBuilder.ApplyConfiguration(new MausacConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SanphamChitietConfiguration());
            modelBuilder.ApplyConfiguration(new SanphamConfiguration());
            modelBuilder.ApplyConfiguration(new SizeSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new TheloaiConfiguration());
            modelBuilder.ApplyConfiguration(new TheloaiSanphamConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietPhieuNhapConfiguration());
            modelBuilder.ApplyConfiguration(new PhieuNhapConfiguration());
            modelBuilder.ApplyConfiguration(new NhaCungCapConfiguration());
            //modelBuilder.Seed();
        }
        //dbset
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GiohangChitiets { get; set; }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoadonChitiets { get; set; }
        public DbSet<Size> KichCos { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<MaGiamGia> MaGiamGias { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<SanPhamChiTiet> SanphamChitiets { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<TheLoaiSanPham> TheLoaiSanPhams { get; set; }
        public DbSet<HinhAnh> HinhAnhs { get; set; }
        public DbSet<SizeSanPham> SizeSanPhams { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
    }
}
