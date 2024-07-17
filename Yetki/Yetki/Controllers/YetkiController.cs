using Microsoft.AspNetCore.Mvc;
using System.Net;
using Yetki.Helpers;
using Yetki.Models;
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
        [ProducesResponseType(typeof(ProcessResult<bool>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<bool>>> SignUp(RegistrationModel registrationModel)
        {
            var result = await yetkiService.SignUpAsync(registrationModel);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<string>>> SingIn(SignInModel signInModel)
        {
            var result = await yetkiService.SignInAsync(signInModel);
            return Ok(result);
        }


    }
}
