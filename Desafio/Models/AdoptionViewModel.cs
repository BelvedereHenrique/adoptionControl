using Desafio.Contracts;
using System.Collections.Generic;

namespace Web.Mvc.Models
{
    public class AdoptionViewModel
    {
        public IList<AnimalContract> Animals { get; set; }
        public IList<AdopterContract> Adoptors { get; set; }
    }
}