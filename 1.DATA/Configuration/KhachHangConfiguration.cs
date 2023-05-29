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
    public class KhachhangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KhachHang");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ten).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.MatKhau).IsRequired();
            builder.Property(x => x.DiaChi);
            builder.Property(x => x.GioiTinh);
            builder.Property(x => x.Sdt);
            builder.Property(x => x.NgaySinh);
        }
    }
}
