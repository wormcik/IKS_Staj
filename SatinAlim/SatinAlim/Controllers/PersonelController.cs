using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using SatinAlim.Services;
using System.IdentityModel.Tokens.Jwt;
// using SatinAlimHizmet.Services;
using System.Net;

namespace SatinAlim.Controllers
{

    [ApiController, Route("api/v1/satinAlim/[controller]/[action]")]
    public class PersonelController : ControllerBase
    {
        private readonly PersonelService personelService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PersonelController(PersonelService personelService, IHttpContextAccessor httpContextAccessor)
        {
            this.personelService = personelService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        /*[CustomAuthorize("PersonelEkle")]*/
        [ProducesResponseType(typeof(ProcessResult<PersonelEkleModelDTO>),(int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProcessResult<PersonelEkleModelDTO>>> PersonelEkle(PersonelEkleSorguModel personel)
        {
                var result = await personelService.PersonelEkleAsync(personel);
                return Ok(result);
        }

        [HttpGet]
        [CustomAuthorize("PersonelGetir")]
        [ProducesResponseType(typeof(ProcessResult<PersonelGetirModelDTO>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<PersonelGetirModelDTO>>> PersonelGetir(int id)
        {
                var result = await personelService.PersonelGetirAsync(id);
                return Ok(result);
        }



        [HttpGet]
        [ProducesResponseType(typeof(ProcessResult<PersonelGetirModelDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<PersonelGetirModelDTO>>> UserPersonelGetir()
        {

            var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var KullaniciKod_Value = jwtToken.Claims.FirstOrDefault(c => c.Type == "KullaniciKod");
            /*User.Claims.FirstOrDefault(c => c.Type == "role");*/
            var KullaniciKod = Guid.Parse(KullaniciKod_Value.Value);

            var result = await personelService.UserPersonelGetirAsync(KullaniciKod);
            return Ok(result);
        }



        [HttpPost]
        [CustomAuthorize("PersonelListele")]
        [ProducesResponseType(typeof(ProcessResult<List<PersonelListeleModelDTO>>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<PersonelListeleModelDTO>>>> PersonelListele(PersonelListeleSorguModel  sorgu)
        {
                var result = await personelService.PersonelListeleAsync(sorgu);
                return Ok(result);
        }

        [HttpPut]
        [CustomAuthorize("PersonelGuncelle")]
        [ProducesResponseType(typeof(ProcessResult<PersonelGuncelleModelDTO>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<PersonelGuncelleModelDTO>>> PersonelGuncelle(PersonelGuncelleSorguModel sorgu)
        {
                var result =  await personelService.PersonelGuncelleAsync(sorgu);
                return Ok(result);
        }

        [HttpDelete]
        [CustomAuthorize("PersonelSil")]
        [ProducesResponseType(typeof(ProcessResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<bool>>> PersonelSil(int id)
        {
                var result = await personelService.PersonelSilAsync(id);
                return Ok(result);
        }

        
    }
}
