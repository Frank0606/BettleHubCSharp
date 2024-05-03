using BettleHubCsharp.Data.Seed;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Data;

public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<Biologo>(options){

    public DbSet<Biologo> Biologo { get; set; }
    public DbSet<Escarabajo> Escarabajo { get; set; }
    public DbSet<Pregunta> Pregunta { get; set; }
    public DbSet<DatoCurioso> DatoCurioso { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SeedEscarabajo());
        modelBuilder.ApplyConfiguration(new SeedPreguntas());
        modelBuilder.ApplyConfiguration(new SeedDatosCuriosos());
        modelBuilder.SeedUserIdentityData();

        base.OnModelCreating(modelBuilder);
    }
}