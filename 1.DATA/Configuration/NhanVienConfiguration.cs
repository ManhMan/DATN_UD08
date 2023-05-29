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
    public class NhanvienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanVien");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ten).IsRequired();
            builder.Property(x => x.MaNV).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.MatKhau).IsRequired();
            builder.Property(x => x.Sdt).IsRequired();
            builder.Property(x => x.DiaChi);
            builder.Property(x => x.GioiTinh);
            builder.Property(x => x.AnhNhanVien);
            builder.Property(x => x.NgaySinh);
            builder.Property(x => x.IdCvu).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();
            builder.HasOne(x => x.chucVu).WithMany(x => x.nhanViens).HasForeignKey(x => x.IdCvu);
            builder.HasOne(x => x.IdGuiBcNavigation).WithMany(x => x.InverseIdGuiBcNavigation);
        }
    }
}
