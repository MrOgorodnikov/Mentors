
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentors.Models
{
    public class AddFirstData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<MentorsContext>();

            //context.Tecnologies.Add(new Tecnology { Name = "JavaScript"});
            //context.Tecnologies.Add(new Tecnology { Name = "Node.js" });
            //context.Tecnologies.Add(new Tecnology { Name = "C++" });


            //var students = context.Students.ToArray();
            //var mentors = context.Mentors.ToArray();
            //var tec = context.Tecnologies.ToArray();

            //students[0].StudentTecnology.Add(new StudentTecnology { StudentId = students[0].Id, TecnologyId = tec[0].Id });
            //students[1].StudentTecnology.Add(new StudentTecnology { StudentId = students[1].Id, TecnologyId = tec[1].Id });
            //students[2].StudentTecnology.Add(new StudentTecnology { StudentId = students[2].Id, TecnologyId = tec[2].Id });
            //students[3].StudentTecnology.Add(new StudentTecnology { StudentId = students[3].Id, TecnologyId = tec[3].Id });

            //var studMent = context.Students.Include(ms => ms.MentorStudent).ThenInclude(m => m.Mentor).ToList();


            //string test = $"{studMent[0].Name}   {studMent[0].MentorStudent.Select(m => m.Mentor).ToList()[0].Name}";

            //context.SaveChanges();
        }
   }
}
