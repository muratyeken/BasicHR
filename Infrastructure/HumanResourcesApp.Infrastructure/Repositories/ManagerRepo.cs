﻿using HumanResourcesApp.Domain.Entities;
using HumanResourcesApp.Domain.Repositories;
using HumanResourcesApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Infrastructure.Repositories
{
    public class ManagerRepo : BaseRepo<Manager>,IManagerRepo
    {
        public ManagerRepo(HRDbContext hrDbContext) : base(hrDbContext)
        {
        }
    }
}
