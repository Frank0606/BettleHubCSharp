using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettleHubCsharp.Data.Seed;

public class SeedDatosCuriosos : IEntityTypeConfiguration<DatoCurioso>
{
    public void Configure(EntityTypeBuilder<DatoCurioso> builder)
    {
        builder.HasData(
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Los Pasalidos son conocidos por su capacidad para producir sonidos, un comportamiento conocido como estridulación."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "El comportamiento social de los Pasalidos es vivir en grupos familiares donde cooperan en el cuidado de las larvas y el mantenimiento de su hogar."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Estos escarabajos son uno de los pocos grupos de coleópteros que exhiben cuidado parental extenso."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Los Pasalidos ayudan en el ciclo de nutrientes en los ecosistemas forestales."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Aunque principalmente habitan en bosques húmedos y tropicales, tambien habitan bosques templados y áreas montañosas."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Los escarabajos de esta familia son xilófagos, lo que significa que se alimentan principalmente de madera."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Tienen cuerpos alargados y robustos, cabezas grandes y cuernos que utilizan en sus rituales de apareamiento y en la lucha por territorio o parejas."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Estos escarabajos pueden tener ciclos de vida relativamente largos en comparación con otros insectos."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Los Pasalidos se encuentran principalmente en las regiones tropicales de América, Asia y África. En América, su distribución va desde México hasta Argentina."},
            new DatoCurioso { Id_Dato = Guid.NewGuid().ToString(), Descripcion_Dato = "Los Pasalidos son objeto de estudio en áreas como ecología del comportamiento, biología de la conservación y entomología forestal."}
        );
    }
}