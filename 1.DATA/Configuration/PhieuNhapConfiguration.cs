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
    public class PhieuNhapConfiguration : IEntityTypeConfiguration<PhieuNhap>
    {
        public void Configure(EntityTypeBuilder<PhieuNhap> builder)
        {
            builder.ToTable("PhieuNhap");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaPhieuNhap).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();
            builder.Property(x => x.GhiChu).IsRequired();

            builder.HasOne(x => x.nhaCungCap).WithMany(x => x.phieuNhaps).HasForeignKey(x => x.IdNhaCungCap);
            builder.HasOne(x => x.nhanVien).WithMany(x => x.PhieuNhaps).HasForeignKey(x => x.CreateByUserId);
        }
    }
}
