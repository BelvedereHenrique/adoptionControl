using Desafio.Contracts;
using System;
using System.Collections.Generic;

namespace Desafio.Repository.Animal
{
    public interface IAnimalRepository: IDatabaseOperations<AnimalContract>
    {
        void Edit(AnimalContract adopter);
    }
}
