using HumanResourcesApp.Domain.Entities;
using HumanResourcesApp.Domain.Enums;
using HumanResourcesApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesApp.MVC.Models.SeedDataFolder
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HRDbContext>();
            dbContext.Database.Migrate();

            if (dbContext.Companies.Count() == 0)
            {
                dbContext.Companies.Add(new Company()
                {
                    Id="1",
                    Name="HrBasic"
                });
            }
            if(dbContext.Companies.Count() == 0)
            {
                dbContext.Managers.Add(new Manager()
                {
                    Id = "2",
                    Name = "Murat",
                    SecondName = "Mustafa",
                    Surname = "Yeken",
                    SecondSurname = "",
                    ImageUrl = "/assets/img/profile-img.jpg",
                    DateOfBirth = DateTime.Now,
                    PlaceOfBirth = "İzmir",
                    IdentityNumber = "35353535353",
                    DateOfRecruitment = DateTime.Now,
                    Occupation = "Software Developer",
                    Department = "Test",
                    Address = "Göztepe",
                    PhoneNumber = "9999999",
                    CompanyId = "1",
                    Email = "murat.yeken@hrbasic.com",
                    CreatedDate = DateTime.Now,
                    Status = Status.Active,

                });
            }
                

                dbContext.SaveChanges();
            
        }
    }
}
