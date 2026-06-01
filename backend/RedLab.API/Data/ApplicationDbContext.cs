using Microsoft.EntityFrameworkCore;
using RedLab.API.Entities;
using System;

namespace RedLab.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Carga inicial de datos (Seeding) para cumplir con los catálogos iniciales 
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"),
                    Nombre = "Laptop Pro 15 pulgadas",
                    Descripcion = "Laptop de alta gama para desarrollo de software",
                    Precio = 1299.99m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,                  
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("f4e3d2c1-b0a9-8f7e-6d5c-4b3a2a1f0e9d"),
                    Nombre = "Monitor UltraWide 34\"",
                    Descripcion = "Monitor curvo ideal para multitasking",
                    Precio = 450.50m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow

                }
            );
        }
    }
}