using _1.DATA.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Configuration
{
    public class ChiTietPhieuNhapConfiguration : IEntityTypeConfiguration<ChiTietPhieuNhap>
    {
        public void Configure(EntityTypeBuilder<ChiTietPhieuNhap> builder)
        {
            builder.ToTable("ChiTietPhieuNhap");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GiaNhap).IsRequired();
            builder.Property(x => x.SoLuong).IsRequired();

            builder.HasOne(x => x.phieuNhap).WithMany(x => x.chiTietPhieuNhaps).HasForeignKey(x => x.IdPhieuNhap);
            builder.HasOne(x => x.sanPhamChiTiet).WithMany(x => x.ChiTietPhieuNhaps).HasForeignKey(x => x.IdSPCT);
            builder.HasOne(x => x.size).WithMany(x => x.ChiTietPhieuNhaps).HasForeignKey(x => x.IdSize);
            //builder.HasOne(x=>x.)

        }
    }
}
