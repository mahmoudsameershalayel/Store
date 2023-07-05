using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.API.Infrastructure.Service.User;
using Store.Core.APIDto.User;
using Store.Core.APIViewModel.General;
using Store.Core.Constant;

namespace Store.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] CreateUserDto dto, string Password)
        {
            return Ok(await GetResponse(async () => new ApiResponseViewModel(await _userService.Register(dto, Password), true, MessagesKeys.success)));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginUserDto dto)
        {
            try
            {
                return Ok(await GetResponse(async () => new ApiResponseViewModel(await _userService.Login(dto), true, MessagesKeys.success)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
