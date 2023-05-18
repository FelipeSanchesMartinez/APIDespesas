using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace despesas.Migrations
{
    /// <inheritdoc />
    public partial class alterandoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BancoId",
                table: "Carteira",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Carteira_BancoId",
                table: "Carteira",
                column: "BancoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carteira_Banco_BancoId",
                table: "Carteira",
                column: "BancoId",
                principalTable: "Banco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carteira_Banco_BancoId",
                table: "Carteira");

            migrationBuilder.DropIndex(
                name: "IX_Carteira_BancoId",
                table: "Carteira");

            migrationBuilder.DropColumn(
                name: "BancoId",
                table: "Carteira");
        }
    }
}
