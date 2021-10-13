using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Persistence.Migrations
{
    public partial class Equipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipamentoTipoId = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    EquipamentoMarcaId = table.Column<int>(type: "int", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NumeroSerie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_EquipamentoMarca_EquipamentoMarcaId",
                        column: x => x.EquipamentoMarcaId,
                        principalTable: "EquipamentoMarca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_EquipamentoTipo_EquipamentoTipoId",
                        column: x => x.EquipamentoTipoId,
                        principalTable: "EquipamentoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ClienteId",
                table: "Equipamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_EquipamentoMarcaId",
                table: "Equipamento",
                column: "EquipamentoMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_EquipamentoTipoId",
                table: "Equipamento",
                column: "EquipamentoTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");
        }
    }
}
