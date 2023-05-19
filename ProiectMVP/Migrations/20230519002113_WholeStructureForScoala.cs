using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMVP.Migrations
{
    /// <inheritdoc />
    public partial class WholeStructureForScoala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                schema: "liceu",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "liceu",
                newName: "Elevi",
                newSchema: "liceu");

            migrationBuilder.AddColumn<int>(
                name: "ClasaId",
                schema: "liceu",
                table: "Elevi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elevi",
                schema: "liceu",
                table: "Elevi",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clase",
                schema: "liceu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    An = table.Column<int>(type: "int", nullable: false),
                    Initiala = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materie",
                schema: "liceu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                schema: "liceu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diriginte = table.Column<bool>(type: "bit", nullable: false),
                    ClasaDiriginteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_Clase_ClasaDiriginteId",
                        column: x => x.ClasaDiriginteId,
                        principalSchema: "liceu",
                        principalTable: "Clase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElevMaterie",
                schema: "liceu",
                columns: table => new
                {
                    ElevId = table.Column<int>(type: "int", nullable: false),
                    MaterieId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Absent = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Semestru = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevMaterie", x => new { x.ElevId, x.MaterieId });
                    table.ForeignKey(
                        name: "FK_ElevMaterie_Elevi_ElevId",
                        column: x => x.ElevId,
                        principalSchema: "liceu",
                        principalTable: "Elevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElevMaterie_Materie_MaterieId",
                        column: x => x.MaterieId,
                        principalSchema: "liceu",
                        principalTable: "Materie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterieProfesor",
                schema: "liceu",
                columns: table => new
                {
                    MateriiId = table.Column<int>(type: "int", nullable: false),
                    ProfesoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterieProfesor", x => new { x.MateriiId, x.ProfesoriId });
                    table.ForeignKey(
                        name: "FK_MaterieProfesor_Materie_MateriiId",
                        column: x => x.MateriiId,
                        principalSchema: "liceu",
                        principalTable: "Materie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterieProfesor_Profesor_ProfesoriId",
                        column: x => x.ProfesoriId,
                        principalSchema: "liceu",
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elevi_ClasaId",
                schema: "liceu",
                table: "Elevi",
                column: "ClasaId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevMaterie_MaterieId",
                schema: "liceu",
                table: "ElevMaterie",
                column: "MaterieId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterieProfesor_ProfesoriId",
                schema: "liceu",
                table: "MaterieProfesor",
                column: "ProfesoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_ClasaDiriginteId",
                schema: "liceu",
                table: "Profesor",
                column: "ClasaDiriginteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Elevi_Clase_ClasaId",
                schema: "liceu",
                table: "Elevi",
                column: "ClasaId",
                principalSchema: "liceu",
                principalTable: "Clase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elevi_Clase_ClasaId",
                schema: "liceu",
                table: "Elevi");

            migrationBuilder.DropTable(
                name: "ElevMaterie",
                schema: "liceu");

            migrationBuilder.DropTable(
                name: "MaterieProfesor",
                schema: "liceu");

            migrationBuilder.DropTable(
                name: "Materie",
                schema: "liceu");

            migrationBuilder.DropTable(
                name: "Profesor",
                schema: "liceu");

            migrationBuilder.DropTable(
                name: "Clase",
                schema: "liceu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elevi",
                schema: "liceu",
                table: "Elevi");

            migrationBuilder.DropIndex(
                name: "IX_Elevi_ClasaId",
                schema: "liceu",
                table: "Elevi");

            migrationBuilder.DropColumn(
                name: "ClasaId",
                schema: "liceu",
                table: "Elevi");

            migrationBuilder.RenameTable(
                name: "Elevi",
                schema: "liceu",
                newName: "Students",
                newSchema: "liceu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                schema: "liceu",
                table: "Students",
                column: "Id");
        }
    }
}
