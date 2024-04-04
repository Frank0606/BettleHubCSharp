using BettleHubCsharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettleHubCsharp.Data.Seed;

public class SeedEscarabajo : IEntityTypeConfiguration<Escarabajo>
{
    public void Configure(EntityTypeBuilder<Escarabajo> builder)
    {
        builder.HasData(
            new Escarabajo { Especie_escarabajo = "especie1", Alas_escarabajo = "alas1", Antena_escarabajo = 01, Ciclo_vida_escarabajo = "ciclo_vida1", Elitros_escarabajo = "elitros1", Familia_escarabajo = "familia1", Genero_escarabajo = "genero1", Mandibula_escarabajo = "mandibula1", Nombre_comun_escarabajo = "nombre_comun1", Ojos_escarabajos = "ojos1", Patas_escarabajo = 01, Torax_escarabajo = "torax1", Audios_escarabajo = [], Imagenes_escarabajo = [], Biologos = [], Protegida = true },
            new Escarabajo { Especie_escarabajo = "especie2", Alas_escarabajo = "alas2", Antena_escarabajo = 02, Ciclo_vida_escarabajo = "ciclo_vida2", Elitros_escarabajo = "elitros2", Familia_escarabajo = "familia2", Genero_escarabajo = "genero2", Mandibula_escarabajo = "mandibula2", Nombre_comun_escarabajo = "nombre_comun2", Ojos_escarabajos = "ojos2", Patas_escarabajo = 02, Torax_escarabajo = "torax2", Audios_escarabajo = [], Imagenes_escarabajo = [], Biologos = [], Protegida = true },
            new Escarabajo { Especie_escarabajo = "especie3", Alas_escarabajo = "alas3", Antena_escarabajo = 03, Ciclo_vida_escarabajo = "ciclo_vida3", Elitros_escarabajo = "elitros3", Familia_escarabajo = "familia3", Genero_escarabajo = "genero3", Mandibula_escarabajo = "mandibula3", Nombre_comun_escarabajo = "nombre_comun3", Ojos_escarabajos = "ojos3", Patas_escarabajo = 03, Torax_escarabajo = "torax3", Audios_escarabajo = [], Imagenes_escarabajo = [], Biologos = [], Protegida = true },
            new Escarabajo { Especie_escarabajo = "especie4", Alas_escarabajo = "alas4", Antena_escarabajo = 04, Ciclo_vida_escarabajo = "ciclo_vida4", Elitros_escarabajo = "elitros4", Familia_escarabajo = "familia4", Genero_escarabajo = "genero4", Mandibula_escarabajo = "mandibula4", Nombre_comun_escarabajo = "nombre_comun4", Ojos_escarabajos = "ojos4", Patas_escarabajo = 04, Torax_escarabajo = "torax4", Audios_escarabajo = [], Imagenes_escarabajo = [], Biologos = [], Protegida = true }
        );
    }
}