using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models
{
    public class Mentor : Person, IComparable<Mentor>
    {
        [Required]
        public int ExperienceInYear { get; set; }
        [Required]
        public int MaxStudentCount { get; set; }
        public int CurrentStudentCount { get; set; }        
        public int FreeStudentCount => MaxStudentCount - CurrentStudentCount;        
        public string PlaceOfWork { get; set; }        
        
        public ICollection<MentorStudent> MentorStudent { get; set; }
        public ICollection<MentorTecnology> MentorTecnology { get; set; }

        public Mentor()
        {
            MentorStudent = new List<MentorStudent>();
            MentorTecnology = new List<MentorTecnology>();            
        }
               
        public int CompareTo(Mentor other)
        {
            if (Id > other.Id)
            {
                return 1;
            }
            if (Id < other.Id)
            {
                return -1;
            }
            return 0;
        }
    }
}
