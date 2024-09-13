using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class AddedModificationInAccessGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccesses");

            migrationBuilder.DropTable(
                name: "AccessListActions");

            migrationBuilder.DropTable(
                name: "AccessLists");

            migrationBuilder.CreateTable(
                name: "AccessGroupActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupActions_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccessGroupDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccessGroupActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessGroupDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccessGroupDetails_AccessGroupActions_AccessGroupActionId",
                        column: x => x.AccessGroupActionId,
                        principalTable: "AccessGroupActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccessGroupDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupActions_AccessGroupId",
                table: "AccessGroupActions",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessGroupDetails_AccessGroupActionId",
                table: "UserAccessGroupDetails",
                column: "AccessGroupActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessGroupDetails_UserId",
                table: "UserAccessGroupDetails",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccessGroupDetails");

            migrationBuilder.DropTable(
                name: "AccessGroupActions");

            migrationBuilder.CreateTable(
                name: "AccessLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessGroupId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessLists_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessListActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessListId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessListActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessListActions_AccessLists_AccessListId",
                        column: x => x.AccessListId,
                        principalTable: "AccessLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessListActionId = table.Column<int>(type: "int", nullable: false),
                    AccessListId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccesses_AccessListActions_AccessListActionId",
                        column: x => x.AccessListActionId,
                        principalTable: "AccessListActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccesses_AccessLists_AccessListId",
                        column: x => x.AccessListId,
                        principalTable: "AccessLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessListActions_AccessListId",
                table: "AccessListActions",
                column: "AccessListId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLists_AccessGroupId",
                table: "AccessLists",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessLists_Subject",
                table: "AccessLists",
                column: "Subject",
                unique: true,
                filter: "[Subject] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_AccessListActionId",
                table: "UserAccesses",
                column: "AccessListActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_AccessListId",
                table: "UserAccesses",
                column: "AccessListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccesses_UserId",
                table: "UserAccesses",
                column: "UserId");
        }
    }
}
