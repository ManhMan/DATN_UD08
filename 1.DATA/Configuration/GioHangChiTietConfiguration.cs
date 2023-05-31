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
    public class GiohangChitietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.ToTable("GiohangChitiet");

            builder.HasKey(x => x.IdGioHang);
            builder.Property(x => x.SoLuong).IsRequired();

            builder.HasOne(x => x.sanphamChitiet).WithMany(x => x.giohangChitiets).HasForeignKey(x => x.IdSPChitiet);
            builder.HasOne(x => x.gioHang).WithMany(x => x.giohangChitiets).HasForeignKey(x => x.IdGioHang);
            builder.HasOne(x => x.size).WithMany(x => x.giohangChitiets).HasForeignKey(x => x.IdSize);
        }
    }
}
