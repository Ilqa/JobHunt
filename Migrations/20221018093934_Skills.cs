using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieReviews.Migrations
{
    public partial class Skills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "UserExperiences");

            migrationBuilder.AddColumn<int>(
                name: "CompanyNameId",
                table: "UserExperiences",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "UserExperiences",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "UserEducation",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteLink",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => new { x.SkillId, x.JobId });
                    table.ForeignKey(
                        name: "FK_JobSkill_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => new { x.SkillId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_UserSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_UserProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_CompanyNameId",
                table: "UserExperiences",
                column: "CompanyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_UserProfileId",
                table: "UserExperiences",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_UserProfileId",
                table: "UserEducation",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_JobId",
                table: "JobSkill",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_ProfileId",
                table: "UserSkill",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEducation_UserProfiles_UserProfileId",
                table: "UserEducation",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExperiences_Companies_CompanyNameId",
                table: "UserExperiences",
                column: "CompanyNameId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExperiences_UserProfiles_UserProfileId",
                table: "UserExperiences",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEducation_UserProfiles_UserProfileId",
                table: "UserEducation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExperiences_Companies_CompanyNameId",
                table: "UserExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExperiences_UserProfiles_UserProfileId",
                table: "UserExperiences");

            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_UserExperiences_CompanyNameId",
                table: "UserExperiences");

            migrationBuilder.DropIndex(
                name: "IX_UserExperiences_UserProfileId",
                table: "UserExperiences");

            migrationBuilder.DropIndex(
                name: "IX_UserEducation_UserProfileId",
                table: "UserEducation");

            migrationBuilder.DropColumn(
                name: "CompanyNameId",
                table: "UserExperiences");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserExperiences");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserEducation");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "WebsiteLink",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "UserProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "UserExperiences",
                type: "text",
                nullable: true);
        }
    }
}
