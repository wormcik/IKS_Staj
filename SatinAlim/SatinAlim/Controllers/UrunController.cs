using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SatinAlim.Controllers
{
    [ApiController, Route("api/v1/satinAlim/[controller]/[action]")]

    public class SatinAlmaUrunController : ControllerBase
    {
        private readonly UrunService satinAlmaUrunService;

        public SatinAlmaUrunController(UrunService satinAlmaUrunService)
        {
            this.satinAlmaUrunService = satinAlmaUrunService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<UrunEkleModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<UrunEkleModelDTO>>> UrunEkle(UrunEkleSorguModel urun)
        {
            var result = await satinAlmaUrunService.UrunEkleAsync(urun);
            return Ok(result);
        }


        [HttpDelete]
        [ProducesResponseType(typeof(ProcessResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<bool>>> UrunSil(int id)
        {
            var result = await satinAlmaUrunService.UrunSilAsync(id);
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(typeof(ProcessResult<UrunGetirModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<UrunGetirModelDTO>>> UrunGetir(int id)
        {
            var result = await satinAlmaUrunService.UrunGetirAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<List<UrunListeleModelDTO>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<UrunListeleModelDTO>>>> UrunListele(UrunListeleSorguModel sorgu)
        {
            var result = await satinAlmaUrunService.UrunListeleAsync(sorgu);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProcessResult<UrunGuncelleModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<UrunGuncelleModelDTO>>> UrunGuncelle(UrunGuncelleSorguModel urun)
        {
            var result = await satinAlmaUrunService.UrunGuncelleAsync(urun);
            return Ok(result);
        }



    }
}

