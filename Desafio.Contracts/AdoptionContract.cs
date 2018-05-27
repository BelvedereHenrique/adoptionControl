using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Contracts
{
    public class AdoptionContract
    {
        public AdoptionContract(Guid adopterID, Guid animalID, DateTime date)
        {
            ID = Guid.NewGuid();
            AnimalID = animalID;
            AdopterID = AdopterID;
            Date = date;
        }

        [Required(ErrorMessage = "Adoption ID is required.")]
        public Guid? ID { get; set; }

        [Required(ErrorMessage = "Adoption Animal is required.")]

        public Guid AnimalID { get; set; }

        [Required(ErrorMessage = "Adoption Adopter is required.")]
        public Guid AdopterID { get; set; }

        [Required(ErrorMessage = "Adoption Adopter is required.")]
        public DateTime Date { get; set; }
    }
}
