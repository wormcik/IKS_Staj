using Microsoft.AspNetCore.Mvc;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using SatinAlim.Services;
using System.Net;

namespace SatinAlim.Controllers
{
    [ApiController, Route("api/v1/satinAlim/[controller]/[action]")]
    public class SatinAlimController : ControllerBase
    {
        private readonly SatinAlimService satinAlimService;
        private readonly JwtTokenService jwtTokenService;

        public SatinAlimController(SatinAlimService satinAlimService,JwtTokenService jwtTokenService)
        {
            this.satinAlimService = satinAlimService;
            this.jwtTokenService = jwtTokenService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Test()
        {
            var result = await satinAlimService.TestAsync();
            return Ok(result);
        }

        [HttpPost]
        [CustomAuthorize("TalepEkle")]
        [ProducesResponseType(typeof(ProcessResult<TalepEkleModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<TalepEkleModelDTO>>> TalepEkle(TalepEkleSorguModel sorgu)
        {
            var KullanıcıKod = jwtTokenService.GetUserGuid();
            var result = await satinAlimService.TalepEkleAsync(sorgu,KullanıcıKod);
            return Ok(result);
        }

    }
}
