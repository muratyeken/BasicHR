using AutoMapper;
using HumanResourcesApp.Application.Models.DTOs;
using HumanResourcesApp.Application.Models.VMs;
using HumanResourcesApp.Domain.Entities;
using HumanResourcesApp.Domain.Enums;
using HumanResourcesApp.Domain.Repositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;

namespace HumanResourcesApp.Application.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly IManagerRepo _managerRepo;

        public ManagerService(IMapper mapper, IManagerRepo managerRepo)
        {
            _mapper = mapper;
            _managerRepo = managerRepo;
        }

        public async Task<UpdateManagerVM> GetManager(string id)
        {
            var manager = await _managerRepo.GetFilteredFirstOrDefault(
                select: x => new UpdateManagerDTO
                {
                    Id = x.Id,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    ImageUrl = x.ImageUrl,
                },
                where: x => x.Id == id);

            var updateManagerVM = _mapper.Map<UpdateManagerVM>(manager);
            return updateManagerVM;
        }

       

        //public async Task<List<ListOfManagerDTO>> GetManagers()
        //{
        //    var managers = await _managerRepo.GetFilteredList(
        //        select: x => new ListOfManagerDTO
        //        {
        //            Id = x.Id,
        //            Address = x.Address,
        //            PhoneNumber = x.PhoneNumber,
        //            ImageUrl = x.ImageUrl,
        //            Occupation = x.Occupation,
        //            Department = x.Department,
        //            Email = x.Email,
        //            Name = x.Name,
        //            SecondName = x.SecondName,
        //            Surname = x.Surname,
        //            SecondSurname = x.SecondSurname,
        //        },
        //        where: x => (x.Status == Status.Active || x.Status == Status.Modified)
        //        );
        //    return managers;
        //}

        public async Task<ListOfManagerDTO> GetManagerOverview()
        {
            var manager = await _managerRepo.GetFilteredFirstOrDefault(
                select: x => new ListOfManagerDTO
                {
                    Id = x.Id,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    ImageUrl = x.ImageUrl,
                    Occupation = x.Occupation,
                    Department = x.Department,
                    Email = x.Email,
                    Name = x.Name,
                    SecondName = x.SecondName,
                    Surname = x.Surname,
                    SecondSurname = x.SecondSurname,
                },
                where: x => (x.Status == Status.Active || x.Status == Status.Modified)
                );
            return manager;
        }

        public async Task UpdateManager(UpdateManagerVM updateManagerVM)
        {

            var model = await _managerRepo.GetDefault(x => x.Id == updateManagerVM.Id);
            model.Address = updateManagerVM.Address;
            model.PhoneNumber = updateManagerVM.PhoneNumber;
            model.UpdatedDate = updateManagerVM.UpdatedDate;
            model.Status = updateManagerVM.Status;

            using var image = Image.Load(updateManagerVM.PictureFile.OpenReadStream());
            image.Mutate(x => x.Resize(600, 560));
            Guid guid = Guid.NewGuid();
            image.Save($"wwwroot/assets/img/{guid}.jpg");
            model.ImageUrl = ($"/assets/img/{guid}.jpg");

            await _managerRepo.Update(model);


        }

        public async Task<ListOfDetailedManagerDTO> GetDetailedManager(string id)
        {
            var detailedManager = await _managerRepo.GetFilteredFirstOrDefault(
                select: x => new ListOfDetailedManagerDTO
                {
                    Id = x.Id,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,


                    Name = x.Name,
                    SecondName = x.SecondName,
                    Surname = x.Surname,
                    SecondSurname = x.SecondSurname,
                    DateOfBirth = x.DateOfBirth,
                    PlaceOfBirth = x.PlaceOfBirth,
                    IdentityNumber = x.IdentityNumber,
                    DateOfRecruitment = x.DateOfRecruitment,
                    Occupation = x.Occupation,
                    Company = x.Company,
                    Email=x.Email,   
                    Department=x.Department,
    },
                where: x => x.Id == id);

            var listedManager = _mapper.Map<ListOfDetailedManagerDTO>(detailedManager);
            return listedManager;
        }
    }
}
