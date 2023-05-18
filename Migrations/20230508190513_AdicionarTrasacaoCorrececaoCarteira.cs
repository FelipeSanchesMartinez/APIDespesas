using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace despesas.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTrasacaoCorrececaoCarteira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CarteiraId",
                table: "Transacao",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_CarteiraId",
                table: "Transacao",
                column: "CarteiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacao_Carteira_CarteiraId",
                table: "Transacao",
                column: "CarteiraId",
                principalTable: "Carteira",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacao_Carteira_CarteiraId",
                table: "Transacao");

            migrationBuilder.DropIndex(
                name: "IX_Transacao_CarteiraId",
                table: "Transacao");

            migrationBuilder.DropColumn(
                name: "CarteiraId",
                table: "Transacao");
        }
    }
}
