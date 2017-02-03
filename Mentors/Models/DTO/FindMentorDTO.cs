using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models.DTO
{
    public class FindMentorDTO
    {
        public List<Tecnology> Tecnilogies { get; set; }
        public List<string> Countries { get; set; } 
        public List<int> Ages { get; set; }
    }
}
