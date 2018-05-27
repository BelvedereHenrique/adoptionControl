using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Contracts
{
    public class AnimalContract
    {
        public AnimalContract(Guid id, string name, AnimalType type, float weight = 0, int age = 0)
        {
            this.ID = ID;
            this.Name = name;
            this.Type = type;
            this.Weight = weight;
            this.Age = age;
        }

        
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Animal Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Animal Type is required.")]
        public AnimalType Type { get; set; }

        public float Weight { get; set; }
        public int Age { get; set; }
    }
    public enum AnimalType
    {
        Dog = 1,
        Cat = 2,
        Bird = 3
    }
}
