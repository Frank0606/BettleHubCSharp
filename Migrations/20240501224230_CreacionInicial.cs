using System;
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Telefono = table.Column<long>(type: "bigint", nullable: true),
                    Protegida = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                    Especie = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Familia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patas = table.Column<int>(type: "int", nullable: false),
                    Torax = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciclo_vida = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre_comun = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Antena = table.Column<int>(type: "int", nullable: false),
                    Ojos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mandibula = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Elitros = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado_investigacion = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Audios = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagenes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Coordenadas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Protegida = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escarabajo", x => x.Especie);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BiologoEscarabajo",
                columns: table => new
                {
                    BiologosId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EscarabajosEspecie = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiologoEscarabajo", x => new { x.BiologosId, x.EscarabajosEspecie });
                    table.ForeignKey(
                        name: "FK_BiologoEscarabajo_AspNetUsers_BiologosId",
                        column: x => x.BiologosId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiologoEscarabajo_Escarabajo_EscarabajosEspecie",
                        column: x => x.EscarabajosEspecie,
                        principalTable: "Escarabajo",
                        principalColumn: "Especie",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d6ba7ab-e237-40be-b215-d61598f7250a", null, "Biologo", "BIOLOGO" },
                    { "a0dec9fd-307b-4f39-b90b-ca9f9d9c0164", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Edad", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Protegida", "SecurityStamp", "Telefono", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a70a5075-1830-49cb-a7a0-a557173cdd7f", 0, "4d21d77a-9483-4c4f-8ee8-87043d618022", 20, "Correo2@correo.com", false, false, null, "CORREO2@CORREO.COM", "Nombre2", "AQAAAAIAAYagAAAAEHEpUSbOyg9Kix0lzj6JDDOo7D17vQn5fnLv0tUZWQLexdeqIvU6lrT1pet/7SgW8Q==", null, false, false, "c90cd2d4-ca8b-41ed-8e56-2d2f5f548fe8", 9999999999L, false, "Nombre2" },
                    { "e1565b84-2b86-4af0-986b-922acf516265", 0, "f7f68615-d316-45af-9fe6-682bd1d42331", 19, "Correo1@correo.com", false, false, null, "CORREO1@CORREO.COM", "NOMBRE1", "AQAAAAIAAYagAAAAEIvGlUoQMLOCWJ91df8HBTLKMzLHmhf/WGMI6YOnttaUFL7WHa59UiO3otk8YIRuqQ==", null, false, true, "41de10ae-1ce4-4ee1-90cd-a63d952b413a", 9999999999L, false, "Nombre1" }
                });

            migrationBuilder.InsertData(
                table: "DatoCurioso",
                columns: new[] { "Id_Dato", "Descripcion_Dato" },
                values: new object[,]
                {
                    { "20c3dd83-94ce-4177-bb36-ecb42c91e01c", "Los escarabajos de esta familia son xilófagos, lo que significa que se alimentan principalmente de madera." },
                    { "2fab21b2-aada-49a4-9cf1-0c66056643dc", "Tienen cuerpos alargados y robustos, cabezas grandes y cuernos que utilizan en sus rituales de apareamiento y en la lucha por territorio o parejas." },
                    { "547d346f-7118-4999-a0f7-e3ad221476db", "El comportamiento social de los Pasalidos es vivir en grupos familiares donde cooperan en el cuidado de las larvas y el mantenimiento de su hogar." },
                    { "7549aae1-8241-43e4-9fdf-b42a930d218b", "Los Pasalidos son conocidos por su capacidad para producir sonidos, un comportamiento conocido como estridulación." },
                    { "7e446d1c-26cd-4683-9605-6162bfcf8aa7", "Los Pasalidos ayudan en el ciclo de nutrientes en los ecosistemas forestales." },
                    { "8d6d3b58-2687-4864-bc28-6f68d233fa50", "Los Pasalidos se encuentran principalmente en las regiones tropicales de América, Asia y África. En América, su distribución va desde México hasta Argentina." },
                    { "a860e306-00a4-499d-a15f-e88afd619412", "Aunque principalmente habitan en bosques húmedos y tropicales, tambien habitan bosques templados y áreas montañosas." },
                    { "d4ed2525-9313-43d6-b401-118268137ab4", "Estos escarabajos pueden tener ciclos de vida relativamente largos en comparación con otros insectos." },
                    { "d801ad56-a015-4a2d-99e8-cf5e75075c49", "Estos escarabajos son uno de los pocos grupos de coleópteros que exhiben cuidado parental extenso." },
                    { "fdfd2335-c32b-4050-a81b-4734b71cd647", "Los Pasalidos son objeto de estudio en áreas como ecología del comportamiento, biología de la conservación y entomología forestal." }
                });

            migrationBuilder.InsertData(
                table: "Escarabajo",
                columns: new[] { "Especie", "Alas", "Antena", "Audios", "Ciclo_vida", "Coordenadas", "Descripcion", "Elitros", "Estado_investigacion", "Familia", "Genero", "Imagenes", "Mandibula", "Nombre_comun", "Ojos", "Patas", "Protegida", "Torax" },
                values: new object[,]
                {
                    { "especie1", "alas1", 1, "[\"./css/resources/audios/junctistriatus/P_junctistriatus_6_2.wav\"]", "ciclo_vida1", "[\"19.5450165,-96.8953113,14\"]", "Los escarabajos pasálidos, también conocidos como escarabajos de tierra, son insectos coleópteros que se caracterizan por su cuerpo ovalado y duro, así como por sus antenas cortas y robustas.", "elitros1", false, "familia1", "genero1", "[\"./css/resources/images/pasalido1.jpg\"]", "mandibula1", "nombre_comun1", "ojos1", 1, true, "torax1" },
                    { "especie2", "alas2", 2, "[\"./css/resources/audios/junctistriatus/P_junctistriatus_6_2.wav\"]", "ciclo_vida2", "[\"17.0794635,-96.7063748,17\"]", "Los escarabajos pasálidos: pequeños guardianes del suelo. Estos insectos, con su armadura brillante y patas fuertes, son esenciales para mantener el equilibrio del ecosistema del suelo al descomponer materia orgánica y aerar el sustrato.", "elitros2", false, "familia2", "genero2", "[\"./css/resources/images/pasalido2.jpg\"]", "mandibula2", "nombre_comun2", "ojos2", 2, true, "torax2" },
                    { "especie3", "alas3", 3, "[\"./css/resources/audios/subopacus/P_subopacus_5_3.wav\"]", "ciclo_vida3", "[\"19.4973646,-96.8573872,16\"]", "Los escarabajos pasálidos son criaturas fascinantes que se encuentran en una variedad de hábitats terrestres. Su papel como descomponedores es crucial para el ciclo de nutrientes, contribuyendo al proceso de compostaje y enriqueciendo la salud del suelo.", "elitros3", false, "familia3", "genero3", "[\"./css/resources/images/pasalido3.jpg\"]", "mandibula3", "nombre_comun3", "ojos3", 3, true, "torax3" },
                    { "especie4", "alas4", 4, "[\"./css/resources/audios/zuninoi/P_zuninoi_3_6.wav\"]", "ciclo_vida4", "[\"19.5266079,-96.9242194,17\"]", "Descubre el mundo subterráneo de los escarabajos pasálidos. Estos pequeños insectos, con su caparazón brillante y su actividad incansable, desempeñan un papel vital en la transformación de materia orgánica en nutrientes disponibles para otras formas de vida en el suelo.", "elitros4", false, "familia4", "genero4", "[\"./css/resources/images/pasalido4.jpg\"]", "mandibula4", "nombre_comun4", "ojos4", 4, true, "torax4" }
                });

            migrationBuilder.InsertData(
                table: "Pregunta",
                columns: new[] { "Id_pregunta", "Pregunta_pregunta", "Respuesta_pregunta" },
                values: new object[,]
                {
                    { "08066457-7619-429b-aeb6-454da3e2c24c", "¿Quién es el Dr Edwin Eriza?", "Un doctor" },
                    { "129dd439-61a8-47ee-b252-21b477b46eaf", "¿Qué son los Pasalidos?", "Los pasálidos son una familia de escarabajos conocidos por su comportamiento social y ecológico, especializados en la descomposición de madera en bosques húmedos y tropicales." },
                    { "699902a6-8688-4372-ade8-df8d08b243ae", "¿Que hace Bettle-Finder?", "Es un paginas web sobre los escarabajos de la familia Passalidae, con la funcion unica de poder clasificar sus sonidos por especie." },
                    { "8bba2efb-245c-423b-9b8c-959b1021c9d6", "¿Quiéres conocer mas sobre otras familias de escarabajos?", "Te recomendamos las siguiente paginas para saber mas sobre otras familias. " },
                    { "ed5f88bf-4d14-4667-a449-d112082e23b0", "¿Quiénes fueron los desarrolladores?", "Somos un grupo de estudiantes de la carrera Lic. Tecnologías Computacionales de la Universidad Veracruzana. Nuestro proyecto Beetle-Finder es un ejemplo sobre nuestro trabajo como desarrolladores, enfocandonos en una comunidad cientifica." }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5d6ba7ab-e237-40be-b215-d61598f7250a", "a70a5075-1830-49cb-a7a0-a557173cdd7f" },
                    { "a0dec9fd-307b-4f39-b90b-ca9f9d9c0164", "e1565b84-2b86-4af0-986b-922acf516265" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BiologoEscarabajo_EscarabajosEspecie",
                table: "BiologoEscarabajo",
                column: "EscarabajosEspecie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BiologoEscarabajo");

            migrationBuilder.DropTable(
                name: "DatoCurioso");

            migrationBuilder.DropTable(
                name: "Pregunta");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Escarabajo");
        }
    }
}
