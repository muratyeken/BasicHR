using HumanResourcesApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Domain.Abstract
{
    public interface IBaseEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? DeletedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        Status Status { get; set; }



    }
}
