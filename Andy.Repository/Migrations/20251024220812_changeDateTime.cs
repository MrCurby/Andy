using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Andy.Persistent.Migrations
{
    /// <inheritdoc />
    public partial class changeDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "memo",
                table: "Subscriptions",
                newName: "Memo");

            migrationBuilder.RenameColumn(
                name: "memo",
                table: "EssentialExpenses",
                newName: "Memo");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Subscriptions",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "Memo",
                table: "Subscriptions",
                newName: "memo");

            migrationBuilder.RenameColumn(
                name: "Memo",
                table: "EssentialExpenses",
                newName: "memo");
        }
    }
}
