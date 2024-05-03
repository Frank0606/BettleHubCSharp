using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BettleHubCsharp.Data.Seed
{
    public static class SeedBiologo
    {
        public static void SeedUserIdentityData(this ModelBuilder modelBuilder)
        {
            // Se crea el rol de administrador
            string administradorRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = administradorRoleId,
                Name = "Administrador",
                NormalizedName = "Administrador".ToUpper()
            });

            // Se crea el rol de biologo
            string biologoRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = biologoRoleId,
                Name = "Biologo",
                NormalizedName = "Biologo".ToUpper()
            });

            // Se agrega el primer usuario que es el admin
            var userId1 = Guid.NewGuid().ToString();
            modelBuilder.Entity<Biologo>().HasData(
                new Biologo
                {
                    Id = userId1,
                    Email = "Correo1@correo.com",
                    NormalizedEmail = "Correo1@correo.com".ToUpper(),
                    UserName = "Nombre1",
                    NormalizedUserName = "Nombre1".ToUpper(),
                    Edad = 19,
                    Telefono = 9999999999,
                    PasswordHash = new PasswordHasher<Biologo>().HashPassword(new Biologo(), "1234"),
                    Protegida = true
                });

            // Se le asigna su rol de administrador
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = administradorRoleId,
                    UserId = userId1
                });

            // Se agrega el segundo usuario que es un biologo
            var userId2 = Guid.NewGuid().ToString();
            modelBuilder.Entity<Biologo>().HasData(
                new Biologo
                {
                    Id = userId2,
                    Email = "Correo2@correo.com",
                    NormalizedEmail = "Correo2@correo.com".ToUpper(),
                    UserName = "Nombre2",
                    NormalizedUserName = "Nombre2",
                    Edad = 20,
                    Telefono = 9999999999,
                    PasswordHash = new PasswordHasher<Biologo>().HashPassword(new Biologo(), "1234"),
                    Protegida = false
                });

            // Se le asigna su rol de biologo
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = biologoRoleId,
                    UserId = userId2
                });
        }
    }
}
