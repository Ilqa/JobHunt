using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReviews.Migrations
{
    public partial class UpdateJobAndUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "UserProfiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UserProfiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "UserProfiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Jobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Jobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Jobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Jobs",
                type: "text",
                nullable: true);
        }
    }
}
