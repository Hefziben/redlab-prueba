using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedLab.API.Entities
{
    public class Producto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); // Id (guid, clave primaria) 

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty; // Nombre (string, requerido) 

        public string? Descripcion { get; set; } // Descripción (string, opcional) 

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; } // Precio (decimal, requerido) 

        [Required]
        public bool Estado { get; set; } = true; // Estado (bool, requerido) 

        [Required]
        public string UsuarioCreacion { get; set; } = string.Empty; // UsuarioCreacion (string o guid) 

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow; // FechaCreacion (DateTime) 

        public string? UsuarioModificacion { get; set; } // Usuario Modificacion (string o guid) 

        public DateTime? FechaModificacion { get; set; } // Fecha Modificacion (DateTime) 
    }
}