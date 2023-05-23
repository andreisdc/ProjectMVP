using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class TableRenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_StudentSubjects_StudentSubjectId",
                schema: "highSchool",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_ClassMasterId",
                schema: "highSchool",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentSubjects_StudentSubjectId",
                schema: "highSchool",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Subjects_CourseId",
                schema: "highSchool",
                table: "Semesters");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyMaterials_Subjects_SubjectId",
                schema: "highSchool",
                table: "StudyMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Classes_GroupId",
                schema: "highSchool",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classes_ClassId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ProfessorSubjects",
                schema: "highSchool");

            migrationBuilder.DropTable(
                name: "StudentSubjects",
                schema: "highSchool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                schema: "highSchool",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                schema: "highSchool",
                table: "Classes");

            migrationBuilder.RenameTable(
                name: "Subjects",
                schema: "highSchool",
                newName: "Courses",
                newSchema: "highSchool");

            migrationBuilder.RenameTable(
                name: "Classes",
                schema: "highSchool",
                newName: "Groups",
                newSchema: "highSchool");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_GroupId",
                schema: "highSchool",
                table: "Courses",
                newName: "IX_Courses_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_ClassMasterId",
                schema: "highSchool",
                table: "Groups",
                newName: "IX_Groups_ClassMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                schema: "highSchool",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                schema: "highSchool",
                table: "Groups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "highSchool",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "highSchool",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "highSchool",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "highSchool",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "highSchool",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_SemesterId",
                schema: "highSchool",
                table: "StudentCourses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_SubjectId",
                schema: "highSchool",
                table: "StudentCourses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_UserId",
                schema: "highSchool",
                table: "StudentCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_SubjectId",
                schema: "highSchool",
                table: "TeacherCourses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_UserId",
                schema: "highSchool",
                table: "TeacherCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_StudentCourses_StudentSubjectId",
                schema: "highSchool",
                table: "Absences",
                column: "StudentSubjectId",
                principalSchema: "highSchool",
                principalTable: "StudentCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Groups_GroupId",
                schema: "highSchool",
                table: "Courses",
                column: "GroupId",
                principalSchema: "highSchool",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_StudentCourses_StudentSubjectId",
                schema: "highSchool",
                table: "Grades",
                column: "StudentSubjectId",
                principalSchema: "highSchool",
                principalTable: "StudentCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_ClassMasterId",
                schema: "highSchool",
                table: "Groups",
                column: "ClassMasterId",
                principalSchema: "highSchool",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Courses_CourseId",
                schema: "highSchool",
                table: "Semesters",
                column: "CourseId",
                principalSchema: "highSchool",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyMaterials_Courses_SubjectId",
                schema: "highSchool",
                table: "StudyMaterials",
                column: "SubjectId",
                principalSchema: "highSchool",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_ClassId",
                schema: "highSchool",
                table: "Users",
                column: "ClassId",
                principalSchema: "highSchool",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_StudentCourses_StudentSubjectId",
                schema: "highSchool",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Groups_GroupId",
                schema: "highSchool",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentCourses_StudentSubjectId",
                schema: "highSchool",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_ClassMasterId",
                schema: "highSchool",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Courses_CourseId",
                schema: "highSchool",
                table: "Semesters");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyMaterials_Courses_SubjectId",
                schema: "highSchool",
                table: "StudyMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_ClassId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropTable(
                name: "StudentCourses",
                schema: "highSchool");

            migrationBuilder.DropTable(
                name: "TeacherCourses",
                schema: "highSchool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                schema: "highSchool",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                schema: "highSchool",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Groups",
                schema: "highSchool",
                newName: "Classes",
                newSchema: "highSchool");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "highSchool",
                newName: "Subjects",
                newSchema: "highSchool");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ClassMasterId",
                schema: "highSchool",
                table: "Classes",
                newName: "IX_Classes_ClassMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_GroupId",
                schema: "highSchool",
                table: "Subjects",
                newName: "IX_Subjects_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                schema: "highSchool",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                schema: "highSchool",
                table: "Subjects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProfessorSubjects",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "highSchool",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubjects_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "highSchool",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "highSchool",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "highSchool",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "highSchool",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubjects_SubjectId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubjects_UserId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SemesterId",
                schema: "highSchool",
                table: "StudentSubjects",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                schema: "highSchool",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_UserId",
                schema: "highSchool",
                table: "StudentSubjects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_StudentSubjects_StudentSubjectId",
                schema: "highSchool",
                table: "Absences",
                column: "StudentSubjectId",
                principalSchema: "highSchool",
                principalTable: "StudentSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_ClassMasterId",
                schema: "highSchool",
                table: "Classes",
                column: "ClassMasterId",
                principalSchema: "highSchool",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_StudentSubjects_StudentSubjectId",
                schema: "highSchool",
                table: "Grades",
                column: "StudentSubjectId",
                principalSchema: "highSchool",
                principalTable: "StudentSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Subjects_CourseId",
                schema: "highSchool",
                table: "Semesters",
                column: "CourseId",
                principalSchema: "highSchool",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyMaterials_Subjects_SubjectId",
                schema: "highSchool",
                table: "StudyMaterials",
                column: "SubjectId",
                principalSchema: "highSchool",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Classes_GroupId",
                schema: "highSchool",
                table: "Subjects",
                column: "GroupId",
                principalSchema: "highSchool",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Classes_ClassId",
                schema: "highSchool",
                table: "Users",
                column: "ClassId",
                principalSchema: "highSchool",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
