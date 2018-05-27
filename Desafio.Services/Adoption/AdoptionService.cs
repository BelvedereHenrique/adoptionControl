using System;
using Desafio.Contracts;
using Desafio.Repository.Adoption;
using System.Collections.Generic;

namespace Desafio.Services.Adoption
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IAdoptionRepository _adoptionRepository;

        public AdoptionService(IAdoptionRepository adoptionRepository)
        {
            _adoptionRepository = adoptionRepository;
        }

        public OperationResult<AdoptionContract> Get(Guid adoptionID)
        {
            try
            {
                var result = _adoptionRepository.Get(adoptionID);
                return new OperationResult<AdoptionContract>(true, "Success", result);
            }
            catch (Exception e)
            {
                return new OperationResult<AdoptionContract>(false, e.Message, null);
            }
        }

        public OperationResult<List<AdoptionContract>> GetAll()
        {
            try
            {
                var result = _adoptionRepository.GetAll();
                return new OperationResult<List<AdoptionContract>>(true, "Success", result);
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
                _adoptionRepository.Add(new AdoptionContract(adopterID, animalID, DateTime.Now));
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
                _adoptionRepository.Delete(adoptionID);
                return new OperationResult(true, "Success");
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }
        }
    }
}
