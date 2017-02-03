using Mentors.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mentors.BussinesLogic
{
    public class FindMentor
    {
        public static List<string> GetAllDifferentCounties(MentorsContext db)
        {
            List<string> countries = new List<string>();

            foreach (var mentor in db.Mentors.ToList())
            {
                if (!countries.Contains(mentor.Country))
                    countries.Add(mentor.Country);
            }

            return countries;
        }
        private static List<Mentor> FindByTecnology(int tecnologyId, MentorsContext db)
        {
            if (tecnologyId == 0)
            {
                return db.Mentors.ToList();
            }
            var mentorsTecnology = db.Mentors.SelectMany(m => m.MentorTecnology.Where(mt => mt.TecnologyId == tecnologyId));
            List<Mentor> mentors = new List<Mentor>();
            foreach (var mentor in mentorsTecnology)
            {
                mentors.Add(db.Mentors.FirstOrDefault(m => m.Id == mentor.MentorId));
            }

            return mentors;
        }        
        private static List<Mentor> FindByCountry(string country, MentorsContext db)
        {
            List<Mentor> mentors = new List<Mentor>();
            foreach (var mentor in db.Mentors.ToList())
            {
                if (mentor.Country == country)
                {
                    mentors.Add(mentor);
                }
            }

            return mentors;
        }
        private static List<Mentor> FindByAge(int downAge, int highAge, MentorsContext db)
        {            
            var mentors = new List<Mentor>();
            if (highAge == 0 && downAge != 0)
                highAge = 200;
            foreach (var mentor in db.Mentors.ToList())
            {
                if (mentor.Age >= downAge && mentor.Age <= highAge)
                    mentors.Add(mentor);
            }

            return mentors;
        }
        private static List<Mentor> FindByVk(bool Vk, MentorsContext db)
        {
            var mentors = new List<Mentor>();
            if (!Vk)
                return mentors;
            foreach (var mentor in db.Mentors.ToList())
            {
                if (mentor.Vk != null)                
                    mentors.Add(mentor);
                
            }
            return mentors;
        }
        private static List<Mentor> FindByFb(bool Fb, MentorsContext db)
        {
            var mentors = new List<Mentor>();
            if (!Fb)
                return mentors;
            foreach (var mentor in db.Mentors.ToList())
            {
                if (mentor.Facebook != null)
                    mentors.Add(mentor);

            }
            return mentors;
        }
        public static List<Mentor> FindMentors(int tecnologyId, string country, int downAge, int highAge, bool Vk, bool Fb, MentorsContext db)
        {
            int criteriesCount = 5; //Because 5 criteries
                     
            if (country == null)            
                criteriesCount--;            
            if (downAge == 0 && highAge == 0)            
                criteriesCount--;
            if (!Vk)            
                criteriesCount--;            
            if (!Fb)            
                criteriesCount--;

            var allMentors = new List<Mentor>();
            allMentors.AddRange(FindByTecnology(tecnologyId, db));
            allMentors.AddRange(FindByAge(downAge, highAge, db));
            allMentors.AddRange(FindByCountry(country, db));
            allMentors.AddRange(FindByVk(Vk, db));
            allMentors.AddRange(FindByFb(Fb, db));
            allMentors.Sort();

            if (criteriesCount == 0)            
                return allMentors;            

            var mentors = new List<Mentor>();
            var groupedMentors = allMentors.GroupBy(m => m.Id);
            foreach (var mentor in groupedMentors)            
                if (mentor.Count() == criteriesCount)                
                    mentors.Add(mentor.FirstOrDefault());  

            mentors.RemoveAll(m => m.FreeStudentCount == 0);
            return mentors;
        }




        
    }
}
