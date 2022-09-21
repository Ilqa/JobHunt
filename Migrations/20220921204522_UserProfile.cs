using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieReviews.Migrations
{
    public partial class UserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AvailableRegions",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserEducation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    InstitutionName = table.Column<string>(type: "text", nullable: true),
                    Qualification = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEducation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    Designation = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExperiences_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Region = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    AvailableRegions = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ResumeFileName = table.Column<string>(type: "text", nullable: true),
                    VideoFileName = table.Column<string>(type: "text", nullable: true),
                    ResumeFileData = table.Column<byte[]>(type: "bytea", nullable: true),
                    VideoFileData = table.Column<byte[]>(type: "bytea", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    ProfileHeadline = table.Column<string>(type: "text", nullable: true),
                    Skills = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_UserId",
                table: "UserEducation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_UserId",
                table: "UserExperiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CompanyId",
                table: "UserProfiles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEducation");

            migrationBuilder.DropTable(
                name: "UserExperiences");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "AvailableRegions",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
