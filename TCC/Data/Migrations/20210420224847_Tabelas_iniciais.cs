using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Data.Migrations
{
    public partial class Tabelas_iniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "AspNetUsers",
                type: "VARCHAR(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "AspNetUsers",
                type: "VARCHAR(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AgendaCastramovel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeDistrito = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Regiao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Rua = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Data = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaCastramovel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Tipo = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Cor = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IdadeAno = table.Column<byte>(type: "TINYINT", nullable: false),
                    IdadeMes = table.Column<byte>(type: "TINYINT", nullable: false),
                    Sexo = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Porte = table.Column<string>(type: "CHAR(1)", nullable: false),
                    DataVacida = table.Column<DateTime>(type: "DATE", nullable: false),
                    DataVermifugo = table.Column<DateTime>(type: "DATE", nullable: false),
                    Medicamento = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    NumChip = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clinica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Telefone = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    Foto = table.Column<byte[]>(nullable: true),
                    Descicao = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Denuncia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Foto = table.Column<byte[]>(nullable: true),
                    Status = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeDistrito = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Regiao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Rua = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEndereco_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(nullable: true),
                    AnimalId = table.Column<int>(nullable: false),
                    AgendaCastramovelId = table.Column<int>(nullable: false),
                    Horario = table.Column<string>(type: "VARCHAR(5)", nullable: true),
                    Status = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_AgendaCastramovel_AgendaCastramovelId",
                        column: x => x.AgendaCastramovelId,
                        principalTable: "AgendaCastramovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ClinicaEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeDistrito = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Regiao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Rua = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ClinicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicaEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicaEndereco_Clinica_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DenunciaEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeDistrito = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Regiao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Rua = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DenunciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenunciaEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DenunciaEndereco_Denuncia_DenunciaId",
                        column: x => x.DenunciaId,
                        principalTable: "Denuncia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Cpf",
                table: "AspNetUsers",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Rg",
                table: "AspNetUsers",
                column: "Rg",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_AgendaCastramovelId",
                table: "Agendamento",
                column: "AgendaCastramovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_AnimalId",
                table: "Agendamento",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_UsuarioId",
                table: "Agendamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_UsuarioId",
                table: "Animal",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicaEndereco_ClinicaId",
                table: "ClinicaEndereco",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_DenunciaEndereco_DenunciaId",
                table: "DenunciaEndereco",
                column: "DenunciaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEndereco_UsuarioId",
                table: "UsuarioEndereco",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "ClinicaEndereco");

            migrationBuilder.DropTable(
                name: "DenunciaEndereco");

            migrationBuilder.DropTable(
                name: "UsuarioEndereco");

            migrationBuilder.DropTable(
                name: "AgendaCastramovel");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Denuncia");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Cpf",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Rg",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "AspNetUsers");
        }
    }
}
