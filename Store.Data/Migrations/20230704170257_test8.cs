using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class test8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83446bff-c89b-42f1-ba19-99aa1a787e39", "AQAAAAIAAYagAAAAEI0EL+htkBuuxdQLJOIvNLfS2aJcRiSNlDck6TLKVvzPrOGHR0OX8TcQWxfGoIiLQg==", "600393d2-84f2-4a15-bf22-c9db4129b331" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1446937-109c-4e1a-97ce-0560442484f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86c995ce-5453-4334-8769-4aef409acc07", "AQAAAAIAAYagAAAAEJda/YfBqSavae8bME2vwldEXc0A/VsVrk+dlLGScYB2mTLinIckbcU5qrQLEWN+PA==", "2a736db9-2bbc-46a6-aaf6-04d841b721a1" });
        }
    }
}
