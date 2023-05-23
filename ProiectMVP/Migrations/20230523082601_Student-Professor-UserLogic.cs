using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class StudentProfessorUserLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Professors_ClassMasterId",
                schema: "highSchool",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorSubjects_Professors_ProfessorId",
                schema: "highSchool",
                table: "ProfessorSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Subjects_SubjectId",
                schema: "highSchool",
                table: "Semesters");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                schema: "highSchool",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                schema: "highSchool",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Professors_ProfessorId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_StudentId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Professors",
                schema: "highSchool");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "highSchool");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfessorId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_SubjectId",
                schema: "highSchool",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                schema: "highSchool",
                table: "Users",
                newName: "ClassId");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                schema: "highSchool",
                table: "Subjects",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_ClassId",
                schema: "highSchool",
                table: "Subjects",
                newName: "IX_Subjects_GroupId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                schema: "highSchool",
                table: "StudentSubjects",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_StudentId",
                schema: "highSchool",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_UserId");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorSubjects_ProfessorId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                newName: "IX_ProfessorSubjects_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                schema: "highSchool",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                schema: "highSchool",
                table: "Semesters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassId",
                schema: "highSchool",
                table: "Users",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_CourseId",
                schema: "highSchool",
                table: "Semesters",
                column: "CourseId");

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
                name: "FK_ProfessorSubjects_Users_UserId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                column: "UserId",
                principalSchema: "highSchool",
                principalTable: "Users",
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
                name: "FK_StudentSubjects_Users_UserId",
                schema: "highSchool",
                table: "StudentSubjects",
                column: "UserId",
                principalSchema: "highSchool",
                principalTable: "Users",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_ClassMasterId",
                schema: "highSchool",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorSubjects_Users_UserId",
                schema: "highSchool",
                table: "ProfessorSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Subjects_CourseId",
                schema: "highSchool",
                table: "Semesters");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Users_UserId",
                schema: "highSchool",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Classes_GroupId",
                schema: "highSchool",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classes_ClassId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClassId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_CourseId",
                schema: "highSchool",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "CourseId",
                schema: "highSchool",
                table: "Semesters");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                schema: "highSchool",
                table: "Users",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                schema: "highSchool",
                table: "Subjects",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_GroupId",
                schema: "highSchool",
                table: "Subjects",
                newName: "IX_Subjects_ClassId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "highSchool",
                table: "StudentSubjects",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_UserId",
                schema: "highSchool",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_StudentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                newName: "ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorSubjects_UserId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                newName: "IX_ProfessorSubjects_ProfessorId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                schema: "highSchool",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Professors",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "highSchool",
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_SubjectId",
                schema: "highSchool",
                table: "Semesters",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                schema: "highSchool",
                table: "Students",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Professors_ClassMasterId",
                schema: "highSchool",
                table: "Classes",
                column: "ClassMasterId",
                principalSchema: "highSchool",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorSubjects_Professors_ProfessorId",
                schema: "highSchool",
                table: "ProfessorSubjects",
                column: "ProfessorId",
                principalSchema: "highSchool",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Subjects_SubjectId",
                schema: "highSchool",
                table: "Semesters",
                column: "SubjectId",
                principalSchema: "highSchool",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                schema: "highSchool",
                table: "StudentSubjects",
                column: "StudentId",
                principalSchema: "highSchool",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                schema: "highSchool",
                table: "Subjects",
                column: "ClassId",
                principalSchema: "highSchool",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Professors_ProfessorId",
                schema: "highSchool",
                table: "Users",
                column: "ProfessorId",
                principalSchema: "highSchool",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_StudentId",
                schema: "highSchool",
                table: "Users",
                column: "StudentId",
                principalSchema: "highSchool",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
