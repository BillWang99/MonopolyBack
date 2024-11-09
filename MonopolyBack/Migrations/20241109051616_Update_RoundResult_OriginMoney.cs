using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonopolyBack.Migrations
{
    /// <inheritdoc />
    public partial class Update_RoundResult_OriginMoney : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginMoney",
                table: "RoundResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginMoney",
                table: "RoundResult");
        }
    }
}
