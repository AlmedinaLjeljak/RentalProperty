using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalProperty_.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pitanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is2FActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tfa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TwoFKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tfa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nekretnina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nekretnina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nekretnina_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Administrator_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOtkljucano = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LogKretanjePoSistemu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    QueryPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsException = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogKretanjePoSistemu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LogKretanjePoSistemu_KorisnickiNalog_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    SpolID = table.Column<int>(type: "int", nullable: false),
                    DrazavaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Drzava_DrazavaID",
                        column: x => x.DrazavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Korisnik_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Korisnik_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnik_Spol_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spol",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikAgent",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    DatumTermina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VrijemeSat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikAgent", x => new { x.KorisnikId, x.AgentId, x.DatumTermina });
                    table.ForeignKey(
                        name: "FK_KorisnikAgent_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KorisnikAgent_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikNekretnina",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    NekretninaId = table.Column<int>(type: "int", nullable: false),
                    datumIzdavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Izdano = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikNekretnina", x => new { x.NekretninaId, x.KorisnikId, x.datumIzdavanja });
                    table.ForeignKey(
                        name: "FK_KorisnikNekretnina_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_KorisnikNekretnina_Nekretnina_NekretninaId",
                        column: x => x.NekretninaId,
                        principalTable: "Nekretnina",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina" },
                    { 2, "Hrvatska" },
                    { 3, "Srbija" }
                });

            migrationBuilder.InsertData(
                table: "FAQ",
                columns: new[] { "Id", "Odgovor", "Pitanje" },
                values: new object[,]
                {
                    { 1, "Cijena zavisi od lokacije i vaseg izbora sta zelite iznajmiti", "Koja je cijena izdavanja nekretnina?" },
                    { 2, "Naravno, nudimo vam na raspolaganje sve agente", "Da li imate agente koji nam mogu pokazati nekretnine" },
                    { 3, "Cijena zavisi od kvadrature zeljene nekretnine", "Od cega zavisi cijena nekretnine" },
                    { 4, "Na svakoj nekrentini je naznaceno da li je nekretninu moguce samo iznajmiti ili cak i kupiti", "Da li je moguce naznacenu nekretninu i kupiti a ne samo iznajmiti" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Mostar" },
                    { 2, "Sarajevo" },
                    { 3, "Zagreb" },
                    { 4, "Beograd" },
                    { 5, "Konjic" },
                    { 6, "Tuzla" },
                    { 7, "Zenica" },
                    { 8, "Bugojno" },
                    { 9, "Bihac" },
                    { 10, "Banja Luka" }
                });

            migrationBuilder.InsertData(
                table: "KorisnickiNalog",
                columns: new[] { "ID", "Password", "Username", "is2FActive" },
                values: new object[,]
                {
                    { 1, "admin", "admin", false },
                    { 2, "host", "host", false },
                    { 3, "almedina123", "almedinalj", true },
                    { 4, "alema123", "alemad", true },
                    { 5, "adil123", "adilj", true },
                    { 6, "denis123", "denism", true }
                });

            migrationBuilder.InsertData(
                table: "Recenzija",
                columns: new[] { "Id", "Ime", "Prezime", "Slika", "Tekst" },
                values: new object[,]
                {
                    { 1, "Alema", "Duvnjak", "assets/1rec.jpg", "Dugo trazenu nekretninu pronasli smo pomocu ove agencije za izdavanje nekretnina. Zadovoljni korisnici. " },
                    { 2, "Almedina", "Ljeljak", "assets/2rec.jpg", "Iznajmljivali smo nekreninu preko ove agencije dugi niz godina,prezadovoljni smo. " },
                    { 3, "Emina", "Junuz", "assets/3rec.jpg", "Zadovoljni korisnici svih usluga koje nudi data agencija za iznajmljivanje." },
                    { 4, "Iris", "Memic", "assets/4rec.jpg", "Usluga je na zadovoljavajucem nivou." }
                });

            migrationBuilder.InsertData(
                table: "Spol",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Zenski" },
                    { 2, "Muski" }
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[,]
                {
                    { 1, "Almedina", "Ljeljak" },
                    { 2, "Alema", "Duvnjak" }
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "ID", "BrojTelefona", "DrazavaID", "GradID", "Ime", "Prezime", "Slika", "SpolID" },
                values: new object[,]
                {
                    { 3, "062123123", 1, 5, "Almedina", "Ljeljak", "assets/1korisnik.jpg", 1 },
                    { 4, "062345678", 1, 8, "Alema", "Duvnjak", "assets/2korisnik.jpg", 1 },
                    { 5, "062897855", 2, 3, "Adil", "Joldic", "assets/3korisnik.jpg", 2 },
                    { 6, "061789635", 3, 4, "Denis", "Music", "assets/4korisnik.jpg", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_DrazavaID",
                table: "Korisnik",
                column: "DrazavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_GradID",
                table: "Korisnik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_SpolID",
                table: "Korisnik",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikAgent_AgentId",
                table: "KorisnikAgent",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikNekretnina_KorisnikId",
                table: "KorisnikNekretnina",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_LogKretanjePoSistemu_KorisnikID",
                table: "LogKretanjePoSistemu",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Nekretnina_KategorijaID",
                table: "Nekretnina",
                column: "KategorijaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "KorisnikAgent");

            migrationBuilder.DropTable(
                name: "KorisnikNekretnina");

            migrationBuilder.DropTable(
                name: "LogKretanjePoSistemu");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Tfa");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Nekretnina");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Spol");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
