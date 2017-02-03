using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models.DTO
{
    public class MentorStudentDTO
    {
        public Student Student { get; set; }
        public Mentor Mentor { get; set; }
    }
}
