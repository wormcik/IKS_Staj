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

        public SatinAlimController(SatinAlimService satinAlimService)
        {
            this.satinAlimService = satinAlimService;
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
            var result = await satinAlimService.TalepEkleAsync(sorgu);
            return Ok(result);
        }

    }
}
