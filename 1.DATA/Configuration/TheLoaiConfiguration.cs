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
    public class TheloaiConfiguration : IEntityTypeConfiguration<TheLoai>
    {
        public void Configure(EntityTypeBuilder<TheLoai> builder)
        {
            builder.ToTable("TheLoai");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenTheLoai).IsRequired();
        }
    }
}
