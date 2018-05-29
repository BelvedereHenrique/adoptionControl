using System;
using System.Collections.Generic;
using Desafio.Contracts;

namespace Desafio.Repository.Adopter
{
    public interface IAdopterRepository: IDatabaseOperations<AdopterContract>
    {
        void Edit(AdopterContract adopter);
    }
}
