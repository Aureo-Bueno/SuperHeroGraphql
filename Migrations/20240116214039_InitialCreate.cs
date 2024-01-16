using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperHeroesGraphQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperHero",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperHeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_SuperHero_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "SuperHero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Power",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuperPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperHeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Power", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Power_SuperHero_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "SuperHero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "SuperHeroId", "Title" },
                values: new object[,]
                {
                    { new Guid("1852deb8-bc3e-4931-901c-b65d855ba8c2"), "Superman is a fictional superhero. The character was created by writer Jerry Siegel and artist Joe Shuster, and first appeared in the comic book Action Comics #1 (cover-dated June 1938 and published April 18, 1938).", new Guid("00000000-0000-0000-0000-000000000000"), "Superman" },
                    { new Guid("fb584691-98ce-4951-9293-15be12ca6cd0"), "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger,[2][3] and first appeared in Detective Comics #27 (May 1939).", new Guid("00000000-0000-0000-0000-000000000000"), "Batman" }
                });

            migrationBuilder.InsertData(
                table: "SuperHero",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1852deb8-bc3e-4931-901c-b65d855ba8c2"), "Superman is a fictional superhero. The character was created by writer Jerry Siegel and artist Joe Shuster, and first appeared in the comic book Action Comics #1 (cover-dated June 1938 and published April 18, 1938).", "Superman" },
                    { new Guid("fb584691-98ce-4951-9293-15be12ca6cd0"), "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger,[2][3] and first appeared in Detective Comics #27 (May 1939).", "Batman" }
                });

            migrationBuilder.InsertData(
                table: "Power",
                columns: new[] { "Id", "Description", "SuperHeroId", "SuperPower" },
                values: new object[,]
                {
                    { new Guid("1852deb8-bc3e-4931-901c-b65d855ba8c2"), "Superman's powers include incredible strength, the ability to fly, and invulnerability.", new Guid("1852deb8-bc3e-4931-901c-b65d855ba8c2"), "Superhuman strength, speed, stamina and durability" },
                    { new Guid("fb584691-98ce-4951-9293-15be12ca6cd0"), "Batman's primary character traits can be summarized as \"wealthy, physical prowess, deductive abilities and obsession\".", new Guid("fb584691-98ce-4951-9293-15be12ca6cd0"), "Genius-level intellect" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_SuperHeroId",
                table: "Movie",
                column: "SuperHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Power_SuperHeroId",
                table: "Power",
                column: "SuperHeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Power");

            migrationBuilder.DropTable(
                name: "SuperHero");
        }
    }
}
