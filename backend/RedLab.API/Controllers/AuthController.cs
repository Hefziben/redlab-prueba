using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RedLab.API.Data;
using RedLab.API.Entities;
using RedLab.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RedLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<Usuario> _passwordHasher;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<Usuario>();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registrar([FromBody] RegistroModel model)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == model.Email))
                return BadRequest(new { message = "El correo electrónico ya está registrado." });

            var usuario = new Usuario
            {
                Nombre = model.Nombre,
                Email = model.Email
            };

            usuario.PasswordHash = _passwordHasher.HashPassword(usuario, model.Password);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuario registrado exitosamente." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (usuario == null)
                return Unauthorized(new { message = "Credenciales incorrectas." });

            var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, model.Password);
            if (resultado == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Credenciales incorrectas." });

            var token = GenerarJwtToken(usuario);

            return Ok(new { 
                token, 
                usuario = new { usuario.Id, usuario.Nombre, usuario.Email } 
            });
        }

        private string GenerarJwtToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Name, usuario.Nombre)
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}