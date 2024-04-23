using BettleHubCsharp.Data.Seed;
using BettleHubCsharp.Models;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Data;

public class DataContext : DbContext{
    public DataContext(DbContextOptions<DataContext> options) : base(options){

    }

    public DbSet<Biologo> Biologo { get; set; }
    public DbSet<Escarabajo> Escarabajo { get; set; }
    public DbSet<Pregunta> Pregunta { get; set; }
    public DbSet<DatoCurioso> DatoCurioso { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SeedBiologo());
        modelBuilder.ApplyConfiguration(new SeedEscarabajo());
        modelBuilder.ApplyConfiguration(new SeedPreguntas());
        modelBuilder.ApplyConfiguration(new SeedDatosCuriosos());
    }
}