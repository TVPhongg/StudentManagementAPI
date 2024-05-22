using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    public partial class V30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_score",
                table: "score");

            migrationBuilder.DropIndex(
                name: "IX_score_studentId",
                table: "score");

            migrationBuilder.AddPrimaryKey(
                name: "PK_score",
                table: "score",
                columns: new[] { "studentId", "subjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_score_subjectId",
                table: "score",
                column: "subjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_score",
                table: "score");

            migrationBuilder.DropIndex(
                name: "IX_score_subjectId",
                table: "score");

            migrationBuilder.AddPrimaryKey(
                name: "PK_score",
                table: "score",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_score_studentId",
                table: "score",
                column: "studentId");
        }
    }
}
