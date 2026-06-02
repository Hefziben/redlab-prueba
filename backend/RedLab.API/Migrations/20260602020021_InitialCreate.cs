using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RedLab.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "Nombre", "Precio", "UsuarioCreacion", "UsuarioModificacion" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"), "Laptop de alta gama para desarrollo de software", true, new DateTime(2026, 6, 2, 2, 0, 20, 904, DateTimeKind.Utc).AddTicks(5589), new DateTime(2026, 6, 2, 2, 0, 20, 904, DateTimeKind.Utc).AddTicks(5590), "Laptop Pro 15 pulgadas", 1299.99m, "SystemAdmin", "SystemAdmin" },
                    { new Guid("f4e3d2c1-b0a9-8f7e-6d5c-4b3a2a1f0e9d"), "Monitor curvo ideal para multitasking", true, new DateTime(2026, 6, 2, 2, 0, 20, 904, DateTimeKind.Utc).AddTicks(5605), new DateTime(2026, 6, 2, 2, 0, 20, 904, DateTimeKind.Utc).AddTicks(5606), "Monitor UltraWide 34\"", 450.50m, "SystemAdmin", "SystemAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
