using System;
using System.Linq;
using Desafio.Contracts;
using System.Collections.Generic;
using Desafio.Repository.Context;

namespace Desafio.Repository.Adopter
{
    public class AdopterRepository : IAdopterRepository
    {
        public AdopterContract Get(Guid adopterId)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var adopter = context.Adopters.Include("Animals").First(x => x.ID == adopterId);
                    //this prevents cyclic reference
                    adopter.Animals = null;
                    return adopter;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AdopterContract> GetAll()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var adopters = context.Adopters.Include("Animals").ToList();
                    //this prevents cyclic reference
                    adopters.ForEach(x => x.Animals = null);
                    return adopters;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Add(AdopterContract adopter)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Adopters.Add(adopter);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Guid adopterID)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var adopter = context.Adopters.First(x => x.ID == adopterID);
                    if (context.Animals.Any(x=>x.AdoptedBy == adopterID))
                        throw new ArgumentException("Cannot delete Adopters who have current adoptions");
               
                    context.Adopters.Remove(adopter);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Edit(AdopterContract newAdopter)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var oldAdopter = context.Adopters.First(x => x.ID == newAdopter.ID);

                    MapUpdatedFields(newAdopter, oldAdopter);

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void MapUpdatedFields(AdopterContract newAdopter, AdopterContract oldAdopter)
        {
            oldAdopter.ID = newAdopter.ID;
            oldAdopter.Name = newAdopter.Name;
            oldAdopter.Phone = newAdopter.Phone;
            oldAdopter.State = newAdopter.State;
            oldAdopter.AddressLine = newAdopter.AddressLine;
            oldAdopter.Email = newAdopter.Email;
        }
    }
}
