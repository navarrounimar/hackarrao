using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletins_Aluno_AlunoUserId",
                table: "Boletins");

            migrationBuilder.DropIndex(
                name: "IX_Boletins_AlunoUserId",
                table: "Boletins");

            migrationBuilder.RenameColumn(
                name: "AlunoUserId",
                table: "Boletins",
                newName: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Boletins",
                newName: "AlunoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletins_AlunoUserId",
                table: "Boletins",
                column: "AlunoUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletins_Aluno_AlunoUserId",
                table: "Boletins",
                column: "AlunoUserId",
                principalTable: "Aluno",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
