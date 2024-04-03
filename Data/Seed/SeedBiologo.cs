using BettleHubCsharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettleHubCsharp.Data.Seed;

public class SeedBiologo : IEntityTypeConfiguration<Biologo>
{
    public void Configure(EntityTypeBuilder<Biologo> builder)
    {
        builder.HasData(
            new Biologo { Id_biologo = 1, Correo_biologo = "Correo1", Nombre_biologo = "Nombre1", Edad_biologo = 19, Telefono_biologo = 1, Contrasena_biologo = "1234", Usuario_biologo = "Usuario1", Protegida=true},
            new Biologo { Id_biologo = 2, Correo_biologo = "Correo2", Nombre_biologo = "Nombre2", Edad_biologo = 20, Telefono_biologo = 2, Contrasena_biologo = "1234", Usuario_biologo = "Usuario2", Protegida=true},
            new Biologo { Id_biologo = 3, Correo_biologo = "Correo3", Nombre_biologo = "Nombre3", Edad_biologo = 18, Telefono_biologo = 3, Contrasena_biologo = "1234", Usuario_biologo = "Usuario3", Protegida=true},
            new Biologo { Id_biologo = 4, Correo_biologo = "Correo4", Nombre_biologo = "Nombre4", Edad_biologo = 23, Telefono_biologo = 4, Contrasena_biologo = "1234", Usuario_biologo = "Usuario4", Protegida=true}
        );
    }
}