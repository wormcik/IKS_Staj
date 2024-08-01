using Microsoft.AspNetCore.Mvc;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using SatinAlim.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;

namespace SatinAlim.Controllers
{
    [ApiController, Route("api/v1/satinAlim/[controller]/[action]")]
    public class SatinAlimController : ControllerBase
    {
        private readonly SatinAlimService satinAlimService;
        private readonly JwtTokenService jwtTokenService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SatinAlimController(SatinAlimService satinAlimService,JwtTokenService jwtTokenService,IHttpContextAccessor httpContextAccessor)
        {
            this.satinAlimService = satinAlimService;
            this.jwtTokenService = jwtTokenService;
            this.httpContextAccessor = httpContextAccessor;
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
        [ProducesResponseType(typeof(ProcessResult<List<TalepModelDTO>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<TalepModelDTO>>>> TalepEkle(TalepEkleSorguModel sorgu)
        {
            //var KullanıcıKod = jwtTokenService.GetUserGuid();
            //var KullanıcıKod = new Guid();
            var claims = User.Claims.ToList();


            var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var KullaniciKod_Value = jwtToken.Claims.FirstOrDefault(c => c.Type == "KullaniciKod");
                /*User.Claims.FirstOrDefault(c => c.Type == "role");*/
            var KullaniciKod = Guid.Parse(KullaniciKod_Value.Value);
            var result = await satinAlimService.TalepEkleAsync(sorgu,KullaniciKod);
            return Ok(result);
        }



        [HttpPost]
        [ProducesResponseType(typeof(ProcessResult<List<TalepModelDTO>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<List<TalepModelDTO>>>> TalepListele(TalepListeleSorguModel sorgu)
        {
            var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var KullaniciKod_Value = jwtToken.Claims.FirstOrDefault(c => c.Type == "KullaniciKod");
            var KullaniciKod = Guid.Parse(KullaniciKod_Value.Value);

            var result =await satinAlimService.TalepListeleAsync(KullaniciKod, sorgu);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProcessResult<TalepModelDTO>), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ProcessResult<TalepModelDTO>>> TalepGetir(long TalepKod)
        {

            var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var KullaniciKod_Value = jwtToken.Claims.FirstOrDefault(c => c.Type == "KullaniciKod");
            var KullaniciKod = Guid.Parse(KullaniciKod_Value.Value);

            var result = await satinAlimService.TalepGetirAsync(TalepKod,KullaniciKod);
            return Ok(result);
        }


        [HttpPut]
        [ProducesResponseType(typeof(ProcessResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<bool>>> TalepOnayla(long TalepKod)
        {
            var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var KullaniciKod_Value = jwtToken.Claims.FirstOrDefault(c => c.Type == "KullaniciKod");
            var KullaniciKod = Guid.Parse(KullaniciKod_Value.Value);

            var result = await satinAlimService.TalepOnaylaAsync(TalepKod,KullaniciKod);

            return Ok(result);
        }


        [HttpPut]
        [ProducesResponseType(typeof(ProcessResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcessResult<bool>>> TalepReddet(long TalepKod)
        {
            var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var KullaniciKod_Value = jwtToken.Claims.FirstOrDefault(c => c.Type == "KullaniciKod");
            var KullaniciKod = Guid.Parse(KullaniciKod_Value.Value);

            var result = await satinAlimService.TalepReddetAsync(TalepKod, KullaniciKod);

            return Ok(result);
        }
    }
}
