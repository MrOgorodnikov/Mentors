using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mentors.Models
{
    public class Student : Person
    {
        

        public ICollection<MentorStudent> MentorStudent { get; set; }
        public ICollection<StudentTecnology> StudentTecnology { get; set; }

        public Student()
        {
            MentorStudent = new List<MentorStudent>();
            StudentTecnology = new List<StudentTecnology>();
        }

    }
}
