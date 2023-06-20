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
    public class HoadonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TrangThai).IsRequired();
            builder.Property(x => x.TongTien).IsRequired();
            builder.Property(x => x.DiaChi).IsRequired();
            builder.Property(x => x.IdNV);
            builder.Property(x => x.IdKH).IsRequired();

            builder.HasOne(x => x.maGiamGia).WithMany(x => x.hoaDons).HasForeignKey(x => x.IdMaGiamGia);
            builder.HasOne(x => x.khachHang).WithMany(x => x.hoaDons).HasForeignKey(x => x.IdKH);
            builder.HasOne(x => x.nhanVien).WithMany(x => x.hoaDons).HasForeignKey(x => x.IdNV);
        }
    }
}
