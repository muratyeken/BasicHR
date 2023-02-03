using HumanResourcesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Infrastructure.EntityTypeConfiguration
{
    public class CompanyTypeConfig:BaseEntityTypeConfig<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.HasMany(x => x.Managers).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
