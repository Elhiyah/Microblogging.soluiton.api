using Microsoft.AspNetCore.Mvc;
using Microblogging.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;S
using System.Security.Claims;
using System.Text;

namespace Microblogging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly MicrobloggingContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AccountController(MicrobloggingContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Validar los datos de entrada
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verificar si el correo electrónico ya está registrado
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
                return BadRequest(new { message = "El correo electrónico ya está registrado." });

            // Crear un nuevo usuario
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = model.Username,
                Email = model.Email,
                Activo = true
            };

            // Hashear la contraseña
            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

            // Guardar el usuario en la base de datos
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registro exitoso." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Validar los datos de entrada
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Buscar el usuario por correo electrónico
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null)
                return Unauthorized(new { message = "Credenciales inválidas." });

            // Verificar la contraseña
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Credenciales inválidas." });

            // Generar el token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("tu_clave_secreta");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
            // Agrega más claims si es necesario
        }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = "tu_issuer",
                Audience = "tu_audience",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Devolver el token al cliente
            return Ok(new { Token = tokenString });
        }


    }
}
