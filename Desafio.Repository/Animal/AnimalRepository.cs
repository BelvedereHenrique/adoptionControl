using System;
using System.Linq;
using Desafio.Contracts;
using Desafio.Repository.Context;
using System.Collections.Generic;

namespace Desafio.Repository.Animal
{
    public class AnimalRepository : IAnimalRepository
    {
        public AnimalContract Get(Guid animalID)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    return context.Animals.First(x=>x.ID == animalID);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AnimalContract> GetAll()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    return context.Animals.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Add(AnimalContract animal)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Animals.Add(animal);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(Guid animalID)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var animal = context.Animals.First(x => x.ID == animalID);

                    context.Animals.Remove(animal);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Edit(AnimalContract updatedAnimal)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var oldAnimal = context.Animals.First(x => x.ID == updatedAnimal.ID);
                    MapUpdatedFields(updatedAnimal, oldAnimal);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void MapUpdatedFields(AnimalContract updatedAnimal, AnimalContract oldAnimal)
        {
            oldAnimal.Name = updatedAnimal.Name;
            oldAnimal.Type = updatedAnimal.Type;
            oldAnimal.Weight = updatedAnimal.Weight;
        }
    }
}
