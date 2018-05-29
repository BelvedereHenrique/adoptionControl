using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Contracts
{
    public class AdopterContract
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        public string AddressLine { get; set; }
        [Required(ErrorMessage = "Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual ICollection<AnimalContract> Animals { get; set; }
    }
}
