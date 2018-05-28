using System;
using System.Linq;
using Desafio.Contracts;
using Desafio.Services.Animal;
using Desafio.Services.Adopter;
using System.Collections.Generic;
using Desafio.Repository.Adoption;

namespace Desafio.Services.Adoption
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IAdoptionRepository _adoptionRepository;
        private readonly IAnimalService _animalService;
        private readonly IAdopterService _adopterService;

        public AdoptionService(IAdoptionRepository adoptionRepository, IAnimalService animalService, IAdopterService adopterService)
        {
            _adoptionRepository = adoptionRepository;
            _animalService = animalService;
            _adopterService = adopterService;
        }


        public OperationResult<List<AdoptionContract>> GetAll()
        {
            try
            {
                var animals = _animalService.GetAll().Result
                    .Where(x => x.AdoptedBy != null).ToList();
                var adoptions = new List<AdoptionContract>();
                foreach (var item in animals)
                {
                    adoptions.Add(new AdoptionContract()
                    {
                        Adopter  = _adopterService.Get(item.AdoptedBy.Value).Result,
                        Animal = item,
                        
                    });
                }
                return new OperationResult<List<AdoptionContract>>(true, "Success", adoptions);
            }
            catch (Exception e)
            {
                return new OperationResult<List<AdoptionContract>>(false, e.Message, null);
            }
        }

        public OperationResult Adopt(Guid adopterID, Guid animalID)
        {
            try
            {
                _adoptionRepository.Adopt(adopterID, animalID);
                return new OperationResult(true, "Success");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }

        public OperationResult CancelAdoption(Guid adoptionID)
        {
            try
            {
                var animal = _animalService.Get(adoptionID);
                animal.Result.AdoptedBy = null;
                _animalService.Edit(animal.Result);
                return new OperationResult(true, "Success");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }

        public OperationResult<List<AnimalContract>> GetFreeAnimals()
        {
            try
            {
                var animals = _animalService.GetAll().Result.Where(x => x.AdoptedBy == null).ToList();
                return new OperationResult<List<AnimalContract>>(true, "Success", animals);
            }
            catch (Exception e)
            {
                return new OperationResult<List<AnimalContract>>(false, e.Message, null);
            }
        }

    }
}
