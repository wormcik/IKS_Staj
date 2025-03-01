﻿using System;
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
    public class UrunController : ControllerBase
    {
        private readonly UrunService UrunService;

        public UrunController(UrunService satinAlmaUrunService)
        {
            this.UrunService = satinAlmaUrunService;
        }

        [HttpPost]
        [CustomAuthorize("UrunEkle")]
        [ProducesResponseType(typeof(ProcessResult<UrunEkleModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<UrunEkleModelDTO>>> UrunEkle(UrunEkleSorguModel urun)
        {
            var result = await UrunService.UrunEkleAsync(urun);
            return Ok(result);
        }


        [HttpDelete]
        [CustomAuthorize("UrunSil")]
        [ProducesResponseType(typeof(ProcessResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<bool>>> UrunSil(int id)
        {
            var result = await UrunService.UrunSilAsync(id);
            return Ok(result);
        }


        [HttpGet]
        [CustomAuthorize("UrunGetir")]
        [ProducesResponseType(typeof(ProcessResult<UrunGetirModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<UrunGetirModelDTO>>> UrunGetir(int id)
        {
            var result = await UrunService.UrunGetirAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [CustomAuthorize("UrunListele")]
        [ProducesResponseType(typeof(ProcessResult<List<UrunListeleModelDTO>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<UrunListeleModelDTO>>>> UrunListele(UrunListeleSorguModel sorgu)
        {
            var result = await UrunService.UrunListeleAsync(sorgu);
            return Ok(result);
        }

        [HttpPut]
        [CustomAuthorize("UrunGuncelle")]
        [ProducesResponseType(typeof(ProcessResult<UrunGuncelleModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<UrunGuncelleModelDTO>>> UrunGuncelle(UrunGuncelleSorguModel urun)
        {
            var result = await UrunService.UrunGuncelleAsync(urun);
            return Ok(result);
        }



    }
}

