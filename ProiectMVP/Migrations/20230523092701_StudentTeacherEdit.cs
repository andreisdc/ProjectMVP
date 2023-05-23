using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_ClassMasterId",
                schema: "highSchool",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Users_UserId",
                schema: "highSchool",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Users_UserId",
                schema: "highSchool",
                table: "TeacherCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_ClassId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_Teacher_UserId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClassId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Teacher_UserId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClassId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Teacher_FirstName",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Teacher_LastName",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Teacher_UserId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "highSchool",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "highSchool",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "highSchool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "highSchool",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                schema: "highSchool",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                schema: "highSchool",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                schema: "highSchool",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_ClassMasterId",
                schema: "highSchool",
                table: "Groups",
                column: "ClassMasterId",
                principalSchema: "highSchool",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_UserId",
                schema: "highSchool",
                table: "StudentCourses",
                column: "UserId",
                principalSchema: "highSchool",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Teachers_UserId",
                schema: "highSchool",
                table: "TeacherCourses",
                column: "UserId",
                principalSchema: "highSchool",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_ClassMasterId",
                schema: "highSchool",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_UserId",
                schema: "highSchool",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Teachers_UserId",
                schema: "highSchool",
                table: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "highSchool");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "highSchool");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                schema: "highSchool",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Teacher_FirstName",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Teacher_LastName",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Teacher_UserId",
                schema: "highSchool",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "highSchool",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassId",
                schema: "highSchool",
                table: "Users",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Teacher_UserId",
                schema: "highSchool",
                table: "Users",
                column: "Teacher_UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                schema: "highSchool",
                table: "Users",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "FK_StudentCourses_Users_UserId",
                schema: "highSchool",
                table: "StudentCourses",
                column: "UserId",
                principalSchema: "highSchool",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Users_UserId",
                schema: "highSchool",
                table: "TeacherCourses",
                column: "UserId",
                principalSchema: "highSchool",
                principalTable: "Users",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_Teacher_UserId",
                schema: "highSchool",
                table: "Users",
                column: "Teacher_UserId",
                principalSchema: "highSchool",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                schema: "highSchool",
                table: "Users",
                column: "UserId",
                principalSchema: "highSchool",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
