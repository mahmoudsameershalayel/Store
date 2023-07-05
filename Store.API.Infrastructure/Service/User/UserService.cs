using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Core.APIDto.User;
using Store.Data.DBEntities;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Infrastructure.Service.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper , IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> CreateToken(ApplicationUser user)
        {
            List<Claim> claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.UserName),
            };
            //Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));  

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<string> Login(LoginUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null)
            {
                throw new Exception("The user is not exist!!");
            }
            return await CreateToken(user);
        }

        public async Task<CreateUserDto> Register(CreateUserDto dto, string Password)
        {
            var user = _mapper.Map<ApplicationUser>(dto);
            await _userManager.CreateAsync(user, Password);
            await _userManager.AddToRoleAsync(user, "Customer");
            return dto;
        }
    }
}
