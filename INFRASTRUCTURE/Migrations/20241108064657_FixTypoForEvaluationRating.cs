using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class FixTypoForEvaluationRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaulationRatingId",
                table: "EvaluationRatingDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EvaulationRatingId",
                table: "EvaluationRatingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
