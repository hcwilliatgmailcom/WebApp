using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace App.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailPersonen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Person = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailPersonen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(type: "longtext", nullable: false),
                    Beschreibung = table.Column<string>(type: "longtext", nullable: true),
                    Gesendet = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Emailadresse = table.Column<string>(type: "longtext", nullable: false),
                    Vorname = table.Column<string>(type: "longtext", nullable: true),
                    Nachname = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailPersonen");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Personen");
        }
    }
}
