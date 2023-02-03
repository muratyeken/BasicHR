using HumanResourcesApp.Domain.Abstract;
using HumanResourcesApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Domain.Entities
{
    public class Company:IBaseEntity
    {
        public Company()
        {
            Managers = new List<Manager>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }

        public List<Manager> Managers { get; set; }

        
    }
}
