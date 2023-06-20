using _1.DATA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Configuration
{
    public class NhaCungCapConfiguration : IEntityTypeConfiguration<NhaCungCap>
    {
        public void Configure(EntityTypeBuilder<NhaCungCap> builder)
        {
            builder.ToTable("NhaCungCap");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ten);
            builder.Property(x => x.DiaChi);
            builder.Property(x => x.Sdt);
            builder.Property(x => x.TrangThai);
        }
    }
}
