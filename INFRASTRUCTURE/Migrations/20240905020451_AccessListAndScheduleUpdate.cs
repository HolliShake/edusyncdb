using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AccessListAndScheduleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessLists_AccessLists_ParentId",
                table: "AccessLists");

            migrationBuilder.DropIndex(
                name: "IX_AccessLists_ParentId",
                table: "AccessLists");

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AccessListActions",
                keyColumn: "Id",
                keyValue: 15);

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccessLists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "IsGroup",
                table: "AccessLists");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AccessLists");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "AccessLists");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AccessLists");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Schedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Schedules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccessGroupId",
                table: "AccessLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CreatedByUserId",
                table: "Schedules",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Users_CreatedByUserId",
                table: "Schedules",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Users_CreatedByUserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CreatedByUserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccessGroupId",
                table: "AccessLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsGroup",
                table: "AccessLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "AccessLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "AccessLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AccessLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AccessLists",
                columns: new[] { "Id", "AccessGroupId", "IsGroup", "ParentId", "ReferenceId", "Subject", "Type" },
                values: new object[,]
                {
                    { 1, null, true, null, null, "Auth", 1 },
                    { 2, null, true, null, null, "User", 1 },
                    { 3, null, true, null, null, "Student", 1 },
                    { 4, null, true, null, null, "Admin", 1 },
                    { 5, null, true, null, null, "SuperAdmin", 1 }
                });

            migrationBuilder.InsertData(
                table: "AccessListActions",
                columns: new[] { "Id", "AccessListId", "Action" },
                values: new object[,]
                {
                    { 1, 1, "all" },
                    { 2, 1, "read" },
                    { 3, 1, "create" },
                    { 4, 1, "update" },
                    { 5, 1, "delete" },
                    { 6, 2, "all" },
                    { 7, 2, "read" },
                    { 8, 2, "create" },
                    { 9, 2, "update" },
                    { 10, 2, "delete" },
                    { 11, 3, "all" },
                    { 12, 3, "read" },
                    { 13, 3, "create" },
                    { 14, 3, "update" },
                    { 15, 3, "delete" },
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

            migrationBuilder.CreateIndex(
                name: "IX_AccessLists_ParentId",
                table: "AccessLists",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessLists_AccessLists_ParentId",
                table: "AccessLists",
                column: "ParentId",
                principalTable: "AccessLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
