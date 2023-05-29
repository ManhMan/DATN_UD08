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
    public class SizeSanPhamConfiguration : IEntityTypeConfiguration<SizeSanPham>
    {
        public void Configure(EntityTypeBuilder<SizeSanPham> builder)
        {
            builder.ToTable("SizeSanPham");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoLuong).IsRequired();
            builder.Property(x => x.IdSanPhamChiTiet).IsRequired();
            builder.Property(x => x.IdSize).IsRequired();

            builder.HasOne(x => x.SanPhamChitiet).WithMany(x => x.SizeSanPhams).HasForeignKey(x => x.IdSanPhamChiTiet);
            builder.HasOne(x => x.Size).WithMany(x => x.SizeSanPhams).HasForeignKey(x => x.IdSize);
        }
    }
}
