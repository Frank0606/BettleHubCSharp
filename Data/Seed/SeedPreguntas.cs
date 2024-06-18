using BettleHubCsharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettleHubCsharp.Data.Seed;

public class SeedPreguntas : IEntityTypeConfiguration<Pregunta>
{
    public void Configure(EntityTypeBuilder<Pregunta> builder)
    {
        builder.HasData(
            new Pregunta { Id_pregunta = Guid.NewGuid().ToString(), Pregunta_pregunta = "¿Quiénes fueron los desarrolladores?", Respuesta_pregunta = "Somos un grupo de estudiantes de la carrera Lic. Tecnologías Computacionales de la Universidad Veracruzana. Nuestro proyecto Beetle-Finder es un ejemplo sobre nuestro trabajo como desarrolladores, enfocándonos en una comunidad científica."},
            new Pregunta { Id_pregunta = Guid.NewGuid().ToString(), Pregunta_pregunta = "¿Quién es el Dr Edwin Eriza?", Respuesta_pregunta = "Un doctor"},
            new Pregunta { Id_pregunta = Guid.NewGuid().ToString(), Pregunta_pregunta = "¿Qué son los Pasalidos?", Respuesta_pregunta = "Los pasálidos son una familia de escarabajos conocidos por su comportamiento social y ecológico, especializados en la descomposición de madera en bosques húmedos y tropicales."},
            new Pregunta { Id_pregunta = Guid.NewGuid().ToString(), Pregunta_pregunta = "¿Quiéres conocer mas sobre otras familias de escarabajos?", Respuesta_pregunta = "Te recomendamos las siguiente páginas para saber más sobre otras familias. "},
            new Pregunta { Id_pregunta = Guid.NewGuid().ToString(), Pregunta_pregunta = "¿Qué hace Bettle-Finder?", Respuesta_pregunta = "Es una página web sobre los escarabajos de la familia Passalidae, con la funcion única de poder clasificar sus sonidos por especie."}
        );
    }
}