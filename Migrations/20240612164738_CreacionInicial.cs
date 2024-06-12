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
                name: "Ayuda",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subtitulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contenido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayuda", x => x.Id);
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
                    { "28cdd586-d840-452c-9f53-00359913e26d", null, "Biologo", "BIOLOGO" },
                    { "d8a195df-c68c-48cc-8ece-3a3831890d3a", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Edad", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Protegida", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5a5c324e-4b62-43e6-899a-95b8ba4b142e", 0, "913217f3-1567-4056-a806-148958b3523a", 20, "Correo2@correo.com", false, false, null, "CORREO2@CORREO.COM", "Nombre2", "AQAAAAIAAYagAAAAEAoYyXY5YstKbsRjGCA6Shv0nZh9s1h4Xvc9yIxvJaAqPuNbChp3t97H9w+Qvgrouw==", "9999999999", false, false, "2798844b-df9b-43b0-85a1-65cf586c95d6", false, "Nombre2" },
                    { "f4b179b1-313a-465f-885d-9215c72a081e", 0, "af5a9cb7-3270-4f9f-9d14-b99ed42bc4f1", 19, "Correo1@correo.com", false, false, null, "CORREO1@CORREO.COM", "NOMBRE1", "AQAAAAIAAYagAAAAED+JUc0w25/Zr+70TiRKLjSc92IsvUgDUI8OUb0JHMCS4LQ3v4BhsmU6s0CKZuYcBg==", "9999999999", false, true, "31ab0502-82ae-4520-bb98-8a33f3341148", false, "Nombre1" }
                });

            migrationBuilder.InsertData(
                table: "Ayuda",
                columns: new[] { "Id", "Contenido", "Subtitulo", "Titulo" },
                values: new object[,]
                {
                    { "2b6c7929-e93d-42d3-8f33-7df57d2d02a0", "Inicio de Sesión:\n                    Para acceder a las funcionalidades de la plataforma, primero debes iniciar sesión.\n                    En la página de inicio de sesión, ingresa tu correo electrónico y contraseña. Si no tienes una cuenta, contacta al administrador para obtener acceso.\n\n                    Administración de Biólogos:\n                    En esta sección podrás administrar los biólogos registrados en la plataforma.\n                    Mostrar:\n                    Para visualizar la lista de biólogos registrados, haz clic en el enlace 'Mostrar' ubicado en la barra de navegación. Se abrirá una tabla que muestra los nombres, correos electrónicos, edades y teléfonos de los biólogos.\n                    Agregar:\n                    Para agregar un nuevo biólogo, haz clic en el enlace 'Agregar' ubicado en la barra de navegación. Se abrirá un modal donde podrás ingresar los datos del nuevo biólogo, como nombre, correo electrónico, edad, teléfono y contraseña.\n\n                    Administración de Escarabajos:\n                    En esta sección podrás administrar los escarabajos registrados en la plataforma.\n                    Mostrar:\n                    Para visualizar la lista de escarabajos registrados, haz clic en el enlace 'Mostrar' ubicado en la barra de navegación. Se abrirá una tabla que muestra los nombres, especies, hábitats y otros datos relevantes de los escarabajos.\n                    Agregar:\n                    Para agregar un nuevo escarabajo, haz clic en el enlace 'Agregar' ubicado en la barra de navegación. Se abrirá un modal donde podrás ingresar los datos del nuevo escarabajo, como nombre, especie, hábitat y características adicionales.\n\n                    Galería de Escarabajos:\n                    En esta sección podrás visualizar imágenes de los escarabajos registrados en la plataforma.\n                    Para acceder a la galería, selecciona la opción 'Galería' en la barra de navegación. Aquí podrás ver imágenes y detalles de los escarabajos, facilitando su identificación y estudio.\n\n                    Clasificador:\n                    La página de Clasificador permite a los biólogos clasificar los escarabajos a partir de grabaciones de audio. Aquí se describen los pasos para utilizar la página:\n\n                    1. Cargar Audio:\n                    Para cargar un archivo de audio, selecciona el botón 'Subir audio'. Se abrirá un diálogo donde podrás elegir el archivo de audio desde tu dispositivo. Asegúrate de que el archivo esté en un formato compatible y que el nombre del archivo se muestre después de seleccionarlo.\n\n                    2. Ingresar Datos:\n                    - Biólogo: Este campo muestra el nombre del biólogo que está realizando la clasificación. Está deshabilitado para edición directa.\n                    - Coordenadas: Ingrese las coordenadas del lugar donde se registró el audio del escarabajo.\n\n                    3. Previsualización del Audio:\n                    Después de cargar el audio, se mostrará un reproductor de audio donde podrás escuchar el archivo cargado.\n\n                    4. Clasificar:\n                    Presiona el botón 'Clasificar' para procesar el audio. La aplicación analizará el audio y mostrará los resultados de la clasificación.\n\n                    Resultado:\n                    Una vez que se complete la clasificación, se mostrará una imagen del escarabajo clasificado, el nombre científico y el porcentaje de certeza de la clasificación. Si la sección de resultados está oculta, se mostrará al completarse la clasificación.", "Una pequeña guía paso a paso sobre cómo utilizar las principales características de la aplicación.", "Guía de uso" },
                    { "57525306-4de3-4b6f-84d5-756be032c7ca", "La página Beetle-finder está diseñada para permitir a los biólogos clasificar y registrar escarabajos de la familia Passalidae de una manera eficiente. Utiliza tecnologías modernas como C# para ofrecer una experiencia fluida y segura.", "Información detallada sobre cómo funciona la página y la tecnología detrás de ella.", "Documentación sobre la página" },
                    { "a2af93ae-f4d7-4b41-a5be-b8048d72bb05", "1. ¿Qué es Beetle-finder? Beetle-finder es una aplicación diseñada para ayudar a los biólogos en la clasificación y registro de escarabajos, especialmente de la familia Passalidae.\n                    2. ¿Por qué solo hablamos de la familia Passalidae? Nos enfocamos en la familia Passalidae porque es una de las familias de escarabajos más diversas y relevantes para la investigación biológica.\n                    3. ¿Cómo hago la clasificación de mi escarabajo para identificarlo? Puedes utilizar las funciones de búsqueda y clasificación de Beetle-finder para identificar y clasificar tu escarabajo según características específicas.", "Respuestas a las preguntas más frecuentes sobre el uso de la plataforma.", "Preguntas generales" },
                    { "ebb40fde-91d5-4af8-aa8a-4128f47663da", "Beetle-finder es una aplicación destinada a ayudar a los biólogos en la clasificación y registro de escarabajos, centrándose especialmente en la familia Passalidae. Su objetivo principal es proporcionar una herramienta fácil de usar y eficiente para este propósito.", "Descripción general de la aplicación y sus objetivos.", "Sobre qué trata la aplicación" }
                });

            migrationBuilder.InsertData(
                table: "DatoCurioso",
                columns: new[] { "Id_Dato", "Descripcion_Dato" },
                values: new object[,]
                {
                    { "7dba6a8d-b142-4824-aab3-f39fa4e9f904", "Los escarabajos de esta familia son xilófagos, lo que significa que se alimentan principalmente de madera." },
                    { "87199e73-acac-47b9-a676-f1c0ca9ca58e", "Aunque principalmente habitan en bosques húmedos y tropicales, tambien habitan bosques templados y áreas montañosas." },
                    { "8fe59b95-2859-49ee-9878-907c913dc6e5", "Estos escarabajos son uno de los pocos grupos de coleópteros que exhiben cuidado parental extenso." },
                    { "938a1433-e55c-4d2f-969f-66b886bbec4d", "Los Pasalidos se encuentran principalmente en las regiones tropicales de América, Asia y África. En América, su distribución va desde México hasta Argentina." },
                    { "a8e0b905-9ee6-432e-be0a-5834230e9e25", "Los Pasalidos son objeto de estudio en áreas como ecología del comportamiento, biología de la conservación y entomología forestal." },
                    { "c0e3de1a-700d-449b-84f2-103a4d1f2ca1", "Tienen cuerpos alargados y robustos, cabezas grandes y cuernos que utilizan en sus rituales de apareamiento y en la lucha por territorio o parejas." },
                    { "c6d2c678-e869-428a-b156-991058f8ce3c", "El comportamiento social de los Pasalidos es vivir en grupos familiares donde cooperan en el cuidado de las larvas y el mantenimiento de su hogar." },
                    { "ca07d6fe-2933-45e1-8e78-c9dc865dc1d0", "Estos escarabajos pueden tener ciclos de vida relativamente largos en comparación con otros insectos." },
                    { "df4d1eb4-e85e-4437-8b46-269467ff36d7", "Los Pasalidos son conocidos por su capacidad para producir sonidos, un comportamiento conocido como estridulación." },
                    { "f165d867-0d8b-4e35-a887-395a0e45d552", "Los Pasalidos ayudan en el ciclo de nutrientes en los ecosistemas forestales." }
                });

            migrationBuilder.InsertData(
                table: "Escarabajo",
                columns: new[] { "Especie", "Alas", "Antena", "Audios", "Ciclo_vida", "Coordenadas", "Descripcion", "Elitros", "Estado_investigacion", "Familia", "Genero", "Imagenes", "Mandibula", "Nombre_comun", "Ojos", "Patas", "Protegida", "Torax" },
                values: new object[,]
                {
                    { "especie1", "alas1", 1, "[\"./css/resources/audios/junctistriatus/P_junctistriatus_6_2.wav\"]", "ciclo_vida1", "[\"19.5450165,-96.8953113,14\"]", "Los escarabajos pasálidos, también conocidos como escarabajos de tierra, son insectos coleópteros que se caracterizan por su cuerpo ovalado y duro, así como por sus antenas cortas y robustas.", "elitros1", false, "familia1", "genero1", "[\"./css/resources/images/pasalido1.webp\"]", "mandibula1", "nombre_comun1", "ojos1", 1, true, "torax1" },
                    { "especie2", "alas2", 2, "[\"./css/resources/audios/junctistriatus/P_junctistriatus_6_2.wav\"]", "ciclo_vida2", "[\"17.0794635,-96.7063748,17\"]", "Los escarabajos pasálidos: pequeños guardianes del suelo. Estos insectos, con su armadura brillante y patas fuertes, son esenciales para mantener el equilibrio del ecosistema del suelo al descomponer materia orgánica y aerar el sustrato.", "elitros2", false, "familia2", "genero2", "[\"./css/resources/images/pasalido2.webp\"]", "mandibula2", "nombre_comun2", "ojos2", 2, true, "torax2" },
                    { "especie3", "alas3", 3, "[\"./css/resources/audios/subopacus/P_subopacus_5_3.wav\"]", "ciclo_vida3", "[\"19.4973646,-96.8573872,16\"]", "Los escarabajos pasálidos son criaturas fascinantes que se encuentran en una variedad de hábitats terrestres. Su papel como descomponedores es crucial para el ciclo de nutrientes, contribuyendo al proceso de compostaje y enriqueciendo la salud del suelo.", "elitros3", false, "familia3", "genero3", "[\"./css/resources/images/pasalido3.webp\"]", "mandibula3", "nombre_comun3", "ojos3", 3, true, "torax3" },
                    { "especie4", "alas4", 4, "[\"./css/resources/audios/zuninoi/P_zuninoi_3_6.wav\"]", "ciclo_vida4", "[\"19.5266079,-96.9242194,17\"]", "Descubre el mundo subterráneo de los escarabajos pasálidos. Estos pequeños insectos, con su caparazón brillante y su actividad incansable, desempeñan un papel vital en la transformación de materia orgánica en nutrientes disponibles para otras formas de vida en el suelo.", "elitros4", false, "familia4", "genero4", "[\"./css/resources/images/pasalido4.webp\"]", "mandibula4", "nombre_comun4", "ojos4", 4, true, "torax4" }
                });

            migrationBuilder.InsertData(
                table: "Pregunta",
                columns: new[] { "Id_pregunta", "Pregunta_pregunta", "Respuesta_pregunta" },
                values: new object[,]
                {
                    { "1774d1b7-403b-412d-8816-4ee530cbd9a5", "¿Quiénes fueron los desarrolladores?", "Somos un grupo de estudiantes de la carrera Lic. Tecnologías Computacionales de la Universidad Veracruzana. Nuestro proyecto Beetle-Finder es un ejemplo sobre nuestro trabajo como desarrolladores, enfocandonos en una comunidad cientifica." },
                    { "4d7eb39c-8140-483f-9b44-c199a667117f", "¿Que hace Bettle-Finder?", "Es un paginas web sobre los escarabajos de la familia Passalidae, con la funcion unica de poder clasificar sus sonidos por especie." },
                    { "d6e75437-ebc7-46a5-847c-5040ad38ac20", "¿Quién es el Dr Edwin Eriza?", "Un doctor" },
                    { "df544456-91fa-4c5c-af68-9305efcea171", "¿Qué son los Pasalidos?", "Los pasálidos son una familia de escarabajos conocidos por su comportamiento social y ecológico, especializados en la descomposición de madera en bosques húmedos y tropicales." },
                    { "f9aa5002-035e-41c2-abd2-8e014bf1e1a0", "¿Quiéres conocer mas sobre otras familias de escarabajos?", "Te recomendamos las siguiente paginas para saber mas sobre otras familias. " }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "28cdd586-d840-452c-9f53-00359913e26d", "5a5c324e-4b62-43e6-899a-95b8ba4b142e" },
                    { "d8a195df-c68c-48cc-8ece-3a3831890d3a", "f4b179b1-313a-465f-885d-9215c72a081e" }
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
                name: "Ayuda");

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
