using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.Application.Services;
using MiTienda.DataAccess.Contexts;
using MiTienda.Domain.Contracts;
using MiTienda.Domain.Entities;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signIn;
        private readonly MiTiendaContexto _contexto;
        private IRepository<Vendedor> _vendedorRepo;
        private IManagePuntoDeVentaService _managePuntoVentaService;
        IQueryService<PuntoDeVenta> _PVQuery;

        public AccountsController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signIn, MiTiendaContexto contexto, IRepository<Vendedor> vendedorRepo, IQueryService<PuntoDeVenta> lineaQuery)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signIn = signIn;
            _contexto = contexto;
            _vendedorRepo = vendedorRepo;
            _PVQuery = lineaQuery;
          
        }



        [HttpPost("create")]
        public async Task<ActionResult<UserWithTokenDTO>> Create([FromBody] UserCredentialsDTO credentials)
        {
            // Crear el usuario en Identity
            var usuario = new IdentityUser { UserName = credentials.Email, Email = credentials.Email };
            var result = await _userManager.CreateAsync(usuario, credentials.Password);

            if (result.Succeeded)
            {
                var proveedor = new Vendedor();
                proveedor.userID = usuario.Id;
                proveedor.Nombre = credentials.Nombre;
                proveedor.Apellido = credentials.Apellido;
                proveedor.Legajo = credentials.Legajo;
                proveedor.PuntoDeVenta = _PVQuery.GetBy(p => p.Numero == credentials.SucursalId).FirstOrDefault();
                proveedor.State = true;


                // Agregar el vendedor a la base de datos
                _vendedorRepo.AddObject(proveedor);

                var token = await CreateToken(credentials);
                // Generar y devolver el token
                return Ok(new UserWithTokenDTO
                {
                    Token = token.Token,
                    Expiracion = token.Expiracion,
                    Nombre = proveedor.Nombre,
                    Apellido = proveedor.Apellido,
                    Legajo = proveedor.Legajo,
                    SucursalId = proveedor.PuntoDeVenta.Numero,
                    UserID = proveedor.userID
                });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserWithTokenDTO>> Login([FromBody] UserLoginDTO EmailAndPassword)
        {
            UserCredentialsDTO credentials = new UserCredentialsDTO
            {
                Email = EmailAndPassword.Email,
                Password = EmailAndPassword.Password
            };
            // Intento de iniciar sesión
            var result = await _signIn.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Creación del token
                var token = await CreateToken(credentials);

                // Obtención de información del usuario
                var user = await UserByEmail(credentials.Email);
                if (user?.Value == null)
                {
                    return BadRequest("Email o Password incorrecto.");
                }

                // Obtención de información adicional
                var Proveedor = _vendedorRepo
                    .GetBy(x => x.userID == user.Value.Id).AsQueryable()
                    .Include(x => x.PuntoDeVenta)
                    .ThenInclude(x => x.Sucursal)
                    .SingleOrDefault();

                if (Proveedor == null)
                {
                    return BadRequest("Vendedor no asociado al usuario.");
                }

                // Construcción de la respuesta
                return Ok(new UserLogged
                {
                    Token = token.Token,
                    Expiracion = token.Expiracion,
                    Apellido = Proveedor.Apellido,
                    Sucursal = Proveedor.PuntoDeVenta.Sucursal.Numero,
                    NombreSucursal = Proveedor.PuntoDeVenta.Sucursal.Nombre,
                    Legajo = Proveedor.Legajo,
                    Nombre = Proveedor.Nombre
                });
            }

            return BadRequest("Email o Password incorrecto.");
        }


        [HttpGet("listadoUsuarios")]
        public async Task<ActionResult<List<UserDTO>>> UsersList()
        {
            var usersList = _contexto.Users.AsQueryable().Select(user =>
            new UserDTO()
            {
                Id = user.Id,
                Role = _contexto.UserClaims.AsQueryable().Where(claim => claim.UserId == user.Id).Select(claim => claim.ClaimValue).SingleOrDefault(),
                Email = user.Email
            }).ToList();

            return usersList;
        }

        [HttpGet("user/{email}")]
        public async Task<ActionResult<UserDTO>> UserByEmail(string email)
        {
            var user = _contexto.Users.AsQueryable().Select(user => new UserDTO()
            {
                Id = user.Id,
                Role = _contexto.UserClaims.AsQueryable().Where(claim => claim.UserId == user.Id).Select(claim => claim.ClaimValue).SingleOrDefault(),
                Email = user.Email
            }).Where(user => user.Email == email).SingleOrDefault();

            return user;
        }


        private async Task<AuthenticationResponseDTO> CreateToken(UserCredentialsDTO credentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email",credentials.Email)
            };

            var user = await _userManager.FindByEmailAsync(credentials.Email);
            var claimsDB = await _userManager.GetClaimsAsync(user);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["llaveJWT"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            DateTime? expiration = DateTime.Now.AddMinutes(182);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: creds);



            return new AuthenticationResponseDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiration?.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }


    }
}
