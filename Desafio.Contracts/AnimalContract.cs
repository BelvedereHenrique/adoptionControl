using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Contracts
{
    public class AnimalContract
    {
        public AnimalContract(Guid id, string name, string type, float weight = 0, int age = 0)
        {
            this.ID = ID;
            this.Name = name;
            this.AnimalType = type;
            this.Weight = weight;
            this.Age = age;
        }
        public AnimalContract(){}
        
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string AnimalType { get; set; }

        public float Weight { get; set; }
        public int Age { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? AdoptedBy { get; set; }

        public virtual AdopterContract Adopter { get; set; }
    }
}
