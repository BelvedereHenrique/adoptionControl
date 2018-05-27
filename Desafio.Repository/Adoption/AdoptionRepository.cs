using System;
using System.Linq;
using Desafio.Contracts;
using System.Collections.Generic;
using Desafio.Repository.Context;

namespace Desafio.Repository.Adoption
{
    public class AdoptionRepository : IAdoptionRepository
    {
        public AdoptionContract Get(Guid animalID)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var animals = context.Animals.Where(x => x.AdoptedBy != null);
                    return null; 
                    //context.Adopters
                    //    .Where(x => animals.Any(y => y.AdoptedBy == x.ID))
                    //    .Select(x => new AdoptionContract()
                    //    {
                    //        Adopter = x,
                    //        Animals = animals.Where(z => z.AdoptedBy == x.ID).ToList()
                    //    }).First();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AdoptionContract> GetAll()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    return null;
                    ////var animals = .ToList();
                    //var adopters = context.Adopters.Where(x => context.Animals.Where(z => z.AdoptedBy != null).Any(y => y.AdoptedBy == x.ID)).ToList();
                    //var list = new List<AdoptionContract>();
                    //foreach (var item in adopters)
                    //{
                    //    list.Add(new AdoptionContract()
                    //    {
                    //        Adopter = item,
                    //        Animal = item.a
                    //    });
                    //}
                    //return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Adopt(Guid adopter, Guid animal)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var newAnimal = context.Animals.First(x => x.ID == animal);
                    newAnimal.AdoptedBy = adopter;

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
