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
                    Id_biologo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                name: "DatoCurioso",
                columns: table => new
                {
                    Id_Dato = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion_Dato = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatoCurioso", x => x.Id_Dato);
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
                    Ojos_escarabajo = table.Column<string>(type: "longtext", nullable: false)
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
                name: "Pregunta",
                columns: table => new
                {
                    Id_pregunta = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pregunta_pregunta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Respuesta_pregunta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta", x => x.Id_pregunta);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BiologoEscarabajo",
                columns: table => new
                {
                    BiologosId_biologo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    { "0c443a98-143d-414e-89d3-41987ee947bf", "AQAAAAIAAYagAAAAEKdZyBTxdZQZ5TErXDyVVNnqnVFraSfdhkk704DYbuT9tA6N0qaYWtOO0A1g/50WuA==", "Correo4", 23, "Nombre4", true, 9999999999L, "Usuario4" },
                    { "3658f92f-ec58-4bfc-882d-ea8c16fdcc47", "AQAAAAIAAYagAAAAEG9SYhK5OAHT86y21JYcr/ydbUXLmNP8MFiqHJJ0HwFU/fx7+m7Gqf8qH5vmYFY3DA==", "Correo3", 18, "Nombre3", true, 9999999999L, "Usuario3" },
                    { "a4e53e4a-9e37-4dec-8d7f-b260b4750564", "AQAAAAIAAYagAAAAED3fJ1cEbDnVZ9DhMLXzw2DFTH7I7vvtTP7AkMzfP0uhglKerCwm+Sz480fZxYmO/A==", "Correo1", 19, "Nombre1", true, 9999999999L, "Usuario1" },
                    { "b48b3d52-8d99-4639-835a-f5ec62cb3193", "AQAAAAIAAYagAAAAEPN1cHMhzNuuPMzSXXXUuFIwEIp5jw3kGWMxsPCusev6ohH+dMxHNhRuiLR/lfO2PA==", "Correo2", 20, "Nombre2", true, 9999999999L, "Usuario2" }
                });

            migrationBuilder.InsertData(
                table: "DatoCurioso",
                columns: new[] { "Id_Dato", "Descripcion_Dato" },
                values: new object[,]
                {
                    { "4b981b0c-e03c-480c-bc6c-e92dbf0478aa", "Los Pasalidos se encuentran principalmente en las regiones tropicales de América, Asia y África. En América, su distribución va desde México hasta Argentina." },
                    { "4e5b7d6d-e065-4a13-bf97-26dd146b53fd", "Los escarabajos de esta familia son xilófagos, lo que significa que se alimentan principalmente de madera." },
                    { "a35c6048-65f3-4989-89be-a6e79a1741f9", "Los Pasalidos son conocidos por su capacidad para producir sonidos, un comportamiento conocido como estridulación." },
                    { "a935a75f-e60a-4793-85de-18866035308a", "Los Pasalidos ayudan en el ciclo de nutrientes en los ecosistemas forestales." },
                    { "b22d8fe1-666c-4864-9ae5-238e1b551315", "Estos escarabajos son uno de los pocos grupos de coleópteros que exhiben cuidado parental extenso." },
                    { "b6135ba9-0a41-48b3-8a1d-1c0beb166f35", "Estos escarabajos pueden tener ciclos de vida relativamente largos en comparación con otros insectos." },
                    { "c6b1a1b0-a817-4bac-82c1-20d2ab1aad85", "Los Pasalidos son objeto de estudio en áreas como ecología del comportamiento, biología de la conservación y entomología forestal." },
                    { "d1fa8356-72b2-4050-acc5-a2ec0ccdda3c", "Aunque principalmente habitan en bosques húmedos y tropicales, tambien habitan bosques templados y áreas montañosas." },
                    { "e421942e-bb1a-4495-849d-7a3ebfbb4a6b", "El comportamiento social de los Pasalidos es vivir en grupos familiares donde cooperan en el cuidado de las larvas y el mantenimiento de su hogar." },
                    { "e7ccc3e9-0f8c-4516-a9a9-928aed484d18", "Tienen cuerpos alargados y robustos, cabezas grandes y cuernos que utilizan en sus rituales de apareamiento y en la lucha por territorio o parejas." }
                });

            migrationBuilder.InsertData(
                table: "Escarabajo",
                columns: new[] { "Especie_escarabajo", "Alas_escarabajo", "Antena_escarabajo", "Audios_escarabajo", "Ciclo_vida_escarabajo", "Elitros_escarabajo", "Familia_escarabajo", "Genero_escarabajo", "Imagenes_escarabajo", "Mandibula_escarabajo", "Nombre_comun_escarabajo", "Ojos_escarabajo", "Patas_escarabajo", "Protegida", "Torax_escarabajo" },
                values: new object[,]
                {
                    { "especie1", "alas1", 1, "[]", "ciclo_vida1", "elitros1", "familia1", "genero1", "[]", "mandibula1", "nombre_comun1", "ojos1", 1, true, "torax1" },
                    { "especie2", "alas2", 2, "[]", "ciclo_vida2", "elitros2", "familia2", "genero2", "[]", "mandibula2", "nombre_comun2", "ojos2", 2, true, "torax2" },
                    { "especie3", "alas3", 3, "[]", "ciclo_vida3", "elitros3", "familia3", "genero3", "[]", "mandibula3", "nombre_comun3", "ojos3", 3, true, "torax3" },
                    { "especie4", "alas4", 4, "[]", "ciclo_vida4", "elitros4", "familia4", "genero4", "[]", "mandibula4", "nombre_comun4", "ojos4", 4, true, "torax4" }
                });

            migrationBuilder.InsertData(
                table: "Pregunta",
                columns: new[] { "Id_pregunta", "Pregunta_pregunta", "Respuesta_pregunta" },
                values: new object[,]
                {
                    { "45e2fb4d-0136-47ca-bd67-fb1154567874", "¿Quiénes fueron los desarrolladores?", "Somos un grupo de estudiantes de la carrera Lic. Tecnologías Computacionales de la Universidad Veracruzana. Nuestro proyecto Beetle-Finder es un ejemplo sobre nuestro trabajo como desarrolladores, enfocandonos en una comunidad cientifica." },
                    { "a87dfb29-16a2-41cc-99ca-01355675fe4a", "¿Que hace Bettle-Finder?", "Es un paginas web sobre los escarabajos de la familia Passalidae, con la funcion unica de poder clasificar sus sonidos por especie." },
                    { "ad75e339-d9ce-4344-a845-6b98e8da56f9", "¿Quiéres conocer mas sobre otras familias de escarabajos?", "Te recomendamos las siguiente paginas para saber mas sobre otras familias. " },
                    { "c628adb5-756e-45d3-a74d-30afff6ec504", "¿Quién es el Dr Edwin Eriza?", "Un doctor" },
                    { "d298a8a0-6247-4a2a-9145-6bb93ac8ef31", "¿Qué son los Pasalidos?", "Los pasálidos son una familia de escarabajos conocidos por su comportamiento social y ecológico, especializados en la descomposición de madera en bosques húmedos y tropicales." }
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
                name: "DatoCurioso");

            migrationBuilder.DropTable(
                name: "Pregunta");

            migrationBuilder.DropTable(
                name: "Biologo");

            migrationBuilder.DropTable(
                name: "Escarabajo");
        }
    }
}
