using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models
{
    public class MentorTecnology
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }

        public int TecnologyId { get; set; }
        public Tecnology Tecnology { get; set; }
    }
}
