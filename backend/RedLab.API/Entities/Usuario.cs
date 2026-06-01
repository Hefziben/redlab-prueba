using System;
using System.ComponentModel.DataAnnotations;

namespace RedLab.API.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Nombre { get; set; } = string.Empty;
    }
}