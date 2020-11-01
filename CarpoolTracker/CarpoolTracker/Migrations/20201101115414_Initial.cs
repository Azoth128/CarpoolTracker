using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriveDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrivePlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DriveDefinitionId = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrivePlans_DriveDefinitions_DriveDefinitionId",
                        column: x => x.DriveDefinitionId,
                        principalTable: "DriveDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Argb = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DriveDefinitionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_DriveDefinitions_DriveDefinitionId",
                        column: x => x.DriveDefinitionId,
                        principalTable: "DriveDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DefinitionId = table.Column<Guid>(nullable: true),
                    DriverId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drives_DriveDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "DriveDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drives_People_DriverId",
                        column: x => x.DriverId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrivePlans_DriveDefinitionId",
                table: "DrivePlans",
                column: "DriveDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_DefinitionId",
                table: "Drives",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_DriverId",
                table: "Drives",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DriveDefinitionId",
                table: "People",
                column: "DriveDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrivePlans");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "DriveDefinitions");
        }
    }
}
