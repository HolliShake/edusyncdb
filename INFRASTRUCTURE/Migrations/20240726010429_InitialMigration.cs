using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "AccessLists",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 4,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 5,
                column: "ParentId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_AccessLists_ParentId",
                table: "AccessLists",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessLists_AccessLists_ParentId",
                table: "AccessLists",
                column: "ParentId",
                principalTable: "AccessLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessLists_AccessLists_ParentId",
                table: "AccessLists");

            migrationBuilder.DropIndex(
                name: "IX_AccessLists_ParentId",
                table: "AccessLists");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AccessLists");
        }
    }
}
