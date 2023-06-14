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
    public class HoadonChitietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoadonChitiet");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SoLuong).IsRequired();
            builder.Property(x => x.GiaBan).IsRequired();


            builder.HasOne(x => x.hoaDon).WithMany(x => x.hoadonChitiets).HasForeignKey(x => x.IdHoaDon);
            builder.HasOne(x => x.sanphamChitiet).WithMany(x => x.hoadonChitiets).HasForeignKey(x => x.IdSPChitiet);
            builder.HasOne(x => x.size).WithMany(x => x.hoadonChitiets).HasForeignKey(x => x.IdSize);
        }
    }
}
