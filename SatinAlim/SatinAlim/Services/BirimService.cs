using System;
using Microsoft.EntityFrameworkCore;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;

namespace SatinAlim.Services
{
	public class BirimService
	{
        readonly SatinAlimDbContext satinAlimDbContext;
        IConfiguration configuration;
        public BirimService(SatinAlimDbContext satinAlimDbContext, IConfiguration configuration)
        {

            this.configuration = configuration;
            this.satinAlimDbContext = satinAlimDbContext;
        }
        public async Task<bool> TestAsync()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<ProcessResult<BirimEkleModelDTO>> BirimEkleAsync(BirimEkleSorguModel birim)
        {
            try
            {
                var objBirim = await satinAlimDbContext.SatinAlmaBirim.FirstOrDefaultAsync(x => x.BirimAd == birim.BirimAd);
                
                if(objBirim != null)
                {
                    return new ProcessResult<BirimEkleModelDTO>().Failed("Birim adı baska bir birime ait.");
                }
                SatinAlmaBirim eklenenBirim = new SatinAlmaBirim();
                eklenenBirim.BirimAd = birim.BirimAd;
                eklenenBirim.OnaySayi = birim.OnaySayi;
                await satinAlimDbContext.SatinAlmaBirim.AddAsync(eklenenBirim);
                await satinAlimDbContext.SaveChangesAsync();
                BirimEkleModelDTO yeniBirim = new BirimEkleModelDTO();
                yeniBirim.BirimAd = birim.BirimAd;
                yeniBirim.OnaySayi = birim.OnaySayi;
                return new ProcessResult<BirimEkleModelDTO>().Successful(yeniBirim);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<ProcessResult<BirimGetirModelDTO>> BirimGetirAsync(int birimKod)
        {
            try
            {
                var objBirim = await satinAlimDbContext.SatinAlmaBirim.FirstOrDefaultAsync(x => x.SatinAlmaBirimKod == birimKod);
                if (objBirim == null)
                {
                    return new ProcessResult<BirimGetirModelDTO>().Failed("Birim bulunamadı");
                }
                BirimGetirModelDTO birim = new BirimGetirModelDTO();
                birim.BirimAd = objBirim.BirimAd;
                birim.OnaySayi = objBirim.OnaySayi;
                birim.SatinAlmaBirimKod = objBirim.SatinAlmaBirimKod;
                return new ProcessResult<BirimGetirModelDTO>().Successful(birim);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<ProcessResult<BirimGuncelleModelDTO>> BirimGuncelleAsync(BirimGuncelleSorguModel sorgu)
        {
            try
            {
                var objBirim = await satinAlimDbContext.SatinAlmaBirim.FirstOrDefaultAsync(x => x.SatinAlmaBirimKod == sorgu.SatinAlmaBirimKod);
                if(objBirim == null)
                {
                    return new ProcessResult<BirimGuncelleModelDTO>().Failed("Birim bulunamadı");
                }
                objBirim.BirimAd = sorgu.BirimAd;
                objBirim.OnaySayi = sorgu.OnaySayi;

                satinAlimDbContext.Update(objBirim);
                await satinAlimDbContext.SaveChangesAsync();

                BirimGuncelleModelDTO yeniBirim = new BirimGuncelleModelDTO();
                yeniBirim.BirimAd = objBirim.BirimAd;
                yeniBirim.OnaySayi = objBirim.OnaySayi;

                return new ProcessResult<BirimGuncelleModelDTO>().Successful(yeniBirim);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task<ProcessResult<bool>> BirimSilAsync(int birimKod)
        {
            try
            {
                var objBirim = await satinAlimDbContext.SatinAlmaBirim.FirstOrDefaultAsync(x => x.SatinAlmaBirimKod == birimKod);
                if (objBirim == null)
                {
                    return new ProcessResult<bool>().Failed("Birim bulunamadı");
                }
                satinAlimDbContext.SatinAlmaBirim.Remove(objBirim);
                await satinAlimDbContext.SaveChangesAsync();
                return new ProcessResult<bool>().Successful();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<ProcessResult<List<BirimListeleModelDTO>>> BirimListeleAsync(BirimListeleSorguModel sorgu)
        {
            try
            {
                var BirimList = await satinAlimDbContext.SatinAlmaBirim.Where(x =>
                (x.BirimAd == sorgu.BirimAd || string.IsNullOrEmpty(sorgu.BirimAd)) &&
                ((x.OnaySayi >= sorgu.OnaySayi) || (sorgu.OnaySayi == null))).ToListAsync();

                var BirimDTOList = new List<BirimListeleModelDTO>();
                if(BirimList == null)
                {
                    return new ProcessResult<List<BirimListeleModelDTO>>().Failed("Birim bulunamadı.");
                }
                foreach(var Birim in BirimList)
                {
                    var BirimDTO = new BirimListeleModelDTO();
                    BirimDTO.BirimAd = Birim.BirimAd;
                    BirimDTO.OnaySayi = Birim.OnaySayi;
                    BirimDTO.SatinAlmaBirimKod = Birim.SatinAlmaBirimKod;
                    BirimDTOList.Add(BirimDTO);
                }
                return new ProcessResult<List<BirimListeleModelDTO>>().Successful(BirimDTOList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

