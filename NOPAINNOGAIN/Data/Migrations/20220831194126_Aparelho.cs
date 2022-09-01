using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NOPAINNOGAIN.Data.Migrations
{
    public partial class Aparelho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "tempoFim",
                table: "Aparelhos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tempoFim",
                table: "Aparelhos");
        }
    }
}
