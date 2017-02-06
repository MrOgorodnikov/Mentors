using Mentors.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Mentors.BussinesLogic
{
    public class FindMentor
    {
        static MentorsContext db = new MentorsContext();
        public static List<string> GetAllDifferentCounties()
        {
            List<string> countries = new List<string>();

            foreach (var mentor in db.Mentors.ToList())
            {
                if (!countries.Contains(mentor.Country))
                    countries.Add(mentor.Country);
            }

            return countries;
        }
        private static List<Mentor> FindByTecnology(int tecnologyId)
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
        private static List<Mentor> FindByCountry(string country)
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
        private static List<Mentor> FindByAge(int downAge, int highAge)
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
        private static List<Mentor> FindByVk(bool Vk)
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
        private static List<Mentor> FindByFb(bool Fb)
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

        public static List<Mentor> FindMentors(int tecnologyId, string country, int downAge, int highAge, bool Vk, bool Fb)
        {           
            int criteriesCount = GetCriteriesCount(tecnologyId, country, downAge, highAge, Vk, Fb, 5); //Because 5 criteries
                 
            var allMentors = AddMentorsByAllCriteriesToOneList(tecnologyId, country, downAge, highAge, Vk, Fb);           
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

        private static List<Mentor> AddMentorsByAllCriteriesToOneList(int tecnologyId, string country, int downAge, int highAge, bool Vk, bool Fb)
        {
            var allMentors = new List<Mentor>();
            allMentors.AddRange(FindByTecnology(tecnologyId));
            allMentors.AddRange(FindByAge(downAge, highAge));
            allMentors.AddRange(FindByCountry(country));
            allMentors.AddRange(FindByVk(Vk));
            allMentors.AddRange(FindByFb(Fb));

            return allMentors;
        }
        private static int GetCriteriesCount(int tecnologyId, string country, int downAge, int highAge, bool Vk, bool Fb, int maxCriteriesCount)
        {
            int criteriesCount = 5;

            if (country == null)
                criteriesCount--;
            if (downAge == 0 && highAge == 0)
                criteriesCount--;
            if (!Vk)
                criteriesCount--;
            if (!Fb)
                criteriesCount--;

            return criteriesCount;
        }




    }
}
