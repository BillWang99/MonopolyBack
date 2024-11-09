using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonopolyBack.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_GameHistory_gamehistoryId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "gamehistoryId",
                table: "Players",
                newName: "GameHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_gamehistoryId",
                table: "Players",
                newName: "IX_Players_GameHistoryId");

            migrationBuilder.AlterColumn<int>(
                name: "GameHistoryId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_GameHistory_GameHistoryId",
                table: "Players",
                column: "GameHistoryId",
                principalTable: "GameHistory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_GameHistory_GameHistoryId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "GameHistoryId",
                table: "Players",
                newName: "gamehistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_GameHistoryId",
                table: "Players",
                newName: "IX_Players_gamehistoryId");

            migrationBuilder.AlterColumn<int>(
                name: "gamehistoryId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_GameHistory_gamehistoryId",
                table: "Players",
                column: "gamehistoryId",
                principalTable: "GameHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
