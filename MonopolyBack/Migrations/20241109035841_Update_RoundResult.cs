﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonopolyBack.Migrations
{
    /// <inheritdoc />
    public partial class Update_RoundResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "RoundResult",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "RoundResult");
        }
    }
}
