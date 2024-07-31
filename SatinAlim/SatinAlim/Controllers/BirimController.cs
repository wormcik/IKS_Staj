using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using SatinAlim.Services;
using SatinAlim.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SatinAlim.Controllers
{
    [ApiController, Route("api/v1/satinAlim/[controller]/[action]")]
    public class BirimController : ControllerBase
    {
        // GET: /<controller>/
        private readonly BirimService birimService;

        public BirimController(BirimService birimService)
        { 
            this.birimService = birimService;
        }

        
        [HttpPost]
        [CustomAuthorize("BirimEkle")]
        public async Task<ActionResult<ProcessResult<BirimEkleModelDTO>>> BirimEkle(BirimEkleSorguModel sorgu)
        {
            var result = await birimService.BirimEkleAsync(sorgu);
            return Ok(result);
        }


        [HttpDelete]
        [CustomAuthorize("BirimSil")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> BirimSil(int BirimKod)
        {
            var result = await birimService.BirimSilAsync(BirimKod);
            return Ok(result);
        }


        [HttpGet]
        [CustomAuthorize("BirimGetir")]
        [ProducesResponseType(typeof(ProcessResult<BirimGetirModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<BirimGetirModelDTO>>> BirimGetir(int BirimKod)
        {
            var result = await birimService.BirimGetirAsync(BirimKod);
            return Ok(result);
        }


        [HttpPut]
        [CustomAuthorize("BirimGuncelle")]
        [ProducesResponseType(typeof(ProcessResult<BirimGuncelleModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<BirimGuncelleModelDTO>>> BirimGuncelle(BirimGuncelleSorguModel sorgu)
        {
            var result = await birimService.BirimGuncelleAsync(sorgu);
            return Ok(result);
        }


        [HttpPost]
        /*[CustomAuthorize("BirimListele")]*/
        [ProducesResponseType(typeof(ProcessResult<List<BirimListeleModelDTO>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<BirimListeleModelDTO>>>> BirimListele(BirimListeleSorguModel sorgu)
        {
            var result = await birimService.BirimListeleAsync(sorgu);
            return Ok(result);
        }
    }
}

