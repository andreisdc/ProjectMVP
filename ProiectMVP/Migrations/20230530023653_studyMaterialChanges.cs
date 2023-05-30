using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class studyMaterialChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "highSchool",
                table: "StudyMaterials");

            migrationBuilder.RenameColumn(
                name: "FileType",
                schema: "highSchool",
                table: "StudyMaterials",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                schema: "highSchool",
                table: "StudyMaterials",
                newName: "Extension");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                schema: "highSchool",
                table: "StudyMaterials",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                schema: "highSchool",
                table: "StudyMaterials");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "highSchool",
                table: "StudyMaterials",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "Extension",
                schema: "highSchool",
                table: "StudyMaterials",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "highSchool",
                table: "StudyMaterials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
