using Microsoft.EntityFrameworkCore;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using System.Runtime.ConstrainedExecution;

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
            if (personel.SatinAlmaTalep == null)
            {
                personel.SatinAlmaTalep = new List<SatinAlmaTalep>();    
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
            talep.SatinAlmaTalepUrun = new List<SatinAlmaTalepUrun>();
            talep.SatinAlmaTalepHizmet = new List<SatinAlmaTalepHizmet>();

            foreach (var urun in sorgu.TalepUrunSorguModelListe)
            {
                var dbdekiUrun = await satinAlimDbContext.SatinAlmaUrun.FirstOrDefaultAsync(q => q.SatinAlmaUrunKod == urun.SatinAlmaUrunKod);
                var eklenecekUrun = new SatinAlmaTalepUrun();
                eklenecekUrun.BirimFiyat = sorgu.BirimFiyat;
                eklenecekUrun.Miktar = sorgu.Miktar;
                eklenecekUrun.PbKod = sorgu.OngorulenTutarPbKod;
                talep.SatinAlmaTalepUrun.Add(eklenecekUrun);
                if (dbdekiUrun.SatinAlmaBirimUrun == null)
                {
                    dbdekiUrun.SatinAlmaTalepUrun = new List<SatinAlmaTalepUrun>();
                    dbdekiUrun.SatinAlmaTalepUrun.Add(eklenecekUrun);
                }
                else
                {
                    dbdekiUrun.SatinAlmaTalepUrun.Add(eklenecekUrun);
                }
            }

            foreach(var hizmet in sorgu.TalepHizmetSorguModelListe)
            {;
                var dbdekiHizmet = await satinAlimDbContext.SatinAlmaHizmet.FirstOrDefaultAsync(q => q.SatinAlmaHizmetKod == hizmet.SatinAlmaHizmetKod);
                var eklenecekHizmet = new SatinAlmaTalepHizmet();
                eklenecekHizmet.BirimFiyat = hizmet.BirimFiyat;
                eklenecekHizmet.Miktar = hizmet.Miktar;
                eklenecekHizmet.PbKod = hizmet.PbKod;
                talep.SatinAlmaTalepHizmet.Add(eklenecekHizmet);
                dbdekiHizmet.SatinAlmaTalepHizmet.Add(eklenecekHizmet);
            }

            personel.SatinAlmaTalep.Add(talep);

            await satinAlimDbContext.SatinAlmaTalep.AddAsync(talep);
            await satinAlimDbContext.SaveChangesAsync();

            var deneme = await satinAlimDbContext.SatinAlmaTalep
                .Include(x => x.SatinAlmaTalepUrun)
                    .ThenInclude(x => x.SatinAlmaUrun)
                        .ThenInclude(x => x.SatinAlmaBirimUrun)
                            .ThenInclude(x => x.SatinAlmaBirim)
                .Include(x => x.SatinAlmaTalepHizmet)
                    .ThenInclude(x => x.SatinAlmaHizmet)
                        .ThenInclude(x => x.SatinAlmaBirimHizmet)
                            .ThenInclude(x => x.SatinAlmaBirim)
                .ToListAsync();


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
