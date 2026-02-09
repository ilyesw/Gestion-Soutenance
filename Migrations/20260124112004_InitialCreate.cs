using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestSoutenance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateNaiss = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Societes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lib = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PFEs",
                columns: table => new
                {
                    PFEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DateD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadrantID = table.Column<int>(type: "int", nullable: false),
                    SocieteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFEs", x => x.PFEID);
                    table.ForeignKey(
                        name: "FK_PFEs_Enseignants_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Enseignants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PFEs_Societes_SocieteID",
                        column: x => x.SocieteID,
                        principalTable: "Societes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PFE_Etudiants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PFEID = table.Column<int>(type: "int", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE_Etudiants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PFE_Etudiants_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PFE_Etudiants_PFEs_PFEID",
                        column: x => x.PFEID,
                        principalTable: "PFEs",
                        principalColumn: "PFEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PFE_Etudiants_EtudiantId",
                table: "PFE_Etudiants",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_Etudiants_PFEID",
                table: "PFE_Etudiants",
                column: "PFEID");

            migrationBuilder.CreateIndex(
                name: "IX_PFEs_EncadrantID",
                table: "PFEs",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_PFEs_SocieteID",
                table: "PFEs",
                column: "SocieteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PFE_Etudiants");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "PFEs");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Societes");
        }
    }
}
