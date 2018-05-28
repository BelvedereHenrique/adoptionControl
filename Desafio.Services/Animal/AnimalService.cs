using System;
using Desafio.Contracts;
using Desafio.Repository.Animal;
using System.Collections.Generic;

namespace Desafio.Services.Animal
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRespository)
        {
            _animalRepository = animalRespository;
        }

        public OperationResult Add(AnimalContract animal)
        {
            try
            {
                if (animal == null)
                    return new OperationResult(false, "Null contract.");

                animal.ID = Guid.NewGuid();
                animal.CreatedOn = DateTime.Now;
                _animalRepository.Add(animal);
                return new OperationResult(true, "Animal added.");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }

        public OperationResult Delete(Guid animalID)
        {
            try
            {
                if (animalID == Guid.Empty)
                    return new OperationResult(false, "Empty ID.");

                _animalRepository.Delete(animalID);
                return new OperationResult(true, "Animal removed.");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }

        public OperationResult Edit(AnimalContract animal)
        {
            try
            {
                if (animal == null)
                    return new OperationResult(false, "Null contract.");

                _animalRepository.Edit(animal);
                return new OperationResult(true, "Animal edited.");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }

        public OperationResult<AnimalContract> Get(Guid animalID)
        {
            try
            {
                var result = _animalRepository.Get(animalID);
                return new OperationResult<AnimalContract>(true, "Success", result);
            }
            catch (Exception e)
            {
                return new OperationResult<AnimalContract>(false, e.Message, null);
            }
        }

        public OperationResult<List<AnimalContract>> GetAll()
        {
            try
            {
                var result = _animalRepository.GetAll();
                return new OperationResult<List<AnimalContract>>(true, "Success", result);
            }
            catch (Exception e)
            {
                return new OperationResult<List<AnimalContract>>(false, e.Message, null);
            }
        }
    }
}
