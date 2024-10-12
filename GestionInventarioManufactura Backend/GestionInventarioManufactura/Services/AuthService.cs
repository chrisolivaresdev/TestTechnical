using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Interfaces;
using GestionInventarioManufactura.Models;
using GestionInventarioManufactura.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static GestionInventarioManufactura.Utils.Validations;

namespace GestionInventarioManufactura.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthService(IConfiguration configuration, IAuthRepository authRepository, IPasswordHasher<User> passwordHasher, IUserRepository userRepository)
        {
            _configuration = configuration;
            _authRepository = authRepository;
            _passwordHasher= passwordHasher;
            _userRepository = userRepository;
        }

    

        public async Task<AuthReponse> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _authRepository.FindUserByEmail(loginDto.Email);
                if (user == null || !await ValidatePassword(user, loginDto.Password))
                {
                    throw new UnauthorizedAccessException("Invalid Credentials");
                }

                var token = generateJWT(user);

                return new AuthReponse
                {
                    Token = token,
                    isSuccess = true
                };
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public async Task<ApiResponse> Register(RegisterDto registerDto)
        {
            try
            {
                if (!EmailValidator.IsValidEmail(registerDto.Email))
                {
                    throw new UnauthorizedAccessException("El correo electrónico no es válido.");
                }

                var userExist = await _authRepository.FindUserByEmail(registerDto.Email);

                if (userExist != null)
                {
                    return new ApiResponse
                    {
                        isSuccess = false,
                        msj = "User already exists"
                    };
                }

                var newUser = new User
                {
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    Password = _passwordHasher.HashPassword(null, registerDto.Password),
                };


                await _userRepository.Add(newUser);


              return new ApiResponse
                {
                    isSuccess = true,
                    msj = $"Product {newUser.Name} updated successfully"
                };
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        public Task<bool> ValidatePassword(User user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return Task.FromResult(result == PasswordVerificationResult.Success);
        }
   
        private string generateJWT(User user)
        {
            //crear la informacion del usuario para el token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //crear detalle del token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }

}

