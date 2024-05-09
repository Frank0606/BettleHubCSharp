using BettleHubCsharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettleHubCsharp.Data.Seed;

public class SeedAyuda : IEntityTypeConfiguration<Ayuda>
{
    public void Configure(EntityTypeBuilder<Ayuda> builder)
    {
        builder.HasData(
            new Ayuda { Id = Guid.NewGuid().ToString(), Titulo = "Documentacion sobre la pagina", Contenido = "Información detallada sobre cómo funciona la página y la tecnología detrás de ella."},
            new Ayuda { Id = Guid.NewGuid().ToString(), Titulo = "Sobre que trata la aplicacion", Contenido = "Descripción general de la aplicación y sus objetivos."},
            new Ayuda { Id = Guid.NewGuid().ToString(), Titulo = "Preguntas generales", Contenido = "Respuestas a las preguntas más frecuentes sobre el uso de la plataforma."},
            new Ayuda { Id = Guid.NewGuid().ToString(), Titulo = "Guia de uso", Contenido = "Una pequeña guía paso a paso sobre cómo utilizar las principales características de la aplicación."}
        );
    }
}