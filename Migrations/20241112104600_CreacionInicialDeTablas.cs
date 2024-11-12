using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjemploABMCompleto.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicialDeTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdadObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atracciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdadMinima = table.Column<int>(type: "int", nullable: false),
                    EdadMaxima = table.Column<int>(type: "int", nullable: false),
                    AlturaMinima = table.Column<int>(type: "int", nullable: false),
                    AlturaMaxima = table.Column<int>(type: "int", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdParque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atracciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atracciones_Parques_IdParque",
                        column: x => x.IdParque,
                        principalTable: "Parques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atracciones_IdParque",
                table: "Atracciones",
                column: "IdParque");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atracciones");

            migrationBuilder.DropTable(
                name: "Parques");
        }
    }
}
