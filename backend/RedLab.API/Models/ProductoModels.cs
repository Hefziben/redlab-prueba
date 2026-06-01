using System.ComponentModel.DataAnnotations;

namespace RedLab.API.Models
{
    public class CrearProductoModel
    {
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }

        [Required]
        public bool Estado { get; set; } = true;
    }

    public class EditarProductoModel
    {
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}