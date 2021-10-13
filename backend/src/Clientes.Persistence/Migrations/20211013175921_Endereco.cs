using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Persistence.Migrations
{
    public partial class Endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Cliente_ClienteId",
                table: "Telefone");

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    BairroId = table.Column<int>(type: "int", nullable: true),
                    CidadeId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Endereco_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_BairroId",
                table: "Endereco",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Cliente_ClienteId",
                table: "Telefone",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Cliente_ClienteId",
                table: "Telefone");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Cliente_ClienteId",
                table: "Telefone",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
