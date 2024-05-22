using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.departmentId);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    subjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.subjectId);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    classId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    className = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.classId);
                    table.ForeignKey(
                        name: "FK_class_department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "department",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    teacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    major = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.teacherId);
                    table.ForeignKey(
                        name: "FK_teacher_department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "department",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    classId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_student_class_classId",
                        column: x => x.classId,
                        principalTable: "class",
                        principalColumn: "classId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "score",
                columns: table => new
                {
                    subjectId = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    examTimes = table.Column<int>(type: "int", nullable: false),
                    testScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_score", x => x.subjectId);
                    table.ForeignKey(
                        name: "FK_score_student_studentId",
                        column: x => x.studentId,
                        principalTable: "student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_score_subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "subject",
                        principalColumn: "subjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_class_departmentId",
                table: "class",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_score_studentId",
                table: "score",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_student_classId",
                table: "student",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_departmentId",
                table: "teacher",
                column: "departmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "score");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
