using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieReviews.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 1, new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 2, new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 7, new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 8, new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 9, new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 10, new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 3, new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 4, new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 5, new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "Id", "MovieId" },
                keyValues: new object[] { 6, new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b") });

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("7b6bf2e3-5d91-4e75-b62f-7357079acc51"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ACLIds = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: true),
                    AvailableRegions = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieId",
                table: "Review",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MovieId",
                table: "Review");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                columns: new[] { "MovieId", "Id" });

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
    }
}
