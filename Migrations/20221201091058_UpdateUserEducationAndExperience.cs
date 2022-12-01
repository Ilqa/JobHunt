using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReviews.Migrations
{
    public partial class UpdateUserEducationAndExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Qualification",
                table: "UserEducation",
                newName: "Grade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "UserExperiences",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "CurrentlyWorking",
                table: "UserExperiences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "UserExperiences",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DegreeTitle",
                table: "UserEducation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldOfStudy",
                table: "UserEducation",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentlyWorking",
                table: "UserExperiences");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "UserExperiences");

            migrationBuilder.DropColumn(
                name: "DegreeTitle",
                table: "UserEducation");

            migrationBuilder.DropColumn(
                name: "FieldOfStudy",
                table: "UserEducation");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "UserEducation",
                newName: "Qualification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "UserExperiences",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
