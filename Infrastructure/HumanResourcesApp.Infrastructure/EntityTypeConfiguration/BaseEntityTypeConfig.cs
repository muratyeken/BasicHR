using HumanResourcesApp.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Infrastructure.EntityTypeConfiguration
{
    public class BaseEntityTypeConfig<T> : IEntityTypeConfiguration<T> where T : class ,IBaseEntity
    {
        public virtual void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.DeletedDate).IsRequired(false);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);

        }
    }
}
