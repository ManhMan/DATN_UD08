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
    public class TheloaiSanphamConfiguration : IEntityTypeConfiguration<TheLoaiSanPham>
    {
        public void Configure(EntityTypeBuilder<TheLoaiSanPham> builder)
        {
            builder.ToTable("TheLoaiSanPham");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdTheLoai).IsRequired();
            builder.Property(x => x.IdChiTietSP).IsRequired();
            builder.HasOne(x => x.theLoai).WithMany(x => x.theloaiSanPhams).HasForeignKey(x => x.IdTheLoai);
            builder.HasOne(x => x.sanphamChitiet).WithMany(x => x.theLoaiSanPhams).HasForeignKey(x => x.IdChiTietSP);
        }
    }
}
