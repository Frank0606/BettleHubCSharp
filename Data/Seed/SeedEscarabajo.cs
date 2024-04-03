using BettleHubCsharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettleHubCsharp.Data.Seed;

public class SeedEscarabajo : IEntityTypeConfiguration<Escarabajo>
{
    public void Configure(EntityTypeBuilder<Escarabajo> builder)
    {
        builder.HasData(
            new Escarabajo { }
        );
    }
}