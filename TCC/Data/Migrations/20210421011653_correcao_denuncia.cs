using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Data.Migrations
{
    public partial class correcao_denuncia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Denuncia",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "Denuncia",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
