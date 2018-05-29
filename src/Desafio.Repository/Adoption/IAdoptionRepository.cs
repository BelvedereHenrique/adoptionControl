using Desafio.Contracts;
using System;
using System.Collections.Generic;

namespace Desafio.Repository.Adoption
{
    public interface IAdoptionRepository
    {
        AdoptionContract Get(Guid animalID);
        List<AdoptionContract> GetAll();
        void Adopt(Guid adopterID, Guid animalID);
    }
}
