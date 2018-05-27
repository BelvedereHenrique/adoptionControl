using System.Collections.Generic;

namespace Desafio.Contracts
{
    public class AdoptionContract
    {
        public AdopterContract Adopter { get; set; }
        public AnimalContract Animal { get; set; }
        public AdoptionContract(AdopterContract Adopter, AnimalContract Animal)
        {
            this.Adopter = Adopter;
            this.Animal = Animal;
        }
        public AdoptionContract()
        {

        }
    }
}
