using HumanResourcesApp.Application.Extensions;
using HumanResourcesApp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Application.Models.DTOs
{
    public class UpdateManagerDTO
    {
        public string Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        
        public IFormFile PictureFile { get; set; }
        public DateTime? UpdatedDate => DateTime.Now;
        public Status Status => Status.Modified;



    }
}
