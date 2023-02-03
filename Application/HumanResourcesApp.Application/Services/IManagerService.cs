using HumanResourcesApp.Application.Models.DTOs;
using HumanResourcesApp.Application.Models.VMs;
using HumanResourcesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Application.Services
{
    public interface IManagerService
    {

        //Task<List<ListOfManagerDTO>> GetManagers();
        Task<UpdateManagerVM> GetManager(string id);

        Task UpdateManager(UpdateManagerVM updateManagerVM);

        Task<ListOfDetailedManagerDTO> GetDetailedManager(string id);

        Task<ListOfManagerDTO> GetManagerOverview();

        



    }
}
