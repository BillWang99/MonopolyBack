using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonopolyBack.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoundResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rounds_RoundResultId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.RenameTable(
                name: "Rounds",
                newName: "RoundResult");

            migrationBuilder.AddColumn<string>(
                name: "OptionMethod",
                table: "RoundResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoundResult",
                table: "RoundResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_RoundResult_RoundResultId",
                table: "Players",
                column: "RoundResultId",
                principalTable: "RoundResult",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_RoundResult_RoundResultId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoundResult",
                table: "RoundResult");

            migrationBuilder.DropColumn(
                name: "OptionMethod",
                table: "RoundResult");

            migrationBuilder.RenameTable(
                name: "RoundResult",
                newName: "Rounds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rounds_RoundResultId",
                table: "Players",
                column: "RoundResultId",
                principalTable: "Rounds",
                principalColumn: "Id");
        }
    }
}
