using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedReferenceIdToAccesssList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "AccessLists",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReferenceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReferenceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReferenceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReferenceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReferenceId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "AccessLists");
        }
    }
}
