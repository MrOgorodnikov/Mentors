using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mentors.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    CurrentStudentCount = table.Column<int>(nullable: false),
                    ExperienceInYear = table.Column<int>(nullable: false),
                    MaxStudentCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PlaceOfWork = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnologies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentorStudent",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorStudent", x => new { x.MentorId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_MentorStudent_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorTecnology",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false),
                    TecnologyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorTecnology", x => new { x.MentorId, x.TecnologyId });
                    table.ForeignKey(
                        name: "FK_MentorTecnology_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorTecnology_Tecnologies_TecnologyId",
                        column: x => x.TecnologyId,
                        principalTable: "Tecnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTecnology",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    TecnologyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTecnology", x => new { x.StudentId, x.TecnologyId });
                    table.ForeignKey(
                        name: "FK_StudentTecnology_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTecnology_Tecnologies_TecnologyId",
                        column: x => x.TecnologyId,
                        principalTable: "Tecnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentorStudent_StudentId",
                table: "MentorStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorTecnology_TecnologyId",
                table: "MentorTecnology",
                column: "TecnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTecnology_TecnologyId",
                table: "StudentTecnology",
                column: "TecnologyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentorStudent");

            migrationBuilder.DropTable(
                name: "MentorTecnology");

            migrationBuilder.DropTable(
                name: "StudentTecnology");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Tecnologies");
        }
    }
}
