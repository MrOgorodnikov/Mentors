using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mentors.Models
{
    public class Tecnology
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<StudentTecnology> StudentTecnology { get; set; }
        public ICollection<MentorTecnology> MentorTecnology { get; set; }
        public Tecnology()
        {
            StudentTecnology = new List<StudentTecnology>();
            MentorTecnology = new List<MentorTecnology>();
        }

    }
}