using AutoMapper;
using HumanResourcesApp.Application.Models.DTOs;
using HumanResourcesApp.Application.Models.VMs;
using HumanResourcesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Application.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Manager, ListOfManagerDTO>().ReverseMap();
            CreateMap<Manager, UpdateManagerDTO>().ReverseMap();
            CreateMap<Manager, UpdateManagerVM>().ReverseMap();
            CreateMap<UpdateManagerVM, UpdateManagerDTO>().ReverseMap();
            CreateMap<Manager, ListOfDetailedManagerDTO>().ReverseMap();


        }
    }
}
