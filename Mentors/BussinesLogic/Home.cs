using Mentors.Models;
using Mentors.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mentors.BussinesLogic
{
    public class Home
    {
        public static List<MentorTecnologyDTO> CreateMentorTecnologyList()
        {
            var db = new MentorsContext();
            var mtDTO = new List<MentorTecnologyDTO>();
            var mentorList = db.Mentors
                            .Include(mt => mt.MentorTecnology)
                            .ThenInclude(t => t.Tecnology)
                            .ToList();
            foreach (var mentor in mentorList)
            {
                var tecnologyList = mentor.MentorTecnology
                                    .Select(t => t.Tecnology)
                                    .ToList();
                foreach (var tecnology in tecnologyList)
                    mtDTO.Add(new MentorTecnologyDTO { Mentor = mentor, Tecnology = tecnology});
            }

            return mtDTO;
        }

        public static List<MentorStudentDTO> CreateMentorStudentList()
        {
            var db = new MentorsContext();
            var msDTO = new List<MentorStudentDTO>();
            var mentorList = db.Mentors
                            .Include(ms => ms.MentorStudent)
                            .ThenInclude(s => s.Student)
                            .ToList();
            foreach (var mentor in mentorList)
            {
                var studentList = mentor.MentorStudent
                                 .Select(s => s.Student)
                                 .ToList();
                foreach (var student in studentList)
                    msDTO.Add(new MentorStudentDTO { Mentor = mentor, Student = student });
            }

            return msDTO;
        }

        public static void AddMentor(Mentor mentor, List<string> requestFormKeys)
        {
            var db = new MentorsContext();
            var newMentor = new Mentor
            {
                Name = mentor.Name,
                Surname = mentor.Surname,
                Age = mentor.Age,
                ExperienceInYear = mentor.ExperienceInYear,
                MaxStudentCount = mentor.MaxStudentCount,
                PlaceOfWork = mentor.PlaceOfWork
            };
            db.Mentors.Add(newMentor);
            db.SaveChanges();
            AddTecnologiesToMentor(newMentor, requestFormKeys);            
        }

        public static void AddStudent(Student student, List<string> requestFormKeys)
        {
            var db = new MentorsContext();
            var newStudent = new Student
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age
            };
            db.Students.Add(newStudent);
            db.SaveChanges();
            AddTecnologiesToStudent(newStudent, requestFormKeys);
        }
       
        public static void DeleteMentorsTecnologies(Mentor mentor)
        {
            var db = new MentorsContext();
            var ment = db.Mentors.Include(m => m.MentorTecnology).First(m => m.Id == mentor.Id);
            var mentorTecnologyCount = ment.MentorTecnology.Count;
            for (int i = 0; i < mentorTecnologyCount; i++)
            {
                var mentTec = ment.MentorTecnology.First(mt => mt.MentorId == ment.Id);
                ment.MentorTecnology.Remove(mentTec);
                db.SaveChanges();
            }
        }

        public static void DeleteStudentTecnologies(Student student)
        {
            var db = new MentorsContext();
            var stud = db.Students.Include(s => s.StudentTecnology).First(s => s.Id == student.Id);
            var studentTecnologyCount = stud.StudentTecnology.Count;
            for (int i = 0; i < studentTecnologyCount; i++)
            {
                stud.StudentTecnology.Remove(stud.StudentTecnology.FirstOrDefault(st => st.StudentId == stud.Id));
                db.SaveChanges();
            }
        }

        public static void AddTecnologiesToMentor(Mentor mentor, List<string> requestFormKeys)
        {
            var db = new MentorsContext();
            foreach (var x in requestFormKeys)
            {
                if (int.TryParse(x, out int id))
                    db.Mentors
                        .First(m => m.Id == mentor.Id)
                        .MentorTecnology
                        .Add(new MentorTecnology
                        {
                            Mentor = mentor,
                            Tecnology = db
                                        .Tecnologies
                                        .First(t => t.Id == id)
                        });
            }

            db.SaveChanges();
        }

        public static void AddTecnologiesToStudent(Student student, List<string> requestFormKeys)
        {
            var db = new MentorsContext();
            foreach (var x in requestFormKeys)
            {
               
                if (int.TryParse(x, out int id))
    
                {
                    db.Students
                        .First(s => s.Id == student.Id)
                        .StudentTecnology
                        .Add(new StudentTecnology
                        {
                            Student = student,
                            Tecnology = db.Tecnologies.First(t => t.Id == id)
                        });
                }
            }

            db.SaveChanges();
        }

        public static void DeleteMentor(int mentorId)
        {
            var db = new MentorsContext();
            db.Mentors.Remove(db.Mentors.FirstOrDefault(m => m.Id == mentorId));
            db.SaveChanges();
        }

        public static void DeleteStudent(int studentId)
        {
            var db = new MentorsContext();
            db.Students.Remove(db.Students.FirstOrDefault(s => s.Id == studentId));
            db.SaveChanges();
        }

    }
}
