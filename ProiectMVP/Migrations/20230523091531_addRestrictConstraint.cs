using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class addRestrictConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_Teacher_UserId",
                schema: "highSchool",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
