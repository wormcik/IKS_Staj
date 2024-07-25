using Microsoft.AspNetCore.Mvc;
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

        
        public async Task<ProcessResult<List<TalepModelDTO>>> TalepEkleAsync(TalepEkleSorguModel sorgu,Guid KullaniciKod)
        {
            var personel = await satinAlimDbContext.Personel.FirstOrDefaultAsync(x =>
            x.KullaniciKod==KullaniciKod);

           
            if (personel == null)
            {
                return new ProcessResult<List<TalepModelDTO>>().Failed("Personel bulunamadı");
            }
            if (personel.SatinAlmaTalep == null)
            {
                personel.SatinAlmaTalep = new List<SatinAlmaTalep>();    
            }
            var satinAlmaBirim = await satinAlimDbContext.SatinAlmaBirim.FirstOrDefaultAsync(x =>
            x.SatinAlmaBirimKod == sorgu.SatinAlmaBirimKod);

            if( satinAlmaBirim == null)
            {
                return new ProcessResult<List<TalepModelDTO>>().Failed("Birim bulunamadı");
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
                if (dbdekiUrun != null)
                {
                    var a = await satinAlimDbContext.SatinAlmaBirimUrun.FirstOrDefaultAsync(q =>
                    q.SatinAlmaBirimKod == urun.SatinAlmaBirimKod && q.SatinAlmaUrunKod == urun.SatinAlmaUrunKod);
                    if (a != null)
                    {
                        var eklenecekUrun = new SatinAlmaTalepUrun();
                        eklenecekUrun.BirimFiyat = sorgu.BirimFiyat;
                        eklenecekUrun.Miktar = sorgu.Miktar;
                        eklenecekUrun.PbKod = sorgu.OngorulenTutarPbKod;
                        talep.SatinAlmaTalepUrun.Add(eklenecekUrun);
                        if (dbdekiUrun.SatinAlmaTalepUrun == null)
                        {
                            dbdekiUrun.SatinAlmaTalepUrun = new List<SatinAlmaTalepUrun>();
                            dbdekiUrun.SatinAlmaTalepUrun.Add(eklenecekUrun);
                        }
                        else
                        {
                            dbdekiUrun.SatinAlmaTalepUrun.Add(eklenecekUrun);
                        }
                    }
                }
            }

            foreach(var hizmet in sorgu.TalepHizmetSorguModelListe)
            {
                var dbdekiHizmet = await satinAlimDbContext.SatinAlmaHizmet.FirstOrDefaultAsync(q => q.SatinAlmaHizmetKod == hizmet.SatinAlmaHizmetKod);
                if (dbdekiHizmet != null)
                {
                    var hizmetVarMı = await satinAlimDbContext.SatinAlmaBirimHizmet.FirstOrDefaultAsync(q =>
                    q.SatinAlmaHizmetKod == hizmet.SatinAlmaHizmetKod && q.SatinAlmaBirimKod == hizmet.SatinAlmaBirimKod); 
                    if (hizmetVarMı != null)
                    {
                        var eklenecekHizmet = new SatinAlmaTalepHizmet();
                        eklenecekHizmet.BirimFiyat = hizmet.BirimFiyat;
                        eklenecekHizmet.Miktar = hizmet.Miktar;
                        eklenecekHizmet.PbKod = hizmet.PbKod;
                        talep.SatinAlmaTalepHizmet.Add(eklenecekHizmet);
                        if (dbdekiHizmet.SatinAlmaTalepHizmet == null)
                        {
                            dbdekiHizmet.SatinAlmaTalepHizmet = new List<SatinAlmaTalepHizmet>();
                            dbdekiHizmet.SatinAlmaTalepHizmet.Add(eklenecekHizmet);
                        }
                        else
                        {
                            dbdekiHizmet.SatinAlmaTalepHizmet.Add(eklenecekHizmet);
                        }
                    }
                }
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

            var TalepList = new List<TalepModelDTO>();
            
            foreach(var temp in deneme)
            {
                var result = new TalepModelDTO();
                result.Aciklama = temp.Aciklama;
                result.IslemTarih = temp.IslemTarih;
                result.OnaySira = temp.OnaySira;
                result.OngorulenTutar = temp.OngorulenTutar;
                result.OngorulenTutarPbKod = temp.OngorulenTutarPbKod;
                result.SatinAlmaBirimKod = temp.SatinAlmaBirimKod;
                result.TalepTarih = temp.TalepTarih;
                result.TransactionId = temp.TransactionId;
                result.TalepUrunListe = new List<TalepUrunModelDTO>();
                foreach(var urun in temp.SatinAlmaTalepUrun)
                    {
                        var TalepUrun = new TalepUrunModelDTO();
                        TalepUrun.BirimFiyat = urun.BirimFiyat;
                        TalepUrun.Miktar = urun.Miktar;
                        TalepUrun.PbKod = urun.PbKod;
                        TalepUrun.SatinAlmaTalepUrunKod = urun.SatinAlmaTalepUrunKod;
                        TalepUrun.SatinAlmaUrunKod = urun.SatinAlmaUrunKod;
                        result.TalepUrunListe.Add(TalepUrun);
                    }
                result.TalepHizmetListe = new List<TalepHizmetModelDTO>();
                foreach(var hizmet in temp.SatinAlmaTalepHizmet)
                {
                    var TalepHizmet = new TalepHizmetModelDTO();
                    TalepHizmet.BirimFiyat = hizmet.BirimFiyat;
                    TalepHizmet.Miktar = hizmet.Miktar;
                    TalepHizmet.PbKod = hizmet.PbKod;
                    TalepHizmet.SatinAlmaHizmetKod = hizmet.SatinAlmaHizmetKod;
                    TalepHizmet.SatinAlmaTalepHizmetKod = hizmet.SatinAlmaTalepKod;
                    result.TalepHizmetListe.Add(TalepHizmet);
                }
                    TalepList.Add(result);
            }


            return new ProcessResult<List<TalepModelDTO>>().Successful(TalepList);
        }

    }
}
