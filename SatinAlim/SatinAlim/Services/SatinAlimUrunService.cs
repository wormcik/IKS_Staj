using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SatinAlim.Entities;
using SatinAlim.Models;

namespace SatinAlim.Services
{
	public class SatinAlimUrunService
	{
        private readonly IConfiguration configuration;
        private readonly SatinAlimDbContext satinAlimDbContext;

        public SatinAlimUrunService(SatinAlimDbContext satinAlimDbContext, IConfiguration configuration)
        {

            this.configuration = configuration;
            this.satinAlimDbContext = satinAlimDbContext;
        }


        public async Task<UrunEkleModelDTO> UrunEkleAsync(UrunEkleSorguModel urun)
        {
            try
            {
                var objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.Tanim == urun.Tanim);
                if(objUrun != null)
                {
                    return null;
                }

                var yeni_urun = new SatinAlmaUrun();
                yeni_urun.Tanim = urun.Tanim;
                yeni_urun.Aciklama = urun.Aciklama;
                yeni_urun.Birim = urun.Birim;
                satinAlimDbContext.SatinAlmaUrun.Add(yeni_urun);
                satinAlimDbContext.SaveChanges();

                objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.Tanim == urun.Tanim);
                var result = new UrunEkleModelDTO();
                result.Tanim = objUrun.Tanim;
                result.Aciklama = objUrun.Aciklama;
                result.Birim = objUrun.Birim;
                result.SatinAlmaUrunKod = objUrun.SatinAlmaUrunKod;
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> UrunSilAsync(int id)
        {
            try
            {
                var objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.SatinAlmaUrunKod == id);
                if(objUrun == null)
                {
                    return false;
                }
                satinAlimDbContext.SatinAlmaUrun.Remove(objUrun);
                await satinAlimDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<UrunBulModelDTO> UrunBulAsync(int id)
        {
            try
            {
                var objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.SatinAlmaUrunKod == id);
                if (objUrun == null)
                {
                    return null;
                }
                UrunBulModelDTO urun = new UrunBulModelDTO();
                urun.SatinAlmaUrunKod = objUrun.SatinAlmaUrunKod;
                urun.Tanim = objUrun.Tanim;
                urun.Birim = objUrun.Birim;
                urun.Aciklama = objUrun.Aciklama;
                return urun;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UrunListeleModelDTO>> UrunListeleAsync(UrunListeleSorguModel sorgu)
        {
            try
            {
                var urunList = await satinAlimDbContext.SatinAlmaUrun.Where(
                    x => (x.Birim == sorgu.Birim || String.IsNullOrEmpty(sorgu.Birim)) &&
                    x.Aciklama.Contains(sorgu.Aciklama) &&
                    (x.Tanim == sorgu.Tanim || String.IsNullOrEmpty(sorgu.Tanim))
                    ).ToListAsync();
                
                if(urunList == null)
                {
                    return null;
                }
                var result = new List<UrunListeleModelDTO>();
                var temp = new UrunListeleModelDTO();
                foreach (var urun in urunList)
                {
                    temp = new UrunListeleModelDTO();
                    temp.Aciklama = urun.Aciklama;
                    temp.Birim = urun.Birim;
                    temp.SatinAlmaUrunKod = urun.SatinAlmaUrunKod;
                    temp.Tanim = urun.Tanim;
                    result.Add(temp);
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



        public async Task<UrunGuncelleModelDTO> UrunGuncelleAsync(UrunGuncelleSorguModel urun)
        {
            try
            {
                var objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.SatinAlmaUrunKod == urun.SatinAlmaUrunKod);
                if (objUrun == null)
                {
                    return null;
                }
                objUrun.Birim = urun.Birim;
                objUrun.Aciklama = urun.Aciklama;
                objUrun.Tanim = urun.Tanim;
                satinAlimDbContext.Entry(objUrun).State = EntityState.Modified;

                await satinAlimDbContext.SaveChangesAsync();

                objUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(x => x.SatinAlmaUrunKod == urun.SatinAlmaUrunKod);

                var result = new UrunGuncelleModelDTO();
                result.Aciklama = objUrun.Aciklama;
                result.Birim = objUrun.Birim;
                result.SatinAlmaUrunKod = objUrun.SatinAlmaUrunKod;
                result.Tanim = objUrun.Tanim;

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}

