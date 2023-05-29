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
    public class HinhAnhConfiguration : IEntityTypeConfiguration<HinhAnh>
    {
        public void Configure(EntityTypeBuilder<HinhAnh> builder)
        {
            builder.ToTable("HinhAnh");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdSPCT);
            builder.Property(x => x.LinkAnh).IsRequired();
            builder.HasOne(x => x.sanPhamChiTiet).WithMany(x => x.hinhAnhs).HasForeignKey(x => x.IdSPCT);
        }
    }
}
