using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimmingWebApp.DAL.Migrations
{
    public partial class ResultChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Swimmers_SwimmerId",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Swimmers",
                table: "Swimmers");

            migrationBuilder.RenameTable(
                name: "Swimmers",
                newName: "Swimmer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swimmer",
                table: "Swimmer",
                column: "SwimmerId");

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Distance = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    SwimmerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Result_Swimmer_SwimmerId",
                        column: x => x.SwimmerId,
                        principalTable: "Swimmer",
                        principalColumn: "SwimmerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_SwimmerId",
                table: "Result",
                column: "SwimmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Swimmer_SwimmerId",
                table: "Trainings",
                column: "SwimmerId",
                principalTable: "Swimmer",
                principalColumn: "SwimmerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Swimmer_SwimmerId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Swimmer",
                table: "Swimmer");

            migrationBuilder.RenameTable(
                name: "Swimmer",
                newName: "Swimmers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swimmers",
                table: "Swimmers",
                column: "SwimmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Swimmers_SwimmerId",
                table: "Trainings",
                column: "SwimmerId",
                principalTable: "Swimmers",
                principalColumn: "SwimmerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
