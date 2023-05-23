using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorSubject",
                schema: "highSchool");

            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                schema: "highSchool",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProfessorSubjects",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorSubjects_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "highSchool",
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "highSchool",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "highSchool",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "highSchool",
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "highSchool",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SemesterId",
                schema: "highSchool",
                table: "StudentSubjects",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubjects_ProfessorId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubjects_SubjectId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_SubjectId",
                schema: "highSchool",
                table: "Semesters",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfessorId",
                schema: "highSchool",
                table: "Users",
                column: "ProfessorId",
                unique: true,
                filter: "[ProfessorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentId",
                schema: "highSchool",
                table: "Users",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Semesters_SemesterId",
                schema: "highSchool",
                table: "StudentSubjects",
                column: "SemesterId",
                principalSchema: "highSchool",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Semesters_SemesterId",
                schema: "highSchool",
                table: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "ProfessorSubjects",
                schema: "highSchool");

            migrationBuilder.DropTable(
                name: "Semesters",
                schema: "highSchool");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "highSchool");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_SemesterId",
                schema: "highSchool",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                schema: "highSchool",
                table: "StudentSubjects");

            migrationBuilder.CreateTable(
                name: "ProfessorSubject",
                schema: "highSchool",
                columns: table => new
                {
                    ProfessorsId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubject", x => new { x.ProfessorsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Professors_ProfessorsId",
                        column: x => x.ProfessorsId,
                        principalSchema: "highSchool",
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalSchema: "highSchool",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubject_SubjectsId",
                schema: "highSchool",
                table: "ProfessorSubject",
                column: "SubjectsId");
        }
    }
}
