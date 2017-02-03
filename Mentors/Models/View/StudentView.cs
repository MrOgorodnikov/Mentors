using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models.View
{
    public class StudentView
    {
        public Student Student { get; set; }
        public List<Mentor> Mentors { get; set; }
        public List<Tecnology> StudentTecnologies { get; set; }
        public List<Tecnology> AllTecnologies { get; set; }
    }
}
