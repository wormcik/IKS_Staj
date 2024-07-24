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

        
        public async Task<ProcessResult<TalepEkleModelDTO>> TalepEkleAsync(TalepEkleSorguModel sorgu,Guid KullaniciKod)
        {
            var personel = await satinAlimDbContext.Personel.FirstOrDefaultAsync(x =>
            x.KullaniciKod==KullaniciKod);

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
            talep.SatinAlmaBirimKod = sorgu.SatinAlmaBirimKod;
            talep.TalepTarih = sorgu.TalepTarih;
            talep.TransactionId = Guid.NewGuid();

            foreach (var urun in sorgu.TalepUrunSorguModelListe)
            {
                var eklenecekUrun = new SatinAlmaTalepUrun();
                eklenecekUrun.BirimFiyat = sorgu.BirimFiyat;
                eklenecekUrun.Miktar = sorgu.Miktar;
                eklenecekUrun.PbKod = sorgu.OngorulenTutarPbKod;
                talep.SatinAlmaTalepUrun.Add(eklenecekUrun);
            }

            foreach(var hizmet in sorgu.TalepHizmetSorguModelListe)
            {
                var eklenecekHizmet = new SatinAlmaTalepHizmet();
                eklenecekHizmet.BirimFiyat = hizmet.BirimFiyat;
                eklenecekHizmet.Miktar = hizmet.Miktar;
                eklenecekHizmet.PbKod = hizmet.PbKod;
                talep.SatinAlmaTalepHizmet.Add(eklenecekHizmet);
            }

            personel.SatinAlmaTalep.Add(talep);

            await satinAlimDbContext.SatinAlmaTalep.AddAsync(talep);
            await satinAlimDbContext.SaveChangesAsync();

            var result = new TalepEkleModelDTO();

            result.Aciklama = talep.Aciklama;
            result.IslemTarih = talep.IslemTarih;
            result.OnaySira = talep.OnaySira;
            result.OngorulenTutar = talep.OngorulenTutar;
            result.OngorulenTutarPbKod = talep.OngorulenTutarPbKod;
            result.SatinAlmaBirimKod = talep.SatinAlmaBirimKod;
            result.PersonelKod = talep.PersonelKod;
            result.TalepTarih = talep.TalepTarih;
            result.TransactionId = talep.TransactionId;

            return new ProcessResult<TalepEkleModelDTO>().Successful(result);
        }

    }
}
