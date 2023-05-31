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
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable("Entity");  
            builder.HasKey(x=>x.CreateBy);

            builder.Property(x=>x.CreateBy).IsRequired();
            builder.Property(x => x.UpdateBy);
            builder.Property(x => x.DeleteBy);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.UpdateDate);
            builder.Property(x => x.DeleteDate);
            builder.Property(x => x.isDelete);
        }
    }
}
