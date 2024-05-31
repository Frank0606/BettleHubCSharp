﻿// <auto-generated />
using System;
using BettleHubCsharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BettleHubCsharp.Migrations
{
    [DbContext(typeof(IdentityContext))]
    partial class IdentityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BettleHubCsharp.Models.Ayuda", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subtitulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Ayuda");

                    b.HasData(
                        new
                        {
                            Id = "5f1e660c-c5d0-4442-ba54-6f364b10eb54",
                            Contenido = "La página Beetle-finder está diseñada para permitir a los biólogos clasificar y registrar escarabajos de la familia Passalidae de una manera eficiente. Utiliza tecnologías modernas como C# para ofrecer una experiencia fluida y segura.",
                            Subtitulo = "Información detallada sobre cómo funciona la página y la tecnología detrás de ella.",
                            Titulo = "Documentación sobre la página"
                        },
                        new
                        {
                            Id = "7d2f481d-7d5a-4d52-972e-204a05d1dc30",
                            Contenido = "Beetle-finder es una aplicación destinada a ayudar a los biólogos en la clasificación y registro de escarabajos, centrándose especialmente en la familia Passalidae. Su objetivo principal es proporcionar una herramienta fácil de usar y eficiente para este propósito.",
                            Subtitulo = "Descripción general de la aplicación y sus objetivos.",
                            Titulo = "Sobre qué trata la aplicación"
                        },
                        new
                        {
                            Id = "4f3bf304-035a-4c11-b196-7dcf9a3b9586",
                            Contenido = "1. ¿Qué es Beetle-finder? Beetle-finder es una aplicación diseñada para ayudar a los biólogos en la clasificación y registro de escarabajos, especialmente de la familia Passalidae.\n                    2. ¿Por qué solo hablamos de la familia Passalidae? Nos enfocamos en la familia Passalidae porque es una de las familias de escarabajos más diversas y relevantes para la investigación biológica.\n                    3. ¿Cómo hago la clasificación de mi escarabajo para identificarlo? Puedes utilizar las funciones de búsqueda y clasificación de Beetle-finder para identificar y clasificar tu escarabajo según características específicas.",
                            Subtitulo = "Respuestas a las preguntas más frecuentes sobre el uso de la plataforma.",
                            Titulo = "Preguntas generales"
                        },
                        new
                        {
                            Id = "4a1235a9-f916-4409-a07a-1ad724eb60c9",
                            Contenido = "Inicio de Sesión:\n                    Para acceder a las funcionalidades de la plataforma, primero debes iniciar sesión.\n                    En la página de inicio de sesión, ingresa tu correo electrónico y contraseña. Si no tienes una cuenta, contacta al administrador para obtener acceso.\n\n                    Administración de Biólogos:\n                    En esta sección podrás administrar los biólogos registrados en la plataforma.\n                    Mostrar:\n                    Para visualizar la lista de biólogos registrados, haz clic en el enlace 'Mostrar' ubicado en la barra de navegación. Se abrirá una tabla que muestra los nombres, correos electrónicos, edades y teléfonos de los biólogos.\n                    Agregar:\n                    Para agregar un nuevo biólogo, haz clic en el enlace 'Agregar' ubicado en la barra de navegación. Se abrirá un modal donde podrás ingresar los datos del nuevo biólogo, como nombre, correo electrónico, edad, teléfono y contraseña.\n\n                    Administración de Escarabajos:\n                    En esta sección podrás administrar los escarabajos registrados en la plataforma.\n                    Mostrar:\n                    Para visualizar la lista de escarabajos registrados, haz clic en el enlace 'Mostrar' ubicado en la barra de navegación. Se abrirá una tabla que muestra los nombres, especies, hábitats y otros datos relevantes de los escarabajos.\n                    Agregar:\n                    Para agregar un nuevo escarabajo, haz clic en el enlace 'Agregar' ubicado en la barra de navegación. Se abrirá un modal donde podrás ingresar los datos del nuevo escarabajo, como nombre, especie, hábitat y características adicionales.\n\n                    Galería de Escarabajos:\n                    En esta sección podrás visualizar imágenes de los escarabajos registrados en la plataforma.\n                    Para acceder a la galería, selecciona la opción 'Galería' en la barra de navegación. Aquí podrás ver imágenes y detalles de los escarabajos, facilitando su identificación y estudio.\n\n                    Clasificador:\n                    La página de Clasificador permite a los biólogos clasificar los escarabajos a partir de grabaciones de audio. Aquí se describen los pasos para utilizar la página:\n\n                    1. Cargar Audio:\n                    Para cargar un archivo de audio, selecciona el botón 'Subir audio'. Se abrirá un diálogo donde podrás elegir el archivo de audio desde tu dispositivo. Asegúrate de que el archivo esté en un formato compatible y que el nombre del archivo se muestre después de seleccionarlo.\n\n                    2. Ingresar Datos:\n                    - Biólogo: Este campo muestra el nombre del biólogo que está realizando la clasificación. Está deshabilitado para edición directa.\n                    - Coordenadas: Ingrese las coordenadas del lugar donde se registró el audio del escarabajo.\n\n                    3. Previsualización del Audio:\n                    Después de cargar el audio, se mostrará un reproductor de audio donde podrás escuchar el archivo cargado.\n\n                    4. Clasificar:\n                    Presiona el botón 'Clasificar' para procesar el audio. La aplicación analizará el audio y mostrará los resultados de la clasificación.\n\n                    Resultado:\n                    Una vez que se complete la clasificación, se mostrará una imagen del escarabajo clasificado, el nombre científico y el porcentaje de certeza de la clasificación. Si la sección de resultados está oculta, se mostrará al completarse la clasificación.",
                            Subtitulo = "Una pequeña guía paso a paso sobre cómo utilizar las principales características de la aplicación.",
                            Titulo = "Guía de uso"
                        });
                });

            modelBuilder.Entity("BettleHubCsharp.Models.Biologo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Protegida")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2c2cf0ac-2fb4-4e08-98b3-da1daa9d8a56",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fe3535c9-6789-4b18-91f0-0a3e315f430c",
                            Edad = 19,
                            Email = "Correo1@correo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CORREO1@CORREO.COM",
                            NormalizedUserName = "NOMBRE1",
                            PasswordHash = "AQAAAAIAAYagAAAAEAHRoj/djCB9VzkTlhR2xt9jw9dlnOI58iSzsxda44ToW0irArPo0vTn5NxcfKwi5A==",
                            PhoneNumber = "9999999999",
                            PhoneNumberConfirmed = false,
                            Protegida = true,
                            SecurityStamp = "cfd4dd2d-ae7c-4a8a-9fef-e540d8cda41a",
                            TwoFactorEnabled = false,
                            UserName = "Nombre1"
                        },
                        new
                        {
                            Id = "a2da234c-bcdc-4c77-8dfb-460937c45e56",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6882c8d4-677b-44b2-a5b6-cf7a19f55055",
                            Edad = 20,
                            Email = "Correo2@correo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CORREO2@CORREO.COM",
                            NormalizedUserName = "Nombre2",
                            PasswordHash = "AQAAAAIAAYagAAAAENPqEllMgJXYiEiwDQYuyr5oqvt/UqTvn8G/Nu3jKI9dH9XzLgVSwSz6Eyb7JLsIkA==",
                            PhoneNumber = "9999999999",
                            PhoneNumberConfirmed = false,
                            Protegida = false,
                            SecurityStamp = "09beda82-cde2-4560-bc96-291817253b09",
                            TwoFactorEnabled = false,
                            UserName = "Nombre2"
                        });
                });

            modelBuilder.Entity("BettleHubCsharp.Models.DatoCurioso", b =>
                {
                    b.Property<string>("Id_Dato")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion_Dato")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_Dato");

                    b.ToTable("DatoCurioso");

                    b.HasData(
                        new
                        {
                            Id_Dato = "477fa6cc-aacb-4bed-999d-51c742902037",
                            Descripcion_Dato = "Los Pasalidos son conocidos por su capacidad para producir sonidos, un comportamiento conocido como estridulación."
                        },
                        new
                        {
                            Id_Dato = "8eea334f-f8eb-4f31-88c9-81060a62a775",
                            Descripcion_Dato = "El comportamiento social de los Pasalidos es vivir en grupos familiares donde cooperan en el cuidado de las larvas y el mantenimiento de su hogar."
                        },
                        new
                        {
                            Id_Dato = "08d3e208-1a4d-4442-aefa-81755537eff8",
                            Descripcion_Dato = "Estos escarabajos son uno de los pocos grupos de coleópteros que exhiben cuidado parental extenso."
                        },
                        new
                        {
                            Id_Dato = "0bed030f-feb1-411e-8d6f-528b4bd0d946",
                            Descripcion_Dato = "Los Pasalidos ayudan en el ciclo de nutrientes en los ecosistemas forestales."
                        },
                        new
                        {
                            Id_Dato = "8e166ef1-57aa-4647-bc90-e169eb37d77b",
                            Descripcion_Dato = "Aunque principalmente habitan en bosques húmedos y tropicales, tambien habitan bosques templados y áreas montañosas."
                        },
                        new
                        {
                            Id_Dato = "0ee7ca41-4736-4b87-846a-2ccd0f1778a8",
                            Descripcion_Dato = "Los escarabajos de esta familia son xilófagos, lo que significa que se alimentan principalmente de madera."
                        },
                        new
                        {
                            Id_Dato = "554748f9-69a5-4d11-966b-4b85b2b3d78d",
                            Descripcion_Dato = "Tienen cuerpos alargados y robustos, cabezas grandes y cuernos que utilizan en sus rituales de apareamiento y en la lucha por territorio o parejas."
                        },
                        new
                        {
                            Id_Dato = "d6b8a29e-5e43-4928-9327-d6eaff39ceba",
                            Descripcion_Dato = "Estos escarabajos pueden tener ciclos de vida relativamente largos en comparación con otros insectos."
                        },
                        new
                        {
                            Id_Dato = "931989ce-41bd-4304-912c-52fbf45226ec",
                            Descripcion_Dato = "Los Pasalidos se encuentran principalmente en las regiones tropicales de América, Asia y África. En América, su distribución va desde México hasta Argentina."
                        },
                        new
                        {
                            Id_Dato = "805ad7b8-e652-4a87-b11a-c6d0b2e11653",
                            Descripcion_Dato = "Los Pasalidos son objeto de estudio en áreas como ecología del comportamiento, biología de la conservación y entomología forestal."
                        });
                });

            modelBuilder.Entity("BettleHubCsharp.Models.Escarabajo", b =>
                {
                    b.Property<string>("Especie")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Alas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Antena")
                        .HasColumnType("int");

                    b.Property<string>("Audios")
                        .HasColumnType("longtext");

                    b.Property<string>("Ciclo_vida")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Coordenadas")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Elitros")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Estado_investigacion")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Familia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagenes")
                        .HasColumnType("longtext");

                    b.Property<string>("Mandibula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre_comun")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ojos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Patas")
                        .HasColumnType("int");

                    b.Property<bool>("Protegida")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Torax")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Especie");

                    b.ToTable("Escarabajo");

                    b.HasData(
                        new
                        {
                            Especie = "especie1",
                            Alas = "alas1",
                            Antena = 1,
                            Audios = "[\"./css/resources/audios/junctistriatus/P_junctistriatus_6_2.wav\"]",
                            Ciclo_vida = "ciclo_vida1",
                            Coordenadas = "[\"19.5450165,-96.8953113,14\"]",
                            Descripcion = "Los escarabajos pasálidos, también conocidos como escarabajos de tierra, son insectos coleópteros que se caracterizan por su cuerpo ovalado y duro, así como por sus antenas cortas y robustas.",
                            Elitros = "elitros1",
                            Estado_investigacion = false,
                            Familia = "familia1",
                            Genero = "genero1",
                            Imagenes = "[\"./css/resources/images/pasalido1.webp\"]",
                            Mandibula = "mandibula1",
                            Nombre_comun = "nombre_comun1",
                            Ojos = "ojos1",
                            Patas = 1,
                            Protegida = true,
                            Torax = "torax1"
                        },
                        new
                        {
                            Especie = "especie2",
                            Alas = "alas2",
                            Antena = 2,
                            Audios = "[\"./css/resources/audios/junctistriatus/P_junctistriatus_6_2.wav\"]",
                            Ciclo_vida = "ciclo_vida2",
                            Coordenadas = "[\"17.0794635,-96.7063748,17\"]",
                            Descripcion = "Los escarabajos pasálidos: pequeños guardianes del suelo. Estos insectos, con su armadura brillante y patas fuertes, son esenciales para mantener el equilibrio del ecosistema del suelo al descomponer materia orgánica y aerar el sustrato.",
                            Elitros = "elitros2",
                            Estado_investigacion = false,
                            Familia = "familia2",
                            Genero = "genero2",
                            Imagenes = "[\"./css/resources/images/pasalido2.webp\"]",
                            Mandibula = "mandibula2",
                            Nombre_comun = "nombre_comun2",
                            Ojos = "ojos2",
                            Patas = 2,
                            Protegida = true,
                            Torax = "torax2"
                        },
                        new
                        {
                            Especie = "especie3",
                            Alas = "alas3",
                            Antena = 3,
                            Audios = "[\"./css/resources/audios/subopacus/P_subopacus_5_3.wav\"]",
                            Ciclo_vida = "ciclo_vida3",
                            Coordenadas = "[\"19.4973646,-96.8573872,16\"]",
                            Descripcion = "Los escarabajos pasálidos son criaturas fascinantes que se encuentran en una variedad de hábitats terrestres. Su papel como descomponedores es crucial para el ciclo de nutrientes, contribuyendo al proceso de compostaje y enriqueciendo la salud del suelo.",
                            Elitros = "elitros3",
                            Estado_investigacion = false,
                            Familia = "familia3",
                            Genero = "genero3",
                            Imagenes = "[\"./css/resources/images/pasalido3.webp\"]",
                            Mandibula = "mandibula3",
                            Nombre_comun = "nombre_comun3",
                            Ojos = "ojos3",
                            Patas = 3,
                            Protegida = true,
                            Torax = "torax3"
                        },
                        new
                        {
                            Especie = "especie4",
                            Alas = "alas4",
                            Antena = 4,
                            Audios = "[\"./css/resources/audios/zuninoi/P_zuninoi_3_6.wav\"]",
                            Ciclo_vida = "ciclo_vida4",
                            Coordenadas = "[\"19.5266079,-96.9242194,17\"]",
                            Descripcion = "Descubre el mundo subterráneo de los escarabajos pasálidos. Estos pequeños insectos, con su caparazón brillante y su actividad incansable, desempeñan un papel vital en la transformación de materia orgánica en nutrientes disponibles para otras formas de vida en el suelo.",
                            Elitros = "elitros4",
                            Estado_investigacion = false,
                            Familia = "familia4",
                            Genero = "genero4",
                            Imagenes = "[\"./css/resources/images/pasalido4.webp\"]",
                            Mandibula = "mandibula4",
                            Nombre_comun = "nombre_comun4",
                            Ojos = "ojos4",
                            Patas = 4,
                            Protegida = true,
                            Torax = "torax4"
                        });
                });

            modelBuilder.Entity("BettleHubCsharp.Models.Pregunta", b =>
                {
                    b.Property<string>("Id_pregunta")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Pregunta_pregunta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Respuesta_pregunta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_pregunta");

                    b.ToTable("Pregunta");

                    b.HasData(
                        new
                        {
                            Id_pregunta = "0299edc9-9dbb-4bea-b0e3-29a28c218978",
                            Pregunta_pregunta = "¿Quiénes fueron los desarrolladores?",
                            Respuesta_pregunta = "Somos un grupo de estudiantes de la carrera Lic. Tecnologías Computacionales de la Universidad Veracruzana. Nuestro proyecto Beetle-Finder es un ejemplo sobre nuestro trabajo como desarrolladores, enfocandonos en una comunidad cientifica."
                        },
                        new
                        {
                            Id_pregunta = "5b9a379c-917b-4a89-ac4f-4d942d5cb164",
                            Pregunta_pregunta = "¿Quién es el Dr Edwin Eriza?",
                            Respuesta_pregunta = "Un doctor"
                        },
                        new
                        {
                            Id_pregunta = "69bb01fc-a99e-4fc8-bd67-86846f37baa2",
                            Pregunta_pregunta = "¿Qué son los Pasalidos?",
                            Respuesta_pregunta = "Los pasálidos son una familia de escarabajos conocidos por su comportamiento social y ecológico, especializados en la descomposición de madera en bosques húmedos y tropicales."
                        },
                        new
                        {
                            Id_pregunta = "93000261-8828-456b-b5c6-570e3b56e523",
                            Pregunta_pregunta = "¿Quiéres conocer mas sobre otras familias de escarabajos?",
                            Respuesta_pregunta = "Te recomendamos las siguiente paginas para saber mas sobre otras familias. "
                        },
                        new
                        {
                            Id_pregunta = "53e32391-ffcc-48e3-a1cb-81cf4a189696",
                            Pregunta_pregunta = "¿Que hace Bettle-Finder?",
                            Respuesta_pregunta = "Es un paginas web sobre los escarabajos de la familia Passalidae, con la funcion unica de poder clasificar sus sonidos por especie."
                        });
                });

            modelBuilder.Entity("BiologoEscarabajo", b =>
                {
                    b.Property<string>("BiologosId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EscarabajosEspecie")
                        .HasColumnType("varchar(255)");

                    b.HasKey("BiologosId", "EscarabajosEspecie");

                    b.HasIndex("EscarabajosEspecie");

                    b.ToTable("BiologoEscarabajo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b2dd9638-5cea-4782-9434-3938c1c3bb24",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "68da720c-25ed-4584-814c-581995de3af2",
                            Name = "Biologo",
                            NormalizedName = "BIOLOGO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "2c2cf0ac-2fb4-4e08-98b3-da1daa9d8a56",
                            RoleId = "b2dd9638-5cea-4782-9434-3938c1c3bb24"
                        },
                        new
                        {
                            UserId = "a2da234c-bcdc-4c77-8dfb-460937c45e56",
                            RoleId = "68da720c-25ed-4584-814c-581995de3af2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BiologoEscarabajo", b =>
                {
                    b.HasOne("BettleHubCsharp.Models.Biologo", null)
                        .WithMany()
                        .HasForeignKey("BiologosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BettleHubCsharp.Models.Escarabajo", null)
                        .WithMany()
                        .HasForeignKey("EscarabajosEspecie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BettleHubCsharp.Models.Biologo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BettleHubCsharp.Models.Biologo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BettleHubCsharp.Models.Biologo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BettleHubCsharp.Models.Biologo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
