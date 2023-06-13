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
    public class SanphamChitietConfiguration : IEntityTypeConfiguration<SanPhamChiTiet>
    {
        public void Configure(EntityTypeBuilder<SanPhamChiTiet> builder)
        {
            builder.ToTable("SanphamChitiet");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdSP).IsRequired();
            builder.Property(x => x.IdMauSac).IsRequired();
            builder.Property(x => x.GiaBan).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();
            builder.Property(x => x.TenSPChiTiet).IsRequired();
            builder.Property(x => x.MaSPChiTiet).IsRequired();

            builder.HasOne(x => x.sanPham).WithMany(x => x.sanphamChitiets).HasForeignKey(x => x.IdSP);
            builder.HasOne(x => x.mauSac).WithMany(x => x.sanphamChitiets).HasForeignKey(x => x.IdMauSac);
            //builder.HasOne(x=>x.)

        }
    }
}
