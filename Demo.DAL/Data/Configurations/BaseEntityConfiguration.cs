using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Data.Configurations
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.Id).UseIdentityColumn(10, 10);
            builder.Property(b => b.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
