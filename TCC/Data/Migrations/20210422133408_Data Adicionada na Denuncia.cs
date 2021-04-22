using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Data.Migrations
{
    public partial class DataAdicionadanaDenuncia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRealizada",
                table: "Denuncia",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRealizada",
                table: "Denuncia");
        }
    }
}
