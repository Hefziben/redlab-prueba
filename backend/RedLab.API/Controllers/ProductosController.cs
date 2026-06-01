using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedLab.API.Data;
using RedLab.API.Entities;
using RedLab.API.Models;
using RedLab.API.Services;
using System.Security.Claims;

namespace RedLab.API.Controllers
{
    [Authorize] // 🔒 Protege todos los endpoints con JWT
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ReporteService _reporteService; // Añadir referencia

        public ProductosController(ApplicationDbContext context,ReporteService reporteService)
        {
            _context = context;
            _reporteService = reporteService;
        }

        // 🔍 GET: api/productos (Con Paginación, Filtros por nombre y estado)
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos(
            [FromQuery] string? nombre, 
            [FromQuery] bool? estado, 
            [FromQuery] int pagina = 1, 
            [FromQuery] int tamanoPagina = 10)
        {
            var query = _context.Productos.AsQueryable();

            // Aplicar Filtros si vienen en la URL
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            if (estado.HasValue)
            {
                query = query.Where(p => p.Estado == estado.Value);
            }

            // Calcular paginación eficiente
            var totalRegistros = await query.CountAsync();
            var productos = await query
                .OrderByDescending(p => p.FechaCreacion)
                .Skip((pagina - 1) * tamanoPagina)
                .Take(tamanoPagina)
                .ToListAsync();

            return Ok(new
            {
                totalRegistros,
                paginaActual = pagina,
                tamanoPagina,
                totalPaginas = (int)Math.Ceiling((double)totalRegistros / tamanoPagina),
                datos = productos
            });
        }

        // 🎯 GET: api/productos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(Guid id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound(new { message = "Producto no encontrado." });

            return Ok(producto);
        }

        // ➕ POST: api/productos
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProductoModel model)
        {
            // Extraer de forma automática el ID del usuario del Token JWT
            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "System";

            var producto = new Producto
            {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Precio = model.Precio,
                Estado = model.Estado,
                UsuarioCreacion = usuarioId,
                FechaCreacion = DateTime.UtcNow
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
        }

        // 📝 PUT: api/productos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] EditarProductoModel model)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound(new { message = "Producto no encontrado." });

            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "System";

            // Mapear cambios
            producto.Nombre = model.Nombre;
            producto.Descripcion = model.Descripcion;
            producto.Precio = model.Precio;
            producto.Estado = model.Estado;
            
            // Campos de auditoría de modificación
            producto.UsuarioModificacion = usuarioId;
            producto.FechaModificacion = DateTime.UtcNow;

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Producto actualizado con éxito.", producto });
        }

        // ❌ DELETE: api/productos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound(new { message = "Producto no encontrado." });

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Producto eliminado físicamente con éxito." });
        }

        [HttpGet("reporte")]
        public async Task<IActionResult> DescargarReporte()
        {
            // Traemos todos los productos ordenados de la base de datos
            var productos = await _context.Productos
                .OrderBy(p => p.Nombre)
                .ToListAsync();

            // Llamamos a nuestro generador fluido de QuestPDF
            byte[] pdfBytes = _reporteService.GenerarReporteProductosPdf(productos);

            string nombreArchivo = $"Reporte_Productos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            // Retornamos el archivo binario directamente al navegador
            return File(pdfBytes, "application/pdf", nombreArchivo);
        }
    }
}