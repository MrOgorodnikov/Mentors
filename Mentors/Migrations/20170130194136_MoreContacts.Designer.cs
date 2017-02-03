using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Mentors.Models;

namespace Mentors.Migrations
{
    [DbContext(typeof(MentorsContext))]
    [Migration("20170130194136_MoreContacts")]
    partial class MoreContacts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mentors.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("CurrentStudentCount");

                    b.Property<string>("Email");

                    b.Property<int>("ExperienceInYear");

                    b.Property<string>("Facebook");

                    b.Property<string>("LinkedIn");

                    b.Property<int>("MaxStudentCount");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("PlaceOfWork");

                    b.Property<string>("StudyPlace");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("Vk");

                    b.HasKey("Id");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("Mentors.Models.MentorStudent", b =>
                {
                    b.Property<int>("MentorId");

                    b.Property<int>("StudentId");

                    b.HasKey("MentorId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("MentorStudent");
                });

            modelBuilder.Entity("Mentors.Models.MentorTecnology", b =>
                {
                    b.Property<int>("MentorId");

                    b.Property<int>("TecnologyId");

                    b.HasKey("MentorId", "TecnologyId");

                    b.HasIndex("TecnologyId");

                    b.ToTable("MentorTecnology");
                });

            modelBuilder.Entity("Mentors.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<string>("LinkedIn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("StudyPlace");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("Vk");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Mentors.Models.StudentTecnology", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("TecnologyId");

                    b.HasKey("StudentId", "TecnologyId");

                    b.HasIndex("TecnologyId");

                    b.ToTable("StudentTecnology");
                });

            modelBuilder.Entity("Mentors.Models.Tecnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tecnologies");
                });

            modelBuilder.Entity("Mentors.Models.MentorStudent", b =>
                {
                    b.HasOne("Mentors.Models.Mentor", "Mentor")
                        .WithMany("MentorStudent")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mentors.Models.Student", "Student")
                        .WithMany("MentorStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mentors.Models.MentorTecnology", b =>
                {
                    b.HasOne("Mentors.Models.Mentor", "Mentor")
                        .WithMany("MentorTecnology")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mentors.Models.Tecnology", "Tecnology")
                        .WithMany("MentorTecnology")
                        .HasForeignKey("TecnologyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mentors.Models.StudentTecnology", b =>
                {
                    b.HasOne("Mentors.Models.Student", "Student")
                        .WithMany("StudentTecnology")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mentors.Models.Tecnology", "Tecnology")
                        .WithMany("StudentTecnology")
                        .HasForeignKey("TecnologyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
