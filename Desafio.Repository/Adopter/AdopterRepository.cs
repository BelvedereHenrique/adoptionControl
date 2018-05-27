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
                    return context.Adopters.First(x=>x.ID == adopterId);
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
                    return context.Adopters.ToList();
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
                    var adopter = context.Adopters.First(x=>x.ID == adopterID);
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
            oldAdopter.Email = newAdopter.AddressLine;
        }
    }
}
