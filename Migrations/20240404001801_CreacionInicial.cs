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
                    Edad_biologo = table.Column<int>(type: "int", nullable: true),
                    Telefono_biologo = table.Column<long>(type: "bigint", nullable: true),
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
                    Especie_escarabajo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Familia_escarabajo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genero_escarabajo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patas_escarabajo = table.Column<int>(type: "int", nullable: false),
                    Torax_escarabajo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciclo_vida_escarabajo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre_comun_escarabajo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Antena_escarabajo = table.Column<int>(type: "int", nullable: false),
                    Ojos_escarabajos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mandibula_escarabajo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alas_escarabajo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Elitros_escarabajo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Audios_escarabajo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagenes_escarabajo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Protegida = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escarabajo", x => x.Especie_escarabajo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BiologoEscarabajo",
                columns: table => new
                {
                    BiologosId_biologo = table.Column<int>(type: "int", nullable: false),
                    EscarabajosEspecie_escarabajo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiologoEscarabajo", x => new { x.BiologosId_biologo, x.EscarabajosEspecie_escarabajo });
                    table.ForeignKey(
                        name: "FK_BiologoEscarabajo_Biologo_BiologosId_biologo",
                        column: x => x.BiologosId_biologo,
                        principalTable: "Biologo",
                        principalColumn: "Id_biologo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiologoEscarabajo_Escarabajo_EscarabajosEspecie_escarabajo",
                        column: x => x.EscarabajosEspecie_escarabajo,
                        principalTable: "Escarabajo",
                        principalColumn: "Especie_escarabajo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Biologo",
                columns: new[] { "Id_biologo", "Contrasena_biologo", "Correo_biologo", "Edad_biologo", "Nombre_biologo", "Protegida", "Telefono_biologo", "Usuario_biologo" },
                values: new object[,]
                {
                    { 1, "1234", "Correo1", 19, "Nombre1", true, 9999999999L, "Usuario1" },
                    { 2, "1234", "Correo2", 20, "Nombre2", true, 9999999999L, "Usuario2" },
                    { 3, "1234", "Correo3", 18, "Nombre3", true, 9999999999L, "Usuario3" },
                    { 4, "1234", "Correo4", 23, "Nombre4", true, 9999999999L, "Usuario4" }
                });

            migrationBuilder.InsertData(
                table: "Escarabajo",
                columns: new[] { "Especie_escarabajo", "Alas_escarabajo", "Antena_escarabajo", "Audios_escarabajo", "Ciclo_vida_escarabajo", "Elitros_escarabajo", "Familia_escarabajo", "Genero_escarabajo", "Imagenes_escarabajo", "Mandibula_escarabajo", "Nombre_comun_escarabajo", "Ojos_escarabajos", "Patas_escarabajo", "Protegida", "Torax_escarabajo" },
                values: new object[,]
                {
                    { "especie1", "alas1", 1, "[]", "ciclo_vida1", "elitros1", "familia1", "genero1", "[]", "mandibula1", "nombre_comun1", "ojos1", 1, true, "torax1" },
                    { "especie2", "alas2", 2, "[]", "ciclo_vida2", "elitros2", "familia2", "genero2", "[]", "mandibula2", "nombre_comun2", "ojos2", 2, true, "torax2" },
                    { "especie3", "alas3", 3, "[]", "ciclo_vida3", "elitros3", "familia3", "genero3", "[]", "mandibula3", "nombre_comun3", "ojos3", 3, true, "torax3" },
                    { "especie4", "alas4", 4, "[]", "ciclo_vida4", "elitros4", "familia4", "genero4", "[]", "mandibula4", "nombre_comun4", "ojos4", 4, true, "torax4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiologoEscarabajo_EscarabajosEspecie_escarabajo",
                table: "BiologoEscarabajo",
                column: "EscarabajosEspecie_escarabajo");
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
