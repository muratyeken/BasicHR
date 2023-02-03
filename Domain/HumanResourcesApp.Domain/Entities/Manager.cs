using HumanResourcesApp.Domain.Abstract;
using HumanResourcesApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Domain.Entities
{
    public class Manager :IBaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfRecruitment { get; set; }
        public string Occupation { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Company Company { get; set; }
        public string CompanyId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get ; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }
        
    }
}
