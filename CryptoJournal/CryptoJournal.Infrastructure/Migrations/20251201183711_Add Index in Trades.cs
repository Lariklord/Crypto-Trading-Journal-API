using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexinTrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trades_TraderId",
                table: "Trades");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_TraderId_EntryDate",
                table: "Trades",
                columns: new[] { "TraderId", "EntryDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trades_TraderId_EntryDate",
                table: "Trades");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_TraderId",
                table: "Trades",
                column: "TraderId");
        }
    }
}
