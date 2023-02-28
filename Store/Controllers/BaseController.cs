using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core.APIViewModel.General;

namespace Store.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected async Task<IActionResult> GetResponse(Func<Task<ApiResponseViewModel>> func)
        {  
            return Ok(await func());
        }
     

    }
}
