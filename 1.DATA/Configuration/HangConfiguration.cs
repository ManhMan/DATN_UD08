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
    public class HangConfiguration : IEntityTypeConfiguration<Hang>
    {
        public void Configure(EntityTypeBuilder<Hang> builder)
        {
            builder.ToTable("Hang");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenHang).IsRequired();
        }
    }
}
