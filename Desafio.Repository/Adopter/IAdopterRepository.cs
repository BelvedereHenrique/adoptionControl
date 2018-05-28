using System;
using Desafio.Contracts;
using System.Collections.Generic;

namespace Desafio.Repository.Adopter
{
    public interface IAdopterRepository: IDatabaseOperations<AdopterContract>
    {
        void Edit(AdopterContract adopter);
    }
}
