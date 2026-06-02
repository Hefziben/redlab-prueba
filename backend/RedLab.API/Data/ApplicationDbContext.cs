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

                },
                new Producto
                {
                    Id = Guid.Parse("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"),
                    Nombre = "Teclado Mecánico RGB",
                    Descripcion = "Teclado con switches mecánicos silenciosos y distribución ISO",
                    Precio = 89.99m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("c3d4e5f6-a7b8-9c0d-1e2f-3a4b5c6d7e8f"),
                    Nombre = "Mouse Ergonómico Inalámbrico",
                    Descripcion = "Mouse con sensor de alta precisión y batería recargable de larga duración",
                    Precio = 59.90m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"),
                    Nombre = "Laptop Pro 16\"",
                    Descripcion = "32GB RAM, 1TB SSD NVMe, procesador de última generación para desarrollo",
                    Precio = 1350.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("e5f6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"),
                    Nombre = "Hub USB-C 8 en 1",
                    Descripcion = "Adaptador de aluminio con puertos HDMI 4K, SD, MicroSD y USB 3.0",
                    Precio = 42.50m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("f6a7b8c9-d0e1-2f3a-4b5c-6d7e8f9a0b1c"),
                    Nombre = "Silla Ergonómica de Oficina",
                    Descripcion = "Silla con soporte lumbar ajustable y reposabrazos 3D",
                    Precio = 210.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("0a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4c5d"),
                    Nombre = "Disco Duro Externo 2TB",
                    Descripcion = "Almacenamiento portátil USB 3.2 de alta velocidad con cifrado de hardware",
                    Precio = 75.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("1b2c3d4e-5f6a-7b8c-9d0e-1f2a3b4c5d6e"),
                    Nombre = "Auriculares con Cancelación de Ruido",
                    Descripcion = "Auriculares circumaurales inalámbricos con ANC activo ideal para llamadas",
                    Precio = 180.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("2c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"),
                    Nombre = "Memoria RAM DDR5 32GB",
                    Descripcion = "Kit de 2x16GB optimizado para alto rendimiento en servidores y compilación",
                    Precio = 125.50m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("3d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"),
                    Nombre = "Cargador GaN 65W",
                    Descripcion = "Cargador ultracompacto de pared con múltiples salidas USB-C de carga rápida",
                    Precio = 29.99m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("4e5f6a7b-8c9d-0e1f-2a3b-4c5d6e7f8a9b"),
                    Nombre = "Cámara Web 4K Pro",
                    Descripcion = "Resolución Ultra HD con corrección automática de luz y micrófonos duales",
                    Precio = 95.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("5f6a7b8c-9d0e-1f2a-3b4c-5d6e7f8a9b0c"),
                    Nombre = "Escritorio Elevable Eléctrico",
                    Descripcion = "Estructura ajustable con motor silencioso y panel de memoria de altura",
                    Precio = 340.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("6a7b8c9d-0e1f-2a3b-4c5d-6e7f8a9b0c1d"),
                    Nombre = "Switch de Red 8 Puertos Gigabit",
                    Descripcion = "Switch administrable metálico para montaje en rack o pared",
                    Precio = 48.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("7b8c9d0e-1f2a-3b4c-5d6e-7f8a9b0c1d2e"),
                    Nombre = "Router WiFi 6 de Triple Banda",
                    Descripcion = "Alta cobertura y velocidad de transferencia optimizada para entornos IoT",
                    Precio = 155.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("8c9d0e1f-2a3b-4c5d-6e7f-8a9b0c1d2e3f"),
                    Nombre = "Micrófono Condensador USB",
                    Descripcion = "Patrón cardioide con filtro antipop, óptimo para videollamadas y streaming",
                    Precio = 68.50m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("9d0e1f2a-3b4c-5d6e-7f8a-9b0c1d2e3f4a"),
                    Nombre = "Gabinete Porta Servidor Rack 6U",
                    Descripcion = "Gabinete de pared para equipos de telecomunicación con puerta de vidrio templado",
                    Precio = 110.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("0e1f2a3b-4c5d-6e7f-8a9b-0c1d2e3f4a5b"),
                    Nombre = "Cable de Red Cat6 UTP 305m",
                    Descripcion = "Bobina de cable de par trenzado de cobre puro de alto rendimiento",
                    Precio = 85.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("1f2a3b4c-5d6e-7f8a-9b0c-1d2e3f4a5b6c"),
                    Nombre = "UPS Sistema de Respaldo 1500VA",
                    Descripcion = "Regulador de voltaje integrado con batería de respaldo para servidores locales",
                    Precio = 195.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("2a3b4c5d-6e7f-8a9b-0c1d-2e3f4a5b6c7d"),
                    Nombre = "Lámpara de Escritorio Inteligente",
                    Descripcion = "Barra de luz para monitor con control de temperatura de color y brillo continuo",
                    Precio = 38.00m,
                    Estado = true,
                    UsuarioCreacion = "SystemAdmin",
                    UsuarioModificacion = "SystemAdmin",
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                },
                new Producto
                {
                    Id = Guid.Parse("3a3b4c5d-6e7f-8a9b-0c1d-2e3f4a5b6c7e"),
                    Nombre = "Punto de Acceso PoE Exterior",
                    Descripcion = "Access point robusto con protección IP65 e ideal para cobertura extendida",
                    Precio = 115.00m,
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