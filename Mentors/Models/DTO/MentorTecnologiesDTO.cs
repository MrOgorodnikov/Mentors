using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models.DTO
{
    public class MentorTecnologiesDTO
    {
        public Mentor Mentor { get; set; }
        public List<Tecnology> AllTecnologies { get; set; }
        public List<Tecnology> MentorsTecnologies { get; set; }
    }
}
