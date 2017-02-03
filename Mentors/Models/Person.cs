using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StudyPlace { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Vk { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
    }
}
