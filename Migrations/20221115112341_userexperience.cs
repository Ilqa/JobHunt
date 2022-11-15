using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReviews.Migrations
{
    public partial class userexperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExperiences_Companies_CompanyNameId",
                table: "UserExperiences");

            migrationBuilder.DropIndex(
                name: "IX_UserExperiences_CompanyNameId",
                table: "UserExperiences");

            migrationBuilder.DropColumn(
                name: "CompanyNameId",
                table: "UserExperiences");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "UserExperiences",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_CompanyId",
                table: "UserExperiences",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExperiences_Companies_CompanyId",
                table: "UserExperiences",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExperiences_Companies_CompanyId",
                table: "UserExperiences");

            migrationBuilder.DropIndex(
                name: "IX_UserExperiences_CompanyId",
                table: "UserExperiences");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "UserExperiences");

            migrationBuilder.AddColumn<int>(
                name: "CompanyNameId",
                table: "UserExperiences",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserExperiences_CompanyNameId",
                table: "UserExperiences",
                column: "CompanyNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExperiences_Companies_CompanyNameId",
                table: "UserExperiences",
                column: "CompanyNameId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
