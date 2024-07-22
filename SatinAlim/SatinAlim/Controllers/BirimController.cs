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

        
        [HttpPost,AuthorizationController("admin", "manager")]
        [ProducesResponseType(typeof(ProcessResult<BirimEkleModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<BirimEkleModelDTO>>> BirimEkle(BirimEkleSorguModel sorgu)
        {
            var result = await birimService.BirimEkleAsync(sorgu);
            return Ok(result);
        }


        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> BirimSil(int BirimKod)
        {
            var result = await birimService.BirimSilAsync(BirimKod);
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(typeof(ProcessResult<BirimGetirModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<BirimGetirModelDTO>>> BirimGetir(int BirimKod)
        {
            var result = await birimService.BirimGetirAsync(BirimKod);
            return Ok(result);
        }


        [HttpPut]
        [ProducesResponseType(typeof(ProcessResult<BirimGuncelleSorguModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<BirimGuncelleSorguModel>>> BirimGuncelle(BirimGuncelleSorguModel sorgu)
        {
            var result = await birimService.BirimGuncelleAsync(sorgu);
            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<List<BirimListeleModelDTO>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<BirimListeleModelDTO>>>> BirimListele(BirimListeleSorguModel sorgu)
        {
            var result = await birimService.BirimListeleAsync(sorgu);
            return Ok(result);
        }
    }
}

