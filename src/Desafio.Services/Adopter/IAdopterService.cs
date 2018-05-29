using System;
using Desafio.Contracts;
using System.Collections.Generic;

namespace Desafio.Services.Adopter
{
    public interface IAdopterService
    {
        OperationResult<AdopterContract> Get(Guid adopterID);
        OperationResult<List<AdopterContract>> GetAll();
        OperationResult Add(AdopterContract adopter);
        OperationResult Delete(Guid adopterID);
        OperationResult Edit(AdopterContract adopter);
    }
}
