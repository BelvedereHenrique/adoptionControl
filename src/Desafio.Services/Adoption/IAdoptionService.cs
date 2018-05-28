using System;
using Desafio.Contracts;
using System.Collections.Generic;

namespace Desafio.Services.Adoption
{
    public interface IAdoptionService
    {
        OperationResult<List<AdoptionContract>> GetAll();
        OperationResult Adopt(Guid adopterID, Guid animalID);
        OperationResult CancelAdoption(Guid adoptionID);
        OperationResult<List<AnimalContract>> GetFreeAnimals();
    }
}