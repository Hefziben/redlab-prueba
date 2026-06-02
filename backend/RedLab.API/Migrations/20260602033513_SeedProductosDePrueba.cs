using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RedLab.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductosDePrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"),
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3102), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("f4e3d2c1-b0a9-8f7e-6d5c-4b3a2a1f0e9d"),
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3111) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "Nombre", "Precio", "UsuarioCreacion", "UsuarioModificacion" },
                values: new object[,]
                {
                    { new Guid("0a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4c5d"), "Almacenamiento portátil USB 3.2 de alta velocidad con cifrado de hardware", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3154), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3154), "Disco Duro Externo 2TB", 75.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("0e1f2a3b-4c5d-6e7f-8a9b-0c1d2e3f4a5b"), "Bobina de cable de par trenzado de cobre puro de alto rendimiento", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3199), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3199), "Cable de Red Cat6 UTP 305m", 85.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("1b2c3d4e-5f6a-7b8c-9d0e-1f2a3b4c5d6e"), "Auriculares circumaurales inalámbricos con ANC activo ideal para llamadas", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3157), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3158), "Auriculares con Cancelación de Ruido", 180.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("1f2a3b4c-5d6e-7f8a-9b0c-1d2e3f4a5b6c"), "Regulador de voltaje integrado con batería de respaldo para servidores locales", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3203), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3203), "UPS Sistema de Respaldo 1500VA", 195.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("2a3b4c5d-6e7f-8a9b-0c1d-2e3f4a5b6c7d"), "Barra de luz para monitor con control de temperatura de color y brillo continuo", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3207), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3207), "Lámpara de Escritorio Inteligente", 38.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("2c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"), "Kit de 2x16GB optimizado para alto rendimiento en servidores y compilación", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3161), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3162), "Memoria RAM DDR5 32GB", 125.50m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("3a3b4c5d-6e7f-8a9b-0c1d-2e3f4a5b6c7e"), "Access point robusto con protección IP65 e ideal para cobertura extendida", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3211), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3212), "Punto de Acceso PoE Exterior", 115.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("3d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"), "Cargador ultracompacto de pared con múltiples salidas USB-C de carga rápida", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3166), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3166), "Cargador GaN 65W", 29.99m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("4e5f6a7b-8c9d-0e1f-2a3b-4c5d6e7f8a9b"), "Resolución Ultra HD con corrección automática de luz y micrófonos duales", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3169), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3170), "Cámara Web 4K Pro", 95.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("5f6a7b8c-9d0e-1f2a-3b4c-5d6e7f8a9b0c"), "Estructura ajustable con motor silencioso y panel de memoria de altura", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3174), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3175), "Escritorio Elevable Eléctrico", 340.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("6a7b8c9d-0e1f-2a3b-4c5d-6e7f8a9b0c1d"), "Switch administrable metálico para montaje en rack o pared", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3179), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3179), "Switch de Red 8 Puertos Gigabit", 48.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("7b8c9d0e-1f2a-3b4c-5d6e-7f8a9b0c1d2e"), "Alta cobertura y velocidad de transferencia optimizada para entornos IoT", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3183), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3183), "Router WiFi 6 de Triple Banda", 155.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("8c9d0e1f-2a3b-4c5d-6e7f-8a9b0c1d2e3f"), "Patrón cardioide con filtro antipop, óptimo para videollamadas y streaming", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3191), "Micrófono Condensador USB", 68.50m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("9d0e1f2a-3b4c-5d6e-7f8a-9b0c1d2e3f4a"), "Gabinete de pared para equipos de telecomunicación con puerta de vidrio templado", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3194), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3195), "Gabinete Porta Servidor Rack 6U", 110.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"), "Teclado con switches mecánicos silenciosos y distribución ISO", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3115), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3115), "Teclado Mecánico RGB", 89.99m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("c3d4e5f6-a7b8-9c0d-1e2f-3a4b5c6d7e8f"), "Mouse con sensor de alta precisión y batería recargable de larga duración", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3119), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3120), "Mouse Ergonómico Inalámbrico", 59.90m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"), "32GB RAM, 1TB SSD NVMe, procesador de última generación para desarrollo", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3125), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3125), "Laptop Pro 16\"", 1350.00m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("e5f6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"), "Adaptador de aluminio con puertos HDMI 4K, SD, MicroSD y USB 3.0", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3128), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3129), "Hub USB-C 8 en 1", 42.50m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("f6a7b8c9-d0e1-2f3a-4b5c-6d7e8f9a0b1c"), "Silla con soporte lumbar ajustable y reposabrazos 3D", true, new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3133), new DateTime(2026, 6, 2, 3, 35, 12, 858, DateTimeKind.Utc).AddTicks(3133), "Silla Ergonómica de Oficina", 210.00m, "SystemAdmin", "SystemAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("0a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4c5d"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("0e1f2a3b-4c5d-6e7f-8a9b-0c1d2e3f4a5b"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("1b2c3d4e-5f6a-7b8c-9d0e-1f2a3b4c5d6e"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("1f2a3b4c-5d6e-7f8a-9b0c-1d2e3f4a5b6c"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("2a3b4c5d-6e7f-8a9b-0c1d-2e3f4a5b6c7d"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("2c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("3a3b4c5d-6e7f-8a9b-0c1d-2e3f4a5b6c7e"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("3d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("4e5f6a7b-8c9d-0e1f-2a3b-4c5d6e7f8a9b"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("5f6a7b8c-9d0e-1f2a-3b4c-5d6e7f8a9b0c"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("6a7b8c9d-0e1f-2a3b-4c5d-6e7f8a9b0c1d"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("7b8c9d0e-1f2a-3b4c-5d6e-7f8a9b0c1d2e"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("8c9d0e1f-2a3b-4c5d-6e7f-8a9b0c1d2e3f"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("9d0e1f2a-3b4c-5d6e-7f8a-9b0c1d2e3f4a"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-9c0d-1e2f-3a4b5c6d7e8f"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-2f3a-4b5c-6d7e8f9a0b1c"));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"),
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2026, 6, 2, 2, 0, 20, 904, DateTimeKind.Utc).AddTicks(5589), new DateTime(2026, 6, 2, 2, 0, 20, 904, DateTimeKind.Utc).AddTicks(5590) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: new Guid("f4e3d2c1-b0a9-8f7e-6d5c-4b3a2a1f0e9d"),
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2026, 6, 2, 2, 0, 20, 904, DateTimeKind.Utc).AddTicks(5605), new DateTime(2026, 6, 2, 2, 0, 20, 904, DateTimeKind.Utc).AddTicks(5606) });
        }
    }
}
