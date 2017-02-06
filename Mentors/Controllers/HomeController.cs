using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mentors.Models;
using Microsoft.EntityFrameworkCore;
using Mentors.Models.DTO;
using Mentors.BussinesLogic;
using Mentors.Models.View;
using System.Collections.Generic;
using System;

namespace Mentors.Controllers
{
    public class HomeController : Controller
    {
        private MentorsContext db = new MentorsContext();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MentorStudent()
        {
            return View(Home.CreateMentorStudentList());
        }

        public IActionResult Mentors()
        {
            return View(Home.CreateMentorTecnologyList());
        }

        [HttpGet]
        public IActionResult ChangeMentorInfo(int Id)
        {
            var mentor = db.Mentors.First(m => m.Id == Id);
            var tecnologiesList = db.Tecnologies.ToList();
            var mentorsTecnologies = db.Mentors
                                    .Include(mt => mt.MentorTecnology)
                                    .ThenInclude(t => t.Tecnology)
                                    .ToList()
                                    .First(id => id.Id == Id)
                                    .MentorTecnology
                                    .Select(t => t.Tecnology)
                                    .ToList();


            ViewBag.MentorId = Id;
            return View(new MentorTecnologiesDTO
            {
                Mentor = mentor,
                AllTecnologies = tecnologiesList,
                MentorsTecnologies = mentorsTecnologies
            });
        }

        [HttpPost]
        public RedirectResult ChangeMentorInfo(Mentor mentor)
        {
            db.Mentors.Update(mentor);

            Home.DeleteMentorsTecnologies(mentor);
            Home.AddTecnologiesToMentor(mentor, Request.Form.Keys.ToList());

            return Redirect("~/Home/Mentors");
        }

        [HttpPost]
        public RedirectResult DeleteMentor(int mentorId)
        {
            Home.DeleteMentor(mentorId);
            return Redirect("~/Home/Mentors");
        }

        public IActionResult AddMentor()
        {
            return View(db.Tecnologies.ToList());
        }

        [HttpPost]
        public RedirectResult AddMentor(Mentor mentor)
        {
            //if (ModelState.IsValid)
            //    Home.AddMentor(mentor, Request.Form.Keys.ToList());
            //else
            //    // return View(mentor);
            //    return Redirect("~/Home/AddMentor");

            return Redirect("~/Home/Mentors");
        }

        public IActionResult Students()
        {
            return View(db.Students.ToList());
        }

        [HttpPost]
        public RedirectResult DeleteStudent(int studentId)
        {
            Home.DeleteStudent(studentId);
            return Redirect("~/Home/Students");
        }

        public IActionResult MoreAboutStudent(int id)
        {
            return View(CreateStudent(id));
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            return View(CreateStudent(id));
        }

        [HttpPost]
        public RedirectResult EditStudent(Student student)
        {
            db.Students.Update(student);
            Home.DeleteStudentTecnologies(student);
            Home.AddTecnologiesToStudent(student, Request.Form.Keys.ToList());

            return Redirect("~/Home/Students");
        }

        private StudentView CreateStudent(int id)
        {
            var student = db.Students
                            .Include(ms => ms.MentorStudent)
                            .ThenInclude(m => m.Mentor)
                            .First(s => s.Id == id);
            var mentList = student.MentorStudent.Select(m => m.Mentor).ToList();
            student = db.Students
                        .Include(st => st.StudentTecnology)
                        .ThenInclude(t => t.Tecnology)
                        .First(s => s.Id == id);
            var studTecList = student.StudentTecnology.Select(t => t.Tecnology).ToList();
            student = db.Students.First(s => s.Id == id);

            var allTecList = db.Tecnologies.ToList();

            return new StudentView { Student = student, Mentors = mentList, StudentTecnologies = studTecList, AllTecnologies = allTecList };
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View(db.Tecnologies.ToList());
        }

        [HttpPost]
        public RedirectResult AddStudent(Student student)
        {
            Home.AddStudent(student, Request.Form.Keys.ToList());

            return Redirect("~/Home/Students");
        }

        [HttpGet]
        public IActionResult FindMentor()
        {
            var fmDTO = new List<FindMentorDTO>
            {
                new FindMentorDTO { Tecnilogies = db.Tecnologies.ToList(), Countries = BussinesLogic.FindMentor.GetAllDifferentCounties() }
            };
            return View(fmDTO);
        }

        [HttpPost]
        public RedirectToActionResult FindMentor(int tecnologyId, string country, int highAge, int downAge, int Vk, int Fb)
        {
            return RedirectToAction("InterestedMentors", 
                                      new
                                      {
                                          tecnologyId = tecnologyId,
                                          country = country,
                                          downAge = downAge,
                                          highAge = highAge,
                                          Vk = Convert.ToBoolean(Vk),
                                          Fb = Convert.ToBoolean(Fb)
                                      });
        }

        [HttpGet]
        public IActionResult InterestedMentors(int tecnologyId, string country, int highAge, int downAge, bool Vk, bool Fb)
        {            
            return View(BussinesLogic.FindMentor.FindMentors(tecnologyId, country, downAge, highAge,  Vk,  Fb));            
        }
    }
}
