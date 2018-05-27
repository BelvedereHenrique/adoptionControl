using System;
using Desafio.Contracts;
using System.Collections.Generic;

namespace Desafio.Repository.Adoption
{
    public interface IAdoptionRepository: IDatabaseOperations<AdoptionContract>
    {
    }
}
