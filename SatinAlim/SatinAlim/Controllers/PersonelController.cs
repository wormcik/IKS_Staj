using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using SatinAlim.Services;
// using SatinAlimHizmet.Services;
using System.Net;

namespace SatinAlim.Controllers
{

    [ApiController, Route("api/v1/satinAlim/[controller]/[action]")]
    public class PersonelController : ControllerBase
    {
        private readonly PersonelService personelService;

        public PersonelController(PersonelService personelService )
        {
            this.personelService = personelService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<PersonelEkleModelDTO>),(int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProcessResult<PersonelEkleModelDTO>>> PersonelEkle(PersonelEkleSorguModel personel)
        {
                var result = await personelService.PersonelEkleAsync(personel);
                return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProcessResult<PersonelGetirModelDTO>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<PersonelGetirModelDTO>>> PersonelGetir(int id)
        {
                var result = await personelService.PersonelGetirAsync(id);
                return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<List<PersonelListeleModelDTO>>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<PersonelListeleModelDTO>>>> PersonelListele(PersonelListeleSorguModel  sorgu)
        {
                var result = await personelService.PersonelListeleAsync(sorgu);
                return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProcessResult<PersonelGuncelleModelDTO>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<PersonelGuncelleModelDTO>>> PersonelGuncelle(PersonelGuncelleSorguModel sorgu)
        {
                var result =  await personelService.PersonelGuncelleAsync(sorgu);
                return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ProcessResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<bool>>> PersonelSil(int id)
        {
                var result = await personelService.PersonelSilAsync(id);
                return Ok(result);
        }

        
    }
}
