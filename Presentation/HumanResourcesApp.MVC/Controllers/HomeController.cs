using FluentValidation;
using FluentValidation.AspNetCore;
using HumanResourcesApp.Application.Models.VMs;
using HumanResourcesApp.Application.Services;
using HumanResourcesApp.Domain.Entities;
using HumanResourcesApp.Domain.Repositories;
using HumanResourcesApp.Infrastructure.Context;
using HumanResourcesApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace HumanResourcesApp.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IManagerService _managerService;
        private readonly IValidator<UpdateManagerVM> _phoneValidation;
        public HomeController(ILogger<HomeController> logger, IManagerService managerService, IValidator<UpdateManagerVM> phoneValidation)
        {
            _logger = logger;
            _managerService = managerService;
            _phoneValidation = phoneValidation;
        }

        public async Task<IActionResult> Index()
        {

            var manager = await _managerService.GetManagerOverview();
            return View(manager);
        }

        public async Task<IActionResult> UpdateManager(string id)
        {

            var updateManager = await _managerService.GetManager(id);
            return View(updateManager);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateManager(UpdateManagerVM updateManagerVM)
        {
            ValidationResult results = await _phoneValidation.ValidateAsync(updateManagerVM);

            ModelState.Remove("ImageUrl");
            if (ModelState.IsValid)
            {
                if (!results.IsValid)
                {
                    results.AddToModelState(this.ModelState);
                    return View(updateManagerVM);
                }
                await _managerService.UpdateManager(updateManagerVM);
                return RedirectToAction(nameof(Index));
            }
            return View(updateManagerVM);
        }
        public async Task<IActionResult> Details(string id)
        {
            var detailedManager = await _managerService.GetDetailedManager(id);
            return View(detailedManager);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}