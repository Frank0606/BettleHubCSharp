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
                    { "5ebe4b71-e92a-4b1c-8773-c90f08f48f4d", null, "Biologo", "BIOLOGO" },
                    { "71f720bc-d764-481d-bf51-c36aa35f8ae5", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Edad", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Protegida", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ccd4ab7-9656-4670-9f02-498751c28a75", 0, "b83a1dc2-1cb2-4f52-aa27-35806096c507", 19, "Correo1@correo.com", false, false, null, "CORREO1@CORREO.COM", "NOMBRE1", "AQAAAAIAAYagAAAAEO7D6P61PuK26+S/MIbTQnIo0ofVqZmSETh8QSG+fbKb+rKWsbwJZH1BDgpw6/6wIg==", "9999999999", false, true, "57e3af74-0610-449b-8efd-928a9b37d21d", false, "Nombre1" },
                    { "98eecd65-8cd3-4c51-af92-c0a157665199", 0, "e39db5f1-0971-42c3-afee-5658b1655431", 20, "Correo2@correo.com", false, false, null, "CORREO2@CORREO.COM", "Nombre2", "AQAAAAIAAYagAAAAEI8pOwo5aDqunQKc6gJZlxWBeXFF8dizKhhpXcSBGjwFl5BPgFcD+MP94BjHqhx3BQ==", "9999999999", false, false, "d9d3cc17-1b2a-4c12-b2de-d987b05f9a35", false, "Nombre2" }
                });

            migrationBuilder.InsertData(
                table: "Ayuda",
                columns: new[] { "Id", "Contenido", "Subtitulo", "Titulo" },
                values: new object[,]
                {
                    { "18d24c86-1c90-47cb-9761-0b989f658ffc", "Beetle-finder es una aplicación destinada a ayudar a los biólogos en la clasificación y registro de escarabajos, centrándose especialmente en la familia Passalidae. Su objetivo principal es proporcionar una herramienta fácil de usar y eficiente para este propósito.", "Descripción general de la aplicación y sus objetivos.", "Sobre qué trata la aplicación" },
                    { "285eca6e-39c5-400b-9881-ebf3a0cbfc7c", "La página Beetle-finder está diseñada para permitir a los biólogos clasificar y registrar escarabajos de la familia Passalidae de una manera eficiente. Utiliza tecnologías modernas como C# para ofrecer una experiencia fluida y segura.", "Información detallada sobre cómo funciona la página y la tecnología detrás de ella.", "Documentación sobre la página" },
                    { "904d4118-4d44-4f1b-8b28-14d4c4b0317b", "Inicio de Sesión:\n                    Para acceder a las funcionalidades de la plataforma, primero debes iniciar sesión.\n                    En la página de inicio de sesión, ingresa tu correo electrónico y contraseña. Si no tienes una cuenta, contacta al administrador para obtener acceso.\n\n                    Administración de Biólogos:\n                    En esta sección podrás administrar los biólogos registrados en la plataforma.\n                    Mostrar:\n                    Para visualizar la lista de biólogos registrados, haz clic en el enlace 'Mostrar' ubicado en la barra de navegación. Se abrirá una tabla que muestra los nombres, correos electrónicos, edades y teléfonos de los biólogos.\n                    Agregar:\n                    Para agregar un nuevo biólogo, haz clic en el enlace 'Agregar' ubicado en la barra de navegación. Se abrirá un modal donde podrás ingresar los datos del nuevo biólogo, como nombre, correo electrónico, edad, teléfono y contraseña.\n\n                    Administración de Escarabajos:\n                    En esta sección podrás administrar los escarabajos registrados en la plataforma.\n                    Mostrar:\n                    Para visualizar la lista de escarabajos registrados, haz clic en el enlace 'Mostrar' ubicado en la barra de navegación. Se abrirá una tabla que muestra los nombres, especies, hábitats y otros datos relevantes de los escarabajos.\n                    Agregar:\n                    Para agregar un nuevo escarabajo, haz clic en el enlace 'Agregar' ubicado en la barra de navegación. Se abrirá un modal donde podrás ingresar los datos del nuevo escarabajo, como nombre, especie, hábitat y características adicionales.\n\n                    Galería de Escarabajos:\n                    En esta sección podrás visualizar imágenes de los escarabajos registrados en la plataforma.\n                    Para acceder a la galería, selecciona la opción 'Galería' en la barra de navegación. Aquí podrás ver imágenes y detalles de los escarabajos, facilitando su identificación y estudio.\n\n                    Clasificador:\n                    La página de Clasificador permite a los biólogos clasificar los escarabajos a partir de grabaciones de audio. Aquí se describen los pasos para utilizar la página:\n\n                    1. Cargar Audio:\n                    Para cargar un archivo de audio, selecciona el botón 'Subir audio'. Se abrirá un diálogo donde podrás elegir el archivo de audio desde tu dispositivo. Asegúrate de que el archivo esté en un formato compatible y que el nombre del archivo se muestre después de seleccionarlo.\n\n                    2. Ingresar Datos:\n                    - Biólogo: Este campo muestra el nombre del biólogo que está realizando la clasificación. Está deshabilitado para edición directa.\n                    - Coordenadas: Ingrese las coordenadas del lugar donde se registró el audio del escarabajo.\n\n                    3. Previsualización del Audio:\n                    Después de cargar el audio, se mostrará un reproductor de audio donde podrás escuchar el archivo cargado.\n\n                    4. Clasificar:\n                    Presiona el botón 'Clasificar' para procesar el audio. La aplicación analizará el audio y mostrará los resultados de la clasificación.\n\n                    Resultado:\n                    Una vez que se complete la clasificación, se mostrará una imagen del escarabajo clasificado, el nombre científico y el porcentaje de certeza de la clasificación. Si la sección de resultados está oculta, se mostrará al completarse la clasificación.", "Una pequeña guía paso a paso sobre cómo utilizar las principales características de la aplicación.", "Guía de uso" },
                    { "b585faee-8c72-461e-ac12-b09d8af16d7c", "1. ¿Qué es Beetle-finder? Beetle-finder es una aplicación diseñada para ayudar a los biólogos en la clasificación y registro de escarabajos, especialmente de la familia Passalidae.\n                    2. ¿Por qué solo hablamos de la familia Passalidae? Nos enfocamos en la familia Passalidae porque es una de las familias de escarabajos más diversas y relevantes para la investigación biológica.\n                    3. ¿Cómo hago la clasificación de mi escarabajo para identificarlo? Puedes utilizar las funciones de búsqueda y clasificación de Beetle-finder para identificar y clasificar tu escarabajo según características específicas.", "Respuestas a las preguntas más frecuentes sobre el uso de la plataforma.", "Preguntas generales" }
                });

            migrationBuilder.InsertData(
                table: "DatoCurioso",
                columns: new[] { "Id_Dato", "Descripcion_Dato" },
                values: new object[,]
                {
                    { "03f26d05-5fc3-4ca5-810c-a1fcfe8d12b4", "Estos escarabajos son uno de los pocos grupos de coleópteros que exhiben cuidado parental extenso." },
                    { "11ea57ed-d1ec-4fff-81e2-866791bafa11", "El comportamiento social de los Pasalidos es vivir en grupos familiares donde cooperan en el cuidado de las larvas y el mantenimiento de su hogar." },
                    { "1277de68-390f-4192-9a37-4fe2b2e8cd85", "Aunque principalmente habitan en bosques húmedos y tropicales, tambien habitan bosques templados y áreas montañosas." },
                    { "1f7f1f1a-a3cd-4381-a3cb-c3584a8a0432", "Los escarabajos de esta familia son xilófagos, lo que significa que se alimentan principalmente de madera." },
                    { "415de785-7264-410a-a793-0f35fb13aff3", "Los Pasalidos ayudan en el ciclo de nutrientes en los ecosistemas forestales." },
                    { "445d3c47-202c-47d4-a2c9-17e8e122b150", "Estos escarabajos pueden tener ciclos de vida relativamente largos en comparación con otros insectos." },
                    { "632c208f-3028-49ff-bdb6-9a4f35a91693", "Los Pasalidos son objeto de estudio en áreas como ecología del comportamiento, biología de la conservación y entomología forestal." },
                    { "c3f01393-9886-4923-b63a-8397ab8f712f", "Los Pasalidos se encuentran principalmente en las regiones tropicales de América, Asia y África. En América, su distribución va desde México hasta Argentina." },
                    { "cd568188-2f5a-479e-8b8a-6d97262f1480", "Tienen cuerpos alargados y robustos, cabezas grandes y cuernos que utilizan en sus rituales de apareamiento y en la lucha por territorio o parejas." },
                    { "e41ba3a3-d209-4ffd-b666-43470a4a0dfd", "Los Pasalidos son conocidos por su capacidad para producir sonidos, un comportamiento conocido como estridulación." }
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
                    { "6008cd37-21d6-4fbe-ab59-2f8d5ea1af32", "¿Qué son los Pasalidos?", "Los pasálidos son una familia de escarabajos conocidos por su comportamiento social y ecológico, especializados en la descomposición de madera en bosques húmedos y tropicales." },
                    { "8fc1245d-0954-41d9-adfb-546dd3fbd14b", "¿Quién es el Dr Edwin Eriza?", "Un doctor" },
                    { "e34a8f09-f49c-49a8-aba2-fd41fff40ed0", "¿Quiéres conocer mas sobre otras familias de escarabajos?", "Te recomendamos las siguiente paginas para saber mas sobre otras familias. " },
                    { "e911c8a3-bd57-4227-b2b6-e282b2f54157", "¿Quiénes fueron los desarrolladores?", "Somos un grupo de estudiantes de la carrera Lic. Tecnologías Computacionales de la Universidad Veracruzana. Nuestro proyecto Beetle-Finder es un ejemplo sobre nuestro trabajo como desarrolladores, enfocandonos en una comunidad cientifica." },
                    { "ebbc5838-5d92-48f9-bd4a-33fa190f1120", "¿Que hace Bettle-Finder?", "Es un paginas web sobre los escarabajos de la familia Passalidae, con la funcion unica de poder clasificar sus sonidos por especie." }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "71f720bc-d764-481d-bf51-c36aa35f8ae5", "1ccd4ab7-9656-4670-9f02-498751c28a75" },
                    { "5ebe4b71-e92a-4b1c-8773-c90f08f48f4d", "98eecd65-8cd3-4c51-af92-c0a157665199" }
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
