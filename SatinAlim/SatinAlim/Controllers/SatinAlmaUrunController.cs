using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SatinAlim.Entities;
using SatinAlim.Models;
using SatinAlim.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SatinAlim.Controllers
{
    [ApiController, Route("api/v1/satinAlim/[controller]/[action]")]
    public class SatinAlmaUrunController : ControllerBase
    {
        private readonly SatinAlimUrunService satinAlmaUrunService;

        public SatinAlmaUrunController(SatinAlimUrunService satinAlmaUrunService)
        {
            this.satinAlmaUrunService = satinAlmaUrunService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UrunEkleModelDTO>> UrunEkle(UrunEkleSorguModel urun)
        {
            var result = await satinAlmaUrunService.UrunEkleAsync(urun);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UrunSil(int id)
        {
            var result = await satinAlmaUrunService.UrunSilAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UrunBulModelDTO>> UrunBul(int id)
        {
            var result = await satinAlmaUrunService.UrunBulAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<UrunListeleModelDTO>>> UrunListele(UrunListeleSorguModel sorgu)
        {
            var result = await satinAlmaUrunService.UrunListeleAsync(sorgu);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UrunGuncelleModelDTO>> UrunGuncelle(UrunGuncelleSorguModel urun)
        {
            var result = await satinAlmaUrunService.UrunGuncelleAsync(urun);
            return Ok(result);
        }



    }
}

