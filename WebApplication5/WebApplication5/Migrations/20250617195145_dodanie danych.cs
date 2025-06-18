using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class dodaniedanych : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prelegent",
                columns: table => new
                {
                    IdPrelegent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prelegent", x => x.IdPrelegent);
                });

            migrationBuilder.CreateTable(
                name: "Uczestnik",
                columns: table => new
                {
                    IdUczestnik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uczestnik", x => x.IdUczestnik);
                });

            migrationBuilder.CreateTable(
                name: "Wydarzenia",
                columns: table => new
                {
                    IdWydarzenie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxUczestnik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydarzenia", x => x.IdWydarzenie);
                });

            migrationBuilder.CreateTable(
                name: "UczestnikWydarzenie",
                columns: table => new
                {
                    UczestnikId = table.Column<int>(type: "int", nullable: false),
                    WydarzenieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UczestnikWydarzenie", x => new { x.UczestnikId, x.WydarzenieId });
                    table.ForeignKey(
                        name: "FK_UczestnikWydarzenie_Uczestnik_UczestnikId",
                        column: x => x.UczestnikId,
                        principalTable: "Uczestnik",
                        principalColumn: "IdUczestnik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UczestnikWydarzenie_Wydarzenia_WydarzenieId",
                        column: x => x.WydarzenieId,
                        principalTable: "Wydarzenia",
                        principalColumn: "IdWydarzenie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WydarzeniePrelegent",
                columns: table => new
                {
                    PrelegentId = table.Column<int>(type: "int", nullable: false),
                    WydarzenieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WydarzeniePrelegent", x => new { x.PrelegentId, x.WydarzenieId });
                    table.ForeignKey(
                        name: "FK_WydarzeniePrelegent_Prelegent_PrelegentId",
                        column: x => x.PrelegentId,
                        principalTable: "Prelegent",
                        principalColumn: "IdPrelegent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WydarzeniePrelegent_Wydarzenia_WydarzenieId",
                        column: x => x.WydarzenieId,
                        principalTable: "Wydarzenia",
                        principalColumn: "IdWydarzenie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Prelegent",
                columns: new[] { "IdPrelegent", "Email", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "tomasz.zielinski@example.com", "Tomasz", "Zieliński" },
                    { 2, "k.wisniewska@example.com", "Katarzyna", "Wiśniewska" }
                });

            migrationBuilder.InsertData(
                table: "Uczestnik",
                columns: new[] { "IdUczestnik", "Email", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "jan.kowalski@gmail.com", "Jan", "Kowalski" },
                    { 2, "anna.nowak@gmail.com", "Anna", "Nowak" },
                    { 3, "coco.loco@gmail.com", "Coco", "Loco" },
                    { 4, "zygzak@gmail.com", "Zygzak", "McQueen" },
                    { 5, "tomasz@gmail.com", "Tomasz", "Hajto" },
                    { 6, "zbigniew@gmail.com", "Zbigniew", "Golonka" },
                    { 7, "kolanko@gmail.com", "Max", "Kolanko" }
                });

            migrationBuilder.InsertData(
                table: "Wydarzenia",
                columns: new[] { "IdWydarzenie", "Data", "MaxUczestnik", "Opis", "Tytul" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Wydarzenie poświęcone nowym technologiom.", "Konferencja IT" },
                    { 2, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Praktyczne warsztaty z uczenia maszynowego.", "Warsztaty AI" }
                });

            migrationBuilder.InsertData(
                table: "UczestnikWydarzenie",
                columns: new[] { "UczestnikId", "WydarzenieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "WydarzeniePrelegent",
                columns: new[] { "PrelegentId", "WydarzenieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UczestnikWydarzenie_WydarzenieId",
                table: "UczestnikWydarzenie",
                column: "WydarzenieId");

            migrationBuilder.CreateIndex(
                name: "IX_WydarzeniePrelegent_WydarzenieId",
                table: "WydarzeniePrelegent",
                column: "WydarzenieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UczestnikWydarzenie");

            migrationBuilder.DropTable(
                name: "WydarzeniePrelegent");

            migrationBuilder.DropTable(
                name: "Uczestnik");

            migrationBuilder.DropTable(
                name: "Prelegent");

            migrationBuilder.DropTable(
                name: "Wydarzenia");
        }
    }
}
