using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PregledEvidencija.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspekcijskoTijelos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Inspektorat = table.Column<int>(nullable: false),
                    Nadleznost = table.Column<int>(nullable: false),
                    KontaktOsoba = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspekcijskoTijelos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proizvods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Proizvodjac = table.Column<string>(nullable: true),
                    SerijskiBroj = table.Column<string>(nullable: true),
                    ZemljaPorijekla = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InspekcijskaKontrolas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKontrole = table.Column<DateTime>(nullable: false),
                    NadleznoTijeloID = table.Column<int>(nullable: true),
                    KontrolisaniProizvodID = table.Column<int>(nullable: true),
                    RezultatiKontrole = table.Column<string>(nullable: true),
                    ProizvodSiguran = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspekcijskaKontrolas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InspekcijskaKontrolas_Proizvods_KontrolisaniProizvodID",
                        column: x => x.KontrolisaniProizvodID,
                        principalTable: "Proizvods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspekcijskaKontrolas_InspekcijskoTijelos_NadleznoTijeloID",
                        column: x => x.NadleznoTijeloID,
                        principalTable: "InspekcijskoTijelos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspekcijskaKontrolas_KontrolisaniProizvodID",
                table: "InspekcijskaKontrolas",
                column: "KontrolisaniProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_InspekcijskaKontrolas_NadleznoTijeloID",
                table: "InspekcijskaKontrolas",
                column: "NadleznoTijeloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspekcijskaKontrolas");

            migrationBuilder.DropTable(
                name: "Proizvods");

            migrationBuilder.DropTable(
                name: "InspekcijskoTijelos");
        }
    }
}
