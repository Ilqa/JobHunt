using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieReviews.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reviewer = table.Column<string>(type: "text", nullable: true),
                    Stars = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => new { x.MovieId, x.Id });
                    table.ForeignKey(
                        name: "FK_Review_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"), "Superman and Lois" },
                    { new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"), "Avengers: Endgame" },
                    { new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), "Game of Thrones" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "MovieId", "Reviewer", "Stars" },
                values: new object[,]
                {
                    { 1, new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"), "A", 4 },
                    { 2, new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"), "B", 5 },
                    { 7, new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"), "A", 2 },
                    { 8, new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"), "B", 1 },
                    { 9, new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"), "G", 3 },
                    { 10, new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"), "H", 4 },
                    { 3, new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), "A", 4 },
                    { 4, new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), "D", 5 },
                    { 5, new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), "E", 3 },
                    { 6, new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), "F", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
