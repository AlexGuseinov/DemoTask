using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class status_added_toWatchlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Watchlists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 10, 40, 54, 490, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 10, 40, 54, 490, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_StatusId",
                table: "Watchlists",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_Statuses_StatusId",
                table: "Watchlists",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_Statuses_StatusId",
                table: "Watchlists");

            migrationBuilder.DropIndex(
                name: "IX_Watchlists_StatusId",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Watchlists");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 10, 24, 6, 222, DateTimeKind.Utc).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 24, 10, 24, 6, 222, DateTimeKind.Utc).AddTicks(1071));
        }
    }
}
