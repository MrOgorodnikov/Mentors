using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models
{
    public class StudentTecnology
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TecnologyId { get; set; }
        public Tecnology Tecnology { get; set; }
    }
}
