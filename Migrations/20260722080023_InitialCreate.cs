using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Misici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Misici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treneri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Certifikat = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Ime = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treneri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vjezbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Tezina = table.Column<int>(type: "INTEGER", nullable: false),
                    Vrsta = table.Column<int>(type: "INTEGER", nullable: false),
                    JeVremenska = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vjezbe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KilazaPocetna = table.Column<int>(type: "INTEGER", nullable: true),
                    Visina = table.Column<int>(type: "INTEGER", nullable: true),
                    DatumPocetka = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TrenerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cilj = table.Column<int>(type: "INTEGER", nullable: false),
                    Ime = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klijenti_Treneri_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "Treneri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sabloni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    TrenerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabloni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sabloni_Treneri_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "Treneri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treninzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    TrajanjeMinuta = table.Column<int>(type: "INTEGER", nullable: false),
                    TrenerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treninzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treninzi_Treneri_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "Treneri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VjezbaMisici",
                columns: table => new
                {
                    VjezbaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MisicId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VjezbaMisici", x => new { x.VjezbaId, x.MisicId });
                    table.ForeignKey(
                        name: "FK_VjezbaMisici_Misici_MisicId",
                        column: x => x.MisicId,
                        principalTable: "Misici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VjezbaMisici_Vjezbe_VjezbaId",
                        column: x => x.VjezbaId,
                        principalTable: "Vjezbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tezina = table.Column<double>(type: "REAL", nullable: false),
                    Datum = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    KlijentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressRecords_Klijenti_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SablonStavke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrojSetova = table.Column<int>(type: "INTEGER", nullable: true),
                    BrojPonavljanja = table.Column<int>(type: "INTEGER", nullable: true),
                    TrajanjeSekundi = table.Column<int>(type: "INTEGER", nullable: true),
                    Redoslijed = table.Column<int>(type: "INTEGER", nullable: false),
                    SablonId = table.Column<int>(type: "INTEGER", nullable: false),
                    VjezbaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SablonStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SablonStavke_Sabloni_SablonId",
                        column: x => x.SablonId,
                        principalTable: "Sabloni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SablonStavke_Vjezbe_VjezbaId",
                        column: x => x.VjezbaId,
                        principalTable: "Vjezbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KlijentTreninzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DatumDodjele = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    KlijentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreningId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlijentTreninzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KlijentTreninzi_Klijenti_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KlijentTreninzi_Treninzi_TreningId",
                        column: x => x.TreningId,
                        principalTable: "Treninzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VjezbaDodjele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrojSetova = table.Column<int>(type: "INTEGER", nullable: true),
                    BrojPonavljanja = table.Column<int>(type: "INTEGER", nullable: true),
                    TrajanjeSekundi = table.Column<int>(type: "INTEGER", nullable: true),
                    Redoslijed = table.Column<int>(type: "INTEGER", nullable: false),
                    TreningId = table.Column<int>(type: "INTEGER", nullable: false),
                    VjezbaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VjezbaDodjele", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VjezbaDodjele_Treninzi_TreningId",
                        column: x => x.TreningId,
                        principalTable: "Treninzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VjezbaDodjele_Vjezbe_VjezbaId",
                        column: x => x.VjezbaId,
                        principalTable: "Vjezbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klijenti_TrenerId",
                table: "Klijenti",
                column: "TrenerId");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentTreninzi_KlijentId",
                table: "KlijentTreninzi",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentTreninzi_TreningId",
                table: "KlijentTreninzi",
                column: "TreningId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressRecords_KlijentId",
                table: "ProgressRecords",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sabloni_TrenerId",
                table: "Sabloni",
                column: "TrenerId");

            migrationBuilder.CreateIndex(
                name: "IX_SablonStavke_SablonId",
                table: "SablonStavke",
                column: "SablonId");

            migrationBuilder.CreateIndex(
                name: "IX_SablonStavke_VjezbaId",
                table: "SablonStavke",
                column: "VjezbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Treninzi_TrenerId",
                table: "Treninzi",
                column: "TrenerId");

            migrationBuilder.CreateIndex(
                name: "IX_VjezbaDodjele_TreningId",
                table: "VjezbaDodjele",
                column: "TreningId");

            migrationBuilder.CreateIndex(
                name: "IX_VjezbaDodjele_VjezbaId",
                table: "VjezbaDodjele",
                column: "VjezbaId");

            migrationBuilder.CreateIndex(
                name: "IX_VjezbaMisici_MisicId",
                table: "VjezbaMisici",
                column: "MisicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KlijentTreninzi");

            migrationBuilder.DropTable(
                name: "ProgressRecords");

            migrationBuilder.DropTable(
                name: "SablonStavke");

            migrationBuilder.DropTable(
                name: "VjezbaDodjele");

            migrationBuilder.DropTable(
                name: "VjezbaMisici");

            migrationBuilder.DropTable(
                name: "Klijenti");

            migrationBuilder.DropTable(
                name: "Sabloni");

            migrationBuilder.DropTable(
                name: "Treninzi");

            migrationBuilder.DropTable(
                name: "Misici");

            migrationBuilder.DropTable(
                name: "Vjezbe");

            migrationBuilder.DropTable(
                name: "Treneri");
        }
    }
}
