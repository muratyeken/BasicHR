using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Application.Models.DTOs
{
    public class ListOfManagerDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Occupation { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
