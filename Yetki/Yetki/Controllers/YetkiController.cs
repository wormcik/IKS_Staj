using Microsoft.AspNetCore.Mvc;
using System.Net;
using Yetki.Services;

namespace Yetki.Controllers
{
    [ApiController, Route("api/v1/yetki/[controller]/[action]")]
    public class YetkiController : ControllerBase
    {
        private readonly YetkiService yetkiService;

        public YetkiController (YetkiService yetkiService)
        {
            this.yetkiService = yetkiService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> SignUp()
        {
            var result = yetkiService.SignUpAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async  Task<ActionResult<bool>> SingIn()
        {
            var result = yetkiService.SignInAsync();
            return Ok(result);
        }
       
    }
}
