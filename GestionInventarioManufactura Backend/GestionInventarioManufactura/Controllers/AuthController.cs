using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GestionInventarioManufactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            return Ok(result);
        }
       
    }
}
