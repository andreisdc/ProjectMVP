using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class UserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupName",
                schema: "highSchool",
                table: "Groups",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "highSchool",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                schema: "highSchool",
                table: "Grades",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                schema: "highSchool",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "highSchool",
                table: "Groups",
                newName: "GroupName");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                schema: "highSchool",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
