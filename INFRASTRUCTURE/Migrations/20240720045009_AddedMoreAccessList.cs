using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreAccessList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Subject",
                value: "User");

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Subject",
                value: "Student");

            migrationBuilder.InsertData(
                table: "AccessLists",
                columns: new[] { "Id", "IsGroup", "Subject" },
                values: new object[,]
                {
                    { 4, true, "Admin" },
                    { 5, true, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "AccessListActions",
                columns: new[] { "Id", "AccessListId", "Action" },
                values: new object[,]
                {
                    { 16, 4, "all" },
                    { 17, 4, "read" },
                    { 18, 4, "create" },
                    { 19, 4, "update" },
                    { 20, 4, "delete" },
                    { 21, 5, "all" },
                    { 22, 5, "read" },
                    { 23, 5, "create" },
                    { 24, 5, "update" },
                    { 25, 5, "delete" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Subject",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Subject",
                value: "SuperAdmin");
        }
    }
}
