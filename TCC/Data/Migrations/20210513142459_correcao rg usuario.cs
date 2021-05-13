using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Data.Migrations
{
    public partial class correcaorgusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "AspNetUsers",
                type: "VARCHAR(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(9)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "AspNetUsers",
                type: "VARCHAR(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)");
        }
    }
}
