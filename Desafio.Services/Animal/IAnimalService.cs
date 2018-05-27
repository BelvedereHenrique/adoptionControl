using System;
using Desafio.Contracts;
using System.Collections.Generic;

namespace Desafio.Services.Animal
{
    public interface IAnimalService
    {
        OperationResult<List<AnimalContract>> GetAll();
        OperationResult<AnimalContract> Get(Guid contractID); 
        OperationResult Add(AnimalContract animal);
        OperationResult Edit(AnimalContract adopter);
        OperationResult Delete(Guid adopterID);
    }
}
