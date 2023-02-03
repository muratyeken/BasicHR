using HumanResourcesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Infrastructure.EntityTypeConfiguration
{
    public class ManagerTypeConfig:BaseEntityTypeConfig<Manager>
    {
        public override void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);


            base.Configure(builder);
        }
    }
}
