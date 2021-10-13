using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Persistence.Migrations
{
    public partial class TelefoneTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelefoneTipoId",
                table: "Telefones",
                type: "int",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "TelefoneTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneTipo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_TelefoneTipoId",
                table: "Telefones",
                column: "TelefoneTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_TelefoneTipo_TelefoneTipoId",
                table: "Telefones",
                column: "TelefoneTipoId",
                principalTable: "TelefoneTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_TelefoneTipo_TelefoneTipoId",
                table: "Telefones");

            migrationBuilder.DropTable(
                name: "TelefoneTipo");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_TelefoneTipoId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "TelefoneTipoId",
                table: "Telefones");
        }
    }
}
