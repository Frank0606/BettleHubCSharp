using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettleHubCsharp.Data.Seed;

public class SeedBiologo : IEntityTypeConfiguration<Biologo>
{
    public void Configure(EntityTypeBuilder<Biologo> builder)
    {
        builder.HasData(
            new Biologo { Id_biologo = Guid.NewGuid().ToString(), Correo_biologo = "Correo1", Nombre_biologo = "Nombre1", Edad_biologo = 19, Telefono_biologo = 9999999999, Contrasena_biologo = new PasswordHasher<IdentityBiologo>().HashPassword(null, "1234"), Usuario_biologo = "Usuario1", Protegida=true},
            new Biologo { Id_biologo = Guid.NewGuid().ToString(), Correo_biologo = "Correo2", Nombre_biologo = "Nombre2", Edad_biologo = 20, Telefono_biologo = 9999999999, Contrasena_biologo = new PasswordHasher<IdentityBiologo>().HashPassword(null, "1234"), Usuario_biologo = "Usuario2", Protegida=true},
            new Biologo { Id_biologo = Guid.NewGuid().ToString(), Correo_biologo = "Correo3", Nombre_biologo = "Nombre3", Edad_biologo = 18, Telefono_biologo = 9999999999, Contrasena_biologo = new PasswordHasher<IdentityBiologo>().HashPassword(null, "1234"), Usuario_biologo = "Usuario3", Protegida=true},
            new Biologo { Id_biologo = Guid.NewGuid().ToString(), Correo_biologo = "Correo4", Nombre_biologo = "Nombre4", Edad_biologo = 23, Telefono_biologo = 9999999999, Contrasena_biologo = new PasswordHasher<IdentityBiologo>().HashPassword(null, "1234"), Usuario_biologo = "Usuario4", Protegida=true}
        );
    }
}