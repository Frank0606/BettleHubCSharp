using BettleHubCsharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettleHubCsharp.Data.Seed;

public class SeedEscarabajo : IEntityTypeConfiguration<Escarabajo>
{
    public void Configure(EntityTypeBuilder<Escarabajo> builder)
    {
        builder.HasData(
    new Escarabajo
    { 
        Especie = "especie1", 
        Alas = "alas1", 
        Antena = 01, 
        Ciclo_vida = "ciclo_vida1", 
        Elitros = "elitros1", 
        Familia = "familia1", 
        Genero = "genero1", 
        Mandibula = "mandibula1", 
        Nombre_comun = "nombre_comun1", 
        Ojos = "ojos1", 
        Patas = 01, 
        Torax = "torax1", 
        Descripcion = "Los escarabajos pasálidos, también conocidos como escarabajos de tierra, son insectos coleópteros que se caracterizan por su cuerpo ovalado y duro, así como por sus antenas cortas y robustas.", 
        Estado_investigacion = false, 
        Audios = ["./css/resources/audios/junctistriatus/P_junctistriatus_6_2.wav"], 
        Imagenes = ["./css/resources/images/pasalido1.jpg"], 
        Biologos = [], 
        Coordenadas = ["19.5450165,-96.8953113,14"], 
        Protegida = true 
    },
    new Escarabajo
    { 
        Especie = "especie2", 
        Alas = "alas2", 
        Antena = 02, 
        Ciclo_vida = "ciclo_vida2", 
        Elitros = "elitros2", 
        Familia = "familia2", 
        Genero = "genero2", 
        Mandibula = "mandibula2", 
        Nombre_comun = "nombre_comun2", 
        Ojos = "ojos2", 
        Patas = 02, 
        Torax = "torax2", 
        Descripcion = "Los escarabajos pasálidos: pequeños guardianes del suelo. Estos insectos, con su armadura brillante y patas fuertes, son esenciales para mantener el equilibrio del ecosistema del suelo al descomponer materia orgánica y aerar el sustrato.", 
        Estado_investigacion = false, 
        Audios = ["./css/resources/audios/junctistriatus/P_junctistriatus_6_2.wav"], 
        Imagenes = ["./css/resources/images/pasalido2.jpg"], 
        Biologos = [], 
        Coordenadas = ["17.0794635,-96.7063748,17"], 
        Protegida = true 
    },
    new Escarabajo
    { 
        Especie = "especie3", 
        Alas = "alas3", 
        Antena = 03, 
        Ciclo_vida = "ciclo_vida3", 
        Elitros = "elitros3", 
        Familia = "familia3", 
        Genero = "genero3", 
        Mandibula = "mandibula3", 
        Nombre_comun = "nombre_comun3", 
        Ojos = "ojos3", 
        Patas = 03, 
        Torax = "torax3", 
        Descripcion = "Los escarabajos pasálidos son criaturas fascinantes que se encuentran en una variedad de hábitats terrestres. Su papel como descomponedores es crucial para el ciclo de nutrientes, contribuyendo al proceso de compostaje y enriqueciendo la salud del suelo.", 
        Estado_investigacion = false, 
        Audios = ["./css/resources/audios/subopacus/P_subopacus_5_3.wav"], 
        Imagenes = ["./css/resources/images/pasalido3.jpg"], 
        Biologos = [], 
        Coordenadas = ["19.4973646,-96.8573872,16"], 
        Protegida = true 
    },
    new Escarabajo
    { 
        Especie = "especie4", 
        Alas = "alas4", 
        Antena = 04, 
        Ciclo_vida = "ciclo_vida4", 
        Elitros = "elitros4", 
        Familia = "familia4", 
        Genero = "genero4", 
        Mandibula = "mandibula4", 
        Nombre_comun = "nombre_comun4", 
        Ojos = "ojos4", 
        Patas = 04, 
        Torax = "torax4", 
        Descripcion = "Descubre el mundo subterráneo de los escarabajos pasálidos. Estos pequeños insectos, con su caparazón brillante y su actividad incansable, desempeñan un papel vital en la transformación de materia orgánica en nutrientes disponibles para otras formas de vida en el suelo.", 
        Estado_investigacion = false, 
        Audios = ["./css/resources/audios/zuninoi/P_zuninoi_3_6.wav"], 
        Imagenes = ["./css/resources/images/pasalido4.jpg"], 
        Biologos = [], 
        Coordenadas = ["19.5266079,-96.9242194,17"], 
        Protegida = true 
    }
);

    }
}