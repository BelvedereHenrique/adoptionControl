using System;
using System.Linq;
using Desafio.Repository.Context;

namespace Desafio.Repository.Adoption
{
    public class AdoptionRepository : IAdoptionRepository
    {

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
