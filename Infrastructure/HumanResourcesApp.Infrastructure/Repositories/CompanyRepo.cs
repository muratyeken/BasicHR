using HumanResourcesApp.Domain.Entities;
using HumanResourcesApp.Domain.Repositories;
using HumanResourcesApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Infrastructure.Repositories
{
    public class CompanyRepo : BaseRepo<Company>, ICompanyRepo
    {
        public CompanyRepo(HRDbContext hrDbContext) : base(hrDbContext)
        {
        }
    }
}
