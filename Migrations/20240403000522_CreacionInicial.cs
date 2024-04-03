using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BettleHubCsharp.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Biologo",
                columns: table => new
                {
                    Id_biologo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Correo_biologo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre_biologo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edad_biologo = table.Column<int>(type: "int", nullable: false),
                    Telefono_biologo = table.Column<int>(type: "int", nullable: false),
                    Contrasena_biologo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usuario_biologo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Protegida = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biologo", x => x.Id_biologo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Escarabajo",
                columns: table => new
                {
                    EscarabajoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sinopsis = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escarabajo", x => x.EscarabajoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BiologoEscarabajo",
                columns: table => new
                {
                    BiologosId_biologo = table.Column<int>(type: "int", nullable: false),
                    EscarabajosEscarabajoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiologoEscarabajo", x => new { x.BiologosId_biologo, x.EscarabajosEscarabajoId });
                    table.ForeignKey(
                        name: "FK_BiologoEscarabajo_Biologo_BiologosId_biologo",
                        column: x => x.BiologosId_biologo,
                        principalTable: "Biologo",
                        principalColumn: "Id_biologo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiologoEscarabajo_Escarabajo_EscarabajosEscarabajoId",
                        column: x => x.EscarabajosEscarabajoId,
                        principalTable: "Escarabajo",
                        principalColumn: "EscarabajoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Biologo",
                columns: new[] { "Id_biologo", "Contrasena_biologo", "Correo_biologo", "Edad_biologo", "Nombre_biologo", "Protegida", "Telefono_biologo", "Usuario_biologo" },
                values: new object[,]
                {
                    { 1, "1234", "Correo1", 19, "Nombre1", true, 1, "Usuario1" },
                    { 2, "1234", "Correo2", 20, "Nombre2", true, 2, "Usuario2" },
                    { 3, "1234", "Correo3", 18, "Nombre3", true, 3, "Usuario3" },
                    { 4, "1234", "Correo4", 23, "Nombre4", true, 4, "Usuario4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiologoEscarabajo_EscarabajosEscarabajoId",
                table: "BiologoEscarabajo",
                column: "EscarabajosEscarabajoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiologoEscarabajo");

            migrationBuilder.DropTable(
                name: "Biologo");

            migrationBuilder.DropTable(
                name: "Escarabajo");
        }
    }
}
