using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentors.Migrations
{
    public partial class MoreContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudyPlace",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vk",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudyPlace",
                table: "Mentors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vk",
                table: "Mentors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudyPlace",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Vk",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "StudyPlace",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Vk",
                table: "Mentors");
        }
    }
}
