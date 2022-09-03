using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnType("datetime");

            builder.Property(x => x.SurName).IsRequired().HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Password).IsRequired().HasColumnType("nvarchar(MAX)");
        }
    }
}
