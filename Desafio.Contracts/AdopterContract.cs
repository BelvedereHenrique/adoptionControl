using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Contracts
{
    public class AdopterContract
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Adopter Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Adopter Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Adopter AddressLine is required.")]
        public string AddressLine { get; set; }
        [Required(ErrorMessage = "Adopter State is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Adopter Phone is required.")]
        public string Phone { get; set; }

    }
}
