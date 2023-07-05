using Store.Core.APIDto.User;
using Store.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Infrastructure.Service.User
{
    public interface IUserService
    {
        public Task<CreateUserDto> Register(CreateUserDto dto , string Password);
        public Task<string> Login(LoginUserDto dto);
        public Task<string> CreateToken(ApplicationUser user);
    }
}
