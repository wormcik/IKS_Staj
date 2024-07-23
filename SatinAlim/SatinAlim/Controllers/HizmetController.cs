using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using SatinAlim.Services;
using SatinAlimHizmet.Services;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace SatinAlim.Controllers
{
    [ApiController, Route("api/v1/satinAlim/[controller]/[action]")]
    public class HizmetController : ControllerBase
    {

        private readonly HizmetService hizmetService;

        public HizmetController(HizmetService hizmetService)
        {
            this.hizmetService = hizmetService;
        }

        [HttpPost]
        [CustomAuthorize("HizmetEkle")]
        [ProducesResponseType(typeof(ProcessResult<HizmetEkleModelDTO>), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProcessResult<HizmetEkleModelDTO>>> HizmetEkle(HizmetEkleSorguModel hizmet)
        {
            var result = await hizmetService.HizmetEkleAsync(hizmet);
            return Ok(result);
        }

        [HttpGet]
        [CustomAuthorize("HizmetGetir")]
        [ProducesResponseType(typeof(ProcessResult<HizmetGetirModelDTO>), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProcessResult<HizmetGetirModelDTO>>> HizmetGetir(int id)
        {
            var result = await hizmetService.HizmetGetirAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [CustomAuthorize("HizmetListele")]
        [ProducesResponseType(typeof(ProcessResult<List<HizmetListeleModelDTO>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<HizmetListeleModelDTO>>>> HizmetListele(HizmetListeleSorguModel sorgu)
        {
            var result = await hizmetService.HizmetListeleAsync(sorgu);
            return Ok(result);
        }

        [HttpPut]
        [CustomAuthorize("HizmetGuncelle")]
        [ProducesResponseType(typeof(ProcessResult<HizmetGuncelleModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<HizmetGuncelleModelDTO>>> HizmetGuncelle(HizmetGuncelleSorguModel urun)
        {
            var result = await hizmetService.HizmetGuncelleAsync(urun);
            return Ok(result);
        }

        [HttpDelete]
        [CustomAuthorize("HizmetSil")]
        [ProducesResponseType(typeof(ProcessResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<bool>>> HizmetSil(int id)
        {
            var result = await hizmetService.HizmetSilAsync(id);
            return Ok(result);
        }


    }
}
