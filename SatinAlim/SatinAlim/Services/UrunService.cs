using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;

namespace SatinAlim.Services
{
	public class UrunService
	{
        private readonly IConfiguration configuration;
        private readonly SatinAlimDbContext satinAlimDbContext;

        public UrunService(SatinAlimDbContext satinAlimDbContext, IConfiguration configuration)
        {

            this.configuration = configuration;
            this.satinAlimDbContext = satinAlimDbContext;
        }


        public async Task<ProcessResult<UrunEkleModelDTO>> UrunEkleAsync(UrunEkleSorguModel urun)
        {
            try
            {
                var objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.Tanim == urun.Tanim);
                if(objUrun != null)
                {
                    return new ProcessResult<UrunEkleModelDTO>().Failed("Ürün tanımı baska bir ürüne ait.");
                }

                var yeni_urun = new SatinAlmaUrun();
                yeni_urun.Tanim = urun.Tanim;
                yeni_urun.Aciklama = urun.Aciklama;
                yeni_urun.Birim = urun.Birim.ToUpper();
                satinAlimDbContext.SatinAlmaUrun.Add(yeni_urun);
                await satinAlimDbContext.SaveChangesAsync();

                var result = new UrunEkleModelDTO();
                result.Tanim = yeni_urun.Tanim;
                result.Aciklama = yeni_urun.Aciklama;
                result.Birim = yeni_urun.Birim;
                
                return new ProcessResult<UrunEkleModelDTO>().Successful(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ProcessResult<bool>> UrunSilAsync(int urunKod)
        {
            try
            {
                var objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.SatinAlmaUrunKod == urunKod);
                if(objUrun == null)
                {
                    return new ProcessResult<bool>().Failed("Ürün bulunamadı");
                }
                satinAlimDbContext.SatinAlmaUrun.Remove(objUrun);
                await satinAlimDbContext.SaveChangesAsync();
                return new ProcessResult<bool>().Successful();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ProcessResult<UrunGetirModelDTO>> UrunGetirAsync(int urunKod)
        {
            try
            {
                var objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.SatinAlmaUrunKod == urunKod);
                if (objUrun == null)
                {
                    return new ProcessResult<UrunGetirModelDTO>().Failed("Ürün bulunamadı");
                }
                UrunGetirModelDTO urun = new UrunGetirModelDTO();
                urun.SatinAlmaUrunKod = objUrun.SatinAlmaUrunKod;
                urun.Tanim = objUrun.Tanim;
                urun.Birim = objUrun.Birim;
                urun.Aciklama = objUrun.Aciklama;
                return new ProcessResult<UrunGetirModelDTO>().Successful(urun);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcessResult<List<UrunListeleModelDTO>>> UrunListeleAsync(UrunListeleSorguModel sorgu)
        {
            try
            {
                var urunList = await satinAlimDbContext.SatinAlmaUrun.Where(
                    x => (x.Birim == sorgu.Birim.ToUpper() || String.IsNullOrEmpty(sorgu.Birim)) &&
                    x.Aciklama.ToUpper().Contains(sorgu.Aciklama.ToUpper()) &&
                    (x.Tanim.ToUpper() == sorgu.Tanim.ToUpper() || String.IsNullOrEmpty(sorgu.Tanim))
                    ).ToListAsync();
                
                if(urunList == null)
                {
                    return new ProcessResult<List<UrunListeleModelDTO>>().Failed("Urun bulunamadı");
                }
                var result = new List<UrunListeleModelDTO>();
                
                foreach (var urun in urunList)
                {
                    var temp = new UrunListeleModelDTO();
                    temp.Aciklama = urun.Aciklama;
                    temp.Birim = urun.Birim;
                    temp.SatinAlmaUrunKod = urun.SatinAlmaUrunKod;
                    temp.Tanim = urun.Tanim;
                    result.Add(temp);
                }
                return new ProcessResult<List<UrunListeleModelDTO>>().Successful(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



        public async Task<ProcessResult<UrunGuncelleModelDTO>> UrunGuncelleAsync(UrunGuncelleSorguModel urun)
        {
            try
            {
                var objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.SatinAlmaUrunKod == urun.SatinAlmaUrunKod);
                if (objUrun == null)
                {
                    return new ProcessResult<UrunGuncelleModelDTO>().Failed("Urun bulunamadı");
                }
                objUrun.Birim = urun.Birim.ToUpper();
                objUrun.Aciklama = urun.Aciklama;
                objUrun.Tanim = urun.Tanim;
                //satinAlimDbContext.Entry(objUrun).State = EntityState.Modified;
                satinAlimDbContext.Update(objUrun);
                await satinAlimDbContext.SaveChangesAsync();

                var result = new UrunGuncelleModelDTO();
                result.Aciklama = objUrun.Aciklama;
                result.Birim = objUrun.Birim;
                result.SatinAlmaUrunKod = objUrun.SatinAlmaUrunKod;
                result.Tanim = objUrun.Tanim;

                return new ProcessResult<UrunGuncelleModelDTO>().Successful(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}

