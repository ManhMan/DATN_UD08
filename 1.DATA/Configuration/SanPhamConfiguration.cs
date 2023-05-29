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
    public class SanphamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPham");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ten).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();
            builder.Property(x => x.IdHang).IsRequired();

            builder.HasOne(x => x.hang).WithMany(x => x.sanPhams).HasForeignKey(x => x.IdHang);
        }
    }
}
