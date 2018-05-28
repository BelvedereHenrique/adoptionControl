using Desafio.Contracts;

namespace Desafio.Repository.Animal
{
    public interface IAnimalRepository: IDatabaseOperations<AnimalContract>
    {
        void Edit(AnimalContract adopter);
    }
}
