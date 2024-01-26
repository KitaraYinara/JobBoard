using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Server.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44e7023c-1572-4772-90bf-4db5c12934c2", "AQAAAAIAAYagAAAAEOWuwVm9GqzWDU6BAEZ64XpqOg/dZO0YZ+doINHGot1cDV5ZliObk8Oc3rZN3FmlTg==", "d9690bc4-952b-44dc-b1d4-24aeae4890db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f964124-667f-4423-933c-57363d282d9d", "AQAAAAIAAYagAAAAEFQH5DiZYkFNlX+YghflLctf4xe6x9kPQugzonAhzacdL9fsdEufR2pfi3BkjoFMtQ==", "176973e0-3380-4169-b79a-5332f0b81ba0" });
        }
    }
}
