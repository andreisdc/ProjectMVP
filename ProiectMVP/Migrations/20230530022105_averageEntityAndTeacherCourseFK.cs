using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class averageEntityAndTeacherCourseFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCourses",
                schema: "highSchool");

            migrationBuilder.AddColumn<bool>(
                name: "IsThesis",
                schema: "highSchool",
                table: "Grades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                schema: "highSchool",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Averages",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Averages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Averages_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "highSchool",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Averages_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "highSchool",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                schema: "highSchool",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Averages_CourseId",
                schema: "highSchool",
                table: "Averages",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Averages_StudentId",
                schema: "highSchool",
                table: "Averages",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                schema: "highSchool",
                table: "Courses",
                column: "TeacherId",
                principalSchema: "highSchool",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                schema: "highSchool",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Averages",
                schema: "highSchool");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                schema: "highSchool",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsThesis",
                schema: "highSchool",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "highSchool",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                schema: "highSchool",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.TeacherId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "highSchool",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "highSchool",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseId",
                schema: "highSchool",
                table: "TeacherCourses",
                column: "CourseId");
        }
    }
}
