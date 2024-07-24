using Microsoft.EntityFrameworkCore;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;

namespace SatinAlim.Services
{
    public class SatinAlimService
    {
        public readonly SatinAlimDbContext satinAlimDbContext;
        public SatinAlimService(SatinAlimDbContext satinAlimDbContext)
        {
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

        
        public async Task<ProcessResult<TalepEkleModelDTO>> TalepEkleAsync(TalepEkleSorguModel sorgu,Guid KullanıcıKod)
        {
            var personel = await satinAlimDbContext.Personel.FirstOrDefaultAsync(x =>
            x.KullanıcıKod==KullanıcıKod);

            if (personel == null)
            {
                return new ProcessResult<TalepEkleModelDTO>().Failed("Personel bulunamadı");
            }
            var satinAlmaBirim = await satinAlimDbContext.SatinAlmaBirim.FirstOrDefaultAsync(x =>
            x.SatinAlmaBirimKod == sorgu.SatinAlmaBirimKod);

            if( satinAlmaBirim == null)
            {
                return new ProcessResult<TalepEkleModelDTO>().Failed("Birim bulunamadı");
            }

            var talep = new SatinAlmaTalep();
            talep.Aciklama = sorgu.Aciklama;
            talep.IslemTarih = DateTime.Now;
            talep.OnaySira = sorgu.OnaySira;
            talep.OngorulenTutar = sorgu.OngorulenTutar;
            talep.OngorulenTutarPbKod = sorgu.OngorulenTutarPbKod;
            talep.TalepPersonelKod = sorgu.TalepPersonelKod;
            talep.SatinAlmaBirimKod = sorgu.SatinAlmaBirimKod;
            talep.TalepTarih = DateTime.Now;
            talep.TransactionId = Guid.NewGuid();

            await satinAlimDbContext.SatinAlmaTalep.AddAsync(talep);
            await satinAlimDbContext.SaveChangesAsync();

            var result = new TalepEkleModelDTO();

            result.Aciklama = talep.Aciklama;
            result.IslemTarih = talep.IslemTarih;
            result.OnaySira = talep.OnaySira;
            result.OngorulenTutar = talep.OngorulenTutar;
            result.OngorulenTutarPbKod = talep.OngorulenTutarPbKod;
            result.SatinAlmaBirimKod = talep.SatinAlmaBirimKod;
            result.TalepPersonelKod = talep.TalepPersonelKod;
            result.TalepTarih = talep.TalepTarih;
            result.TransactionId = talep.TransactionId;

            return new ProcessResult<TalepEkleModelDTO>().Successful(result);
        }

    }
}
