using System;

namespace Desafio.Repository.Adoption
{
    public interface IAdoptionRepository
    {
        void Adopt(Guid adopterID, Guid animalID);
    }
}
