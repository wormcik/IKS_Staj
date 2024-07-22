using Microsoft.AspNetCore.Mvc;
using SatinAlim.Entities;
using SatinAlim.Services;
using SatinAlimHizmet.Services;
using System.Net;

namespace SatinAlim.Controllers
{
    public class SatinAlimHizmetController : ControllerBase
    {
        private readonly SatinAlimHizmetService satinAlimService;
        
        public SatinAlimHizmetController(SatinAlimHizmetService satinAlimService)
        {
            this.satinAlimService = satinAlimService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Test()
        {
            // var result = await satinAlimService.TestAsync();
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(SatinAlmaTalepHizmet),(int)HttpStatusCode.Created)]
        public async  Task<ActionResult<SatinAlmaTalepHizmet>> Create([FromBody] SatinAlmaTalepHizmet entity)
        {
            var createdEntity = await satinAlimService.CreateSatinAlmaTalepHizmetAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.SatinAlmaHizmetKod }, createdEntity);
            
        }



        [HttpGet]
        [ProducesResponseType(typeof(SatinAlmaTalepHizmet),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<SatinAlmaTalepHizmet>> GetById(int id)
        {
            var entity = await satinAlimService.GetSatinAlmaTalepHizmetAsync(id);

            if(entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await satinAlimService.DeleteSatinAlmaTalepHizmetAsync(id);

            if(!result)
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpPut()]
        [ProducesResponseType(typeof(SatinAlmaTalepHizmet),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<SatinAlmaTalepHizmet>> Update([FromBody] SatinAlmaTalepHizmet entity,int id)
        {
            if(id != entity.SatinAlmaHizmetKod)
            {
                return BadRequest("ID mismathc");
            }

            var updatedEntity = await satinAlimService.UpdateSatinAlmaTalepHizmetAsync(entity,id);

            if(updatedEntity == null)
            {
                return NotFound();
            }

            return Ok(updatedEntity);
        }

    }
}
