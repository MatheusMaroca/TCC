using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Data.Migrations
{
    public partial class telefonedenuncia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Denuncia",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Denuncia");
        }
    }
}
