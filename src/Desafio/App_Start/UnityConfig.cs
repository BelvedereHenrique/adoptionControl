using Unity;
using Desafio.Models;
using System.Web.Mvc;
using Unity.Injection;
using Unity.AspNet.Mvc;
using System.Data.Entity;
using Desafio.Controllers;
using Desafio.Services.Animal;
using Desafio.Services.Adopter;
using Microsoft.AspNet.Identity;
using Desafio.Repository.Animal;
using Desafio.Services.Adoption;
using Desafio.Repository.Adopter;
using Desafio.Repository.Adoption;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Desafio
{
    public static class UnityConfig
    {

        public static void RegisterTypes()
        {
            var container = new UnityContainer();
            container.RegisterType<IAnimalService, AnimalService>();
            container.RegisterType<IAdoptionService, AdoptionService>();
            container.RegisterType<IAdopterService, AdopterService>();
            container.RegisterType<IAnimalRepository, AnimalRepository>();
            container.RegisterType<IAdoptionRepository, AdoptionRepository>();
            container.RegisterType<IAdopterRepository, AdopterRepository>();
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}