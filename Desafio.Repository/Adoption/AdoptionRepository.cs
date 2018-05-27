using System;
using System.Linq;
using Desafio.Contracts;
using System.Collections.Generic;
using Desafio.Repository.Context;

namespace Desafio.Repository.Adoption
{
    public class AdoptionRepository : IAdoptionRepository
    {
        public AdoptionContract Get(Guid adoptionID)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    return context.Adoptions.First(x => x.ID == adoptionID);
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
                    return context.Adoptions.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Add(AdoptionContract adoptionContract)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Adoptions.Add(adoptionContract);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Guid adoptionID)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var adoption = context.Adoptions.First(x => x.ID == adoptionID);
                    context.Adoptions.Remove(adoption);
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
