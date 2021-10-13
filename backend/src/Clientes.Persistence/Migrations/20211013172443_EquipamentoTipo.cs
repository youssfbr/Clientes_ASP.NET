﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Persistence.Migrations
{
    public partial class EquipamentoTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipamentoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoTipo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentoTipo");
        }
    }
}
