using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Week3Deel1.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrumenten",
                columns: table => new
                {
                    InstrumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumenten", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "Popgroepen",
                columns: table => new
                {
                    PopgroepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popgroepen", x => x.PopgroepId);
                });

            migrationBuilder.CreateTable(
                name: "Artiesten",
                columns: table => new
                {
                    ArtiestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstrumentId = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    PopgroepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiesten", x => x.ArtiestId);
                    table.ForeignKey(
                        name: "FK_Artiesten_Instrumenten_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrumenten",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artiesten_Popgroepen_PopgroepId",
                        column: x => x.PopgroepId,
                        principalTable: "Popgroepen",
                        principalColumn: "PopgroepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artiesten_InstrumentId",
                table: "Artiesten",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Artiesten_PopgroepId",
                table: "Artiesten",
                column: "PopgroepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artiesten");

            migrationBuilder.DropTable(
                name: "Instrumenten");

            migrationBuilder.DropTable(
                name: "Popgroepen");
        }
    }
}
