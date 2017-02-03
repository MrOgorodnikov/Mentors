using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mentors.Models
{
    public class MentorsContext : DbContext
    {
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tecnology> Tecnologies { get; set; }

        public MentorsContext(DbContextOptions<MentorsContext> options) : base (options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MentorStudent(modelBuilder);
            MentorTecnology(modelBuilder);
            StudentTecnology(modelBuilder);

        }

        private void MentorStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorStudent>()
                        .HasKey(e => new {e.MentorId, e.StudentId});

            modelBuilder.Entity<MentorStudent>()
                        .HasOne(m => m.Mentor)
                        .WithMany(s => s.MentorStudent)
                        .HasForeignKey(ms => ms.MentorId);

            modelBuilder.Entity<MentorStudent>()
                        .HasOne(s => s.Student)
                        .WithMany(m => m.MentorStudent)
                        .HasForeignKey(ms => ms.StudentId);
        }
        private void MentorTecnology(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorTecnology>()
                        .HasKey(e => new { e.MentorId, e.TecnologyId });

            modelBuilder.Entity<MentorTecnology>()
                        .HasOne(m => m.Mentor)
                        .WithMany(mt => mt.MentorTecnology)
                        .HasForeignKey(m => m.MentorId);

            modelBuilder.Entity<MentorTecnology>()
                        .HasOne(t => t.Tecnology)
                        .WithMany(mt => mt.MentorTecnology)
                        .HasForeignKey(t => t.TecnologyId);
        }
        private void StudentTecnology(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTecnology>()
                        .HasKey(e => new { e.StudentId, e.TecnologyId });

            modelBuilder.Entity<StudentTecnology>()
                        .HasOne(s => s.Student)
                        .WithMany(st => st.StudentTecnology)
                        .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<StudentTecnology>()
                        .HasOne(t => t.Tecnology)
                        .WithMany(st => st.StudentTecnology)
                        .HasForeignKey(t => t.TecnologyId);
        }
    }
}
