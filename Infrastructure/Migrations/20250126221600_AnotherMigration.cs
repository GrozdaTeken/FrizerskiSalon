using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnotherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blacklists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Razlog = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blacklists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frizeri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frizeri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Godisnji",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GodisnjiOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GodisnjiDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Godisnji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Godisnji_Frizeri_FriId",
                        column: x => x.FriId,
                        principalTable: "Frizeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Termin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Frizeri_FriId",
                        column: x => x.FriId,
                        principalTable: "Frizeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smene",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smene_Frizeri_FriId",
                        column: x => x.FriId,
                        principalTable: "Frizeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageQueues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageSubject = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageQueues_Rezervacije_RezId",
                        column: x => x.RezId,
                        principalTable: "Rezervacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Godisnji_FriId",
                table: "Godisnji",
                column: "FriId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageQueues_RezId",
                table: "MessageQueues",
                column: "RezId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_FriId",
                table: "Rezervacije",
                column: "FriId");

            migrationBuilder.CreateIndex(
                name: "IX_Smene_FriId",
                table: "Smene",
                column: "FriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blacklists");

            migrationBuilder.DropTable(
                name: "Godisnji");

            migrationBuilder.DropTable(
                name: "MessageQueues");

            migrationBuilder.DropTable(
                name: "Smene");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Frizeri");
        }
    }
}
