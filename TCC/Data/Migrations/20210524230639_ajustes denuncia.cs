using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Data.Migrations
{
    public partial class ajustesdenuncia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Denuncia",
                type: "VARCHAR(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HorarioComGente",
                table: "Denuncia",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDenunciado",
                table: "Denuncia",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDenuncia",
                table: "Denuncia",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Denuncia");

            migrationBuilder.DropColumn(
                name: "HorarioComGente",
                table: "Denuncia");

            migrationBuilder.DropColumn(
                name: "NomeDenunciado",
                table: "Denuncia");

            migrationBuilder.DropColumn(
                name: "TipoDenuncia",
                table: "Denuncia");
        }
    }
}
