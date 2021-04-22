using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Data.Migrations
{
    public partial class correcao_clinica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClinicaEndereco_ClinicaId",
                table: "ClinicaEndereco");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Clinica",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicaEndereco_ClinicaId",
                table: "ClinicaEndereco",
                column: "ClinicaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClinicaEndereco_ClinicaId",
                table: "ClinicaEndereco");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "Clinica",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicaEndereco_ClinicaId",
                table: "ClinicaEndereco",
                column: "ClinicaId");
        }
    }
}
