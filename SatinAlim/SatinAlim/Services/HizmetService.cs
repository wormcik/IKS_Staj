using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using System.Reflection.Metadata.Ecma335;

namespace SatinAlimHizmet.Services
{
    public class HizmetService
    {
        private readonly SatinAlimDbContext satinAlmaDbContext; // Use SatinAlmaDbContext instead of DbContext
        private readonly IConfiguration configuration;

        public HizmetService(SatinAlimDbContext dbContext, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.satinAlmaDbContext = dbContext;
        }


        public async Task<ProcessResult<HizmetEkleModelDTO>> HizmetEkleAsync(HizmetEkleSorguModel hizmet)
        {
            try
            {
                var obj = await satinAlmaDbContext.SatinAlmaHizmet.FirstOrDefaultAsync(x => x.Tanim == hizmet.Tanim);
                if (obj != null)
                {
                    return new ProcessResult<HizmetEkleModelDTO>().Failed("Boyle bir hizmet var zaten!!! ");
                }

                var new_hizmet = new SatinAlmaHizmet();
                new_hizmet.Tanim = hizmet.Tanim;
                new_hizmet.Aciklama = hizmet.Aciklama;
                new_hizmet.Birim = hizmet.Birim.ToUpper();
                satinAlmaDbContext.SatinAlmaHizmet.Add(new_hizmet);
                await satinAlmaDbContext.SaveChangesAsync();

                var res = new HizmetEkleModelDTO();
                res.Tanim = new_hizmet.Tanim;
                res.Aciklama = new_hizmet.Aciklama;
                res.Birim = new_hizmet.Birim;

                return new ProcessResult<HizmetEkleModelDTO>().Successful(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcessResult<bool>> DeleteHizmetAsync(int hizmetKod)
        {
            try
            {
                var obj = await satinAlmaDbContext.SatinAlmaHizmet.FirstOrDefaultAsync(x => x.SatinAlmaHizmetKod == hizmetKod);
                if (obj == null)
                {
                    return new ProcessResult<bool>().Failed("Boyle bir hizmet henuz yok!!");
                }
                satinAlmaDbContext.SatinAlmaHizmet.Remove(obj);
                await satinAlmaDbContext.SaveChangesAsync();
                return new ProcessResult<bool>().Successful();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcessResult<List<HizmetListeleModelDTO>>> HizmetListeleAsync(HizmetListeleSorguModel sorgu)
        {
            try
            {
                var hizmetList = await satinAlmaDbContext.SatinAlmaHizmet.Where(
                    x => (x.Birim == sorgu.Birim.ToUpper() || String.IsNullOrEmpty(sorgu.Birim)) &&
                    x.Aciklama.ToUpper().Contains(sorgu.Aciklama.ToUpper()) &&
                    (x.Tanim.ToUpper() == sorgu.Tanim.ToUpper() || String.IsNullOrEmpty(sorgu.Tanim))
                    ).ToListAsync();

                if (hizmetList == null)
                {
                    return new ProcessResult<List<HizmetListeleModelDTO>>().Failed("Hizmet bulunamadı");
                }
                var result = new List<HizmetListeleModelDTO>();

                foreach (var hizmet in hizmetList)
                {
                    var temp = new HizmetListeleModelDTO();
                    temp.Aciklama = hizmet.Aciklama;
                    temp.Birim = hizmet.Birim;
                    temp.SatinAlmaHizmetKod = hizmet.SatinAlmaHizmetKod;
                    temp.Tanim = hizmet.Tanim;
                    result.Add(temp);
                }
                return new ProcessResult<List<HizmetListeleModelDTO>>().Successful(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcessResult<HizmetGuncelleModelDTO>> HizmetGuncelleAsync(HizmetGuncelleSorguModel hizmet)
        {
            try
            {
                var obj = await satinAlmaDbContext.SatinAlmaHizmet.FirstOrDefaultAsync(x => x.SatinAlmaHizmetKod == hizmet.SatinAlmaHizmetKod);
                if (obj == null)
                {
                    return new ProcessResult<HizmetGuncelleModelDTO>().Failed("Urun Bulunamadi");
                }
                obj.Birim = hizmet.Birim.ToUpper();
                obj.Aciklama = hizmet.Aciklama;
                obj.Tanim = hizmet.Tanim;
                satinAlmaDbContext.Entry(obj).State = EntityState.Modified;

                await satinAlmaDbContext.SaveChangesAsync();

                var result = new HizmetGuncelleModelDTO();
                result.Aciklama = obj.Aciklama;
                result.Tanim = obj.Tanim;
                result.Birim = obj.Birim;
                result.SatinAlmaUrunKod = result.SatinAlmaUrunKod;

                return new ProcessResult<HizmetGuncelleModelDTO>().Successful(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ProcessResult<HizmetGetirModelDTO>> HizmetGetirAsync(int hizmetKod)
        {
            try
            {
                var obj = await satinAlmaDbContext.SatinAlmaHizmet.FirstOrDefaultAsync(x => x.SatinAlmaHizmetKod == hizmetKod);
                if (obj == null)
                {
                    return new ProcessResult<HizmetGetirModelDTO>().Failed("Ürün bulunamadı");
                }
                HizmetGetirModelDTO hizmet = new HizmetGetirModelDTO();
                hizmet.SatinAlmaHizmetKod = obj.SatinAlmaHizmetKod;
                hizmet.Tanim = obj.Tanim;
                hizmet.Birim = obj.Birim;
                hizmet.Aciklama = obj.Aciklama;
                return new ProcessResult<HizmetGetirModelDTO>().Successful(hizmet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcessResult<bool>> HizmetSilAsync(int hizmetKod)
        {
            try
            {
                var obj = await satinAlmaDbContext.SatinAlmaHizmet.FirstOrDefaultAsync(x => x.SatinAlmaHizmetKod == hizmetKod);
                if (obj == null)
                {
                    return new ProcessResult<bool>().Failed("Hizmet bulunamadı");
                }
                satinAlmaDbContext.SatinAlmaHizmet.Remove(obj);
                await satinAlmaDbContext.SaveChangesAsync();
                return new ProcessResult<bool>().Successful();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}