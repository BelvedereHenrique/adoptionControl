using System;
using System.Collections.Generic;

namespace Desafio.Repository
{
    public interface IDatabaseOperations<T> where T : class
    {
        void Add(T contract);
        void Delete(Guid contractID);
        T Get(Guid contractID);
        List<T> GetAll();
    }
}
