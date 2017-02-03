using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models
{
    public class MentorStudent
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
