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
            talep.OnaySira = 1; 
            talep.OngorulenTutar = sorgu.OngorulenTutar;
            talep.OngorulenTutarPbKod = sorgu.OngorulenTutarPbKod;
            talep.SatinAlmaBirimKod = sorgu.SatinAlmaBirimKod;
            talep.TalepTarih = sorgu.TalepTarih;
            talep.TransactionId = Guid.NewGuid();
            talep.SatinAlmaTalepUrun = new List<SatinAlmaTalepUrun>();
            talep.SatinAlmaTalepHizmet = new List<SatinAlmaTalepHizmet>();
            talep.Onaylandi = false;
            talep.Reddedildi = false;

            var talepTarihce = new SatinAlmaTalepTarihce();
            talepTarihce.Aciklama = talep.Aciklama;
            talepTarihce.IslemTarih = talep.IslemTarih;
            talepTarihce.OnaySira = talep.OnaySira;
            talepTarihce.PersonelKod = personel.PersonelKod;

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
                        eklenecekUrun.BirimFiyat = urun.BirimFiyat;
                        eklenecekUrun.Miktar = urun.Miktar;
                        eklenecekUrun.PbKod = urun.PbKod;
                        talep.SatinAlmaTalepUrun.Add(eklenecekUrun);
                        if (dbdekiUrun.SatinAlmaTalepUrun == null)
                        {
                            dbdekiUrun.SatinAlmaTalepUrun = new List<SatinAlmaTalepUrun>();
                        }
                        dbdekiUrun.SatinAlmaTalepUrun.Add(eklenecekUrun);
                       
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

            talepTarihce.SatinAlmaTalep = await satinAlimDbContext.SatinAlmaTalep.FirstOrDefaultAsync(x =>
            x.TransactionId == talep.TransactionId);

            await satinAlimDbContext.SatinAlmaTalepTarihce.AddAsync(talepTarihce);
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
                result.SatinAlmaTalepKod = temp.SatinAlmaTalepKod;
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



        public async Task<ProcessResult<List<TalepModelDTO>>> TalepListeleAsync(Guid KullaniciKod)
        {
            var personel = await satinAlimDbContext.Personel.FirstOrDefaultAsync(x =>
            x.KullaniciKod == KullaniciKod);

            if(personel == null)
            {
                return new ProcessResult<List<TalepModelDTO>>().Failed("Personel bulunamadı.");
            }
            var BirimPersonel = await satinAlimDbContext.SatinAlmaBirimPersonel.FirstOrDefaultAsync(x=>
            x.PersonelKod == personel.PersonelKod);
            if (BirimPersonel ==null)
            {
                return new ProcessResult<List<TalepModelDTO>>().Failed("Personel birimi bulunamadı.");
            }
            var TalepListe = await satinAlimDbContext.SatinAlmaTalep.Where(x=> x.SatinAlmaBirimKod == BirimPersonel.SatinAlmaBirimKod)
                .Include(x => x.SatinAlmaTalepUrun)
                    .ThenInclude(x => x.SatinAlmaUrun)
                        .ThenInclude(x => x.SatinAlmaBirimUrun)
                            .ThenInclude(x => x.SatinAlmaBirim)
                .Include(x => x.SatinAlmaTalepHizmet)
                    .ThenInclude(x => x.SatinAlmaHizmet)
                        .ThenInclude(x => x.SatinAlmaBirimHizmet)
                            .ThenInclude(x => x.SatinAlmaBirim) 
                .ToListAsync();

            if(TalepListe == null)
            {
                return new ProcessResult<List<TalepModelDTO>>().Failed("Talep bulunamadı.");

            }

            var TalepModelDTOListe = new List<TalepModelDTO>();

            foreach (var temp in TalepListe)
            {
                var result = new TalepModelDTO();
                result.SatinAlmaTalepKod = temp.SatinAlmaTalepKod;
                result.Aciklama = temp.Aciklama;
                result.IslemTarih = temp.IslemTarih;
                result.OnaySira = temp.OnaySira;
                result.OngorulenTutar = temp.OngorulenTutar;
                result.OngorulenTutarPbKod = temp.OngorulenTutarPbKod;
                result.SatinAlmaBirimKod = temp.SatinAlmaBirimKod;
                result.TalepTarih = temp.TalepTarih;
                result.TransactionId = temp.TransactionId;
                result.TalepUrunListe = new List<TalepUrunModelDTO>();
                foreach (var urun in temp.SatinAlmaTalepUrun)
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
                foreach (var hizmet in temp.SatinAlmaTalepHizmet)
                {
                    var TalepHizmet = new TalepHizmetModelDTO();
                    TalepHizmet.BirimFiyat = hizmet.BirimFiyat;
                    TalepHizmet.Miktar = hizmet.Miktar;
                    TalepHizmet.PbKod = hizmet.PbKod;
                    TalepHizmet.SatinAlmaHizmetKod = hizmet.SatinAlmaHizmetKod;
                    TalepHizmet.SatinAlmaTalepHizmetKod = hizmet.SatinAlmaTalepKod;
                    result.TalepHizmetListe.Add(TalepHizmet);
                }
                TalepModelDTOListe.Add(result);
            }
            return new ProcessResult<List<TalepModelDTO>>().Successful(TalepModelDTOListe);
        }




        public async Task<ProcessResult<TalepModelDTO>> TalepGetirAsync(long TalepKod,Guid KullanıcıKod)
        {
            var talep = await satinAlimDbContext.SatinAlmaTalep
    .Include(x => x.SatinAlmaTalepUrun)
        .ThenInclude(x => x.SatinAlmaUrun)
            .ThenInclude(x => x.SatinAlmaBirimUrun)
                .ThenInclude(x => x.SatinAlmaBirim)
    .Include(x => x.SatinAlmaTalepHizmet)
        .ThenInclude(x => x.SatinAlmaHizmet)
            .ThenInclude(x => x.SatinAlmaBirimHizmet)
                .ThenInclude(x => x.SatinAlmaBirim).FirstOrDefaultAsync(x => x.SatinAlmaTalepKod == TalepKod);

            if (talep == null)
            {
                return new ProcessResult<TalepModelDTO>().Failed("Talep bulunamamdı.");
            }

            var Personel = await satinAlimDbContext.Personel.FirstOrDefaultAsync(x =>
            x.KullaniciKod == KullanıcıKod);

            if(Personel == null)
            {
                return new ProcessResult<TalepModelDTO>().Failed("Personel bulunamamdı.");

            }

            var BirimPersonel = await satinAlimDbContext.SatinAlmaBirimPersonel.FirstOrDefaultAsync(x =>
            x.PersonelKod == Personel.PersonelKod);

            if(BirimPersonel.SatinAlmaBirimKod != talep.SatinAlmaBirimKod)
            {
                return new ProcessResult<TalepModelDTO>().Failed("Personel birimi talep biriminden farklı.");
            }

            var result = new TalepModelDTO();
            result.SatinAlmaTalepKod = talep.SatinAlmaTalepKod;
            result.Aciklama = talep.Aciklama;
            result.IslemTarih = talep.IslemTarih;
            result.OnaySira = talep.OnaySira;
            result.OngorulenTutar = talep.OngorulenTutar;
            result.OngorulenTutarPbKod = talep.OngorulenTutarPbKod;
            result.SatinAlmaBirimKod = talep.SatinAlmaBirimKod;
            result.TalepTarih = talep.TalepTarih;
            result.TransactionId = talep.TransactionId;
            result.TalepUrunListe = new List<TalepUrunModelDTO>();
            foreach (var urun in talep.SatinAlmaTalepUrun)
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
            foreach (var hizmet in talep.SatinAlmaTalepHizmet)
            {
                var TalepHizmet = new TalepHizmetModelDTO();
                TalepHizmet.BirimFiyat = hizmet.BirimFiyat;
                TalepHizmet.Miktar = hizmet.Miktar;
                TalepHizmet.PbKod = hizmet.PbKod;
                TalepHizmet.SatinAlmaHizmetKod = hizmet.SatinAlmaHizmetKod;
                TalepHizmet.SatinAlmaTalepHizmetKod = hizmet.SatinAlmaTalepKod;
                result.TalepHizmetListe.Add(TalepHizmet);
            }



            return new ProcessResult<TalepModelDTO>().Successful(result);

        }


        public async Task<ProcessResult<bool>> TalepOnaylaAsync(long TalepKod,Guid KullaniciKod)
        {
            var personel = await satinAlimDbContext.Personel.FirstOrDefaultAsync(x =>
            x.KullaniciKod == KullaniciKod);
            if (personel == null)
            {
                return new ProcessResult<bool>().Failed("Personel bulunamadı");
            }

          var talep = await satinAlimDbContext.SatinAlmaTalep
            .Include(x => x.SatinAlmaTalepUrun)
                .ThenInclude(x => x.SatinAlmaUrun)
                    .ThenInclude(x => x.SatinAlmaBirimUrun)
                        .ThenInclude(x => x.SatinAlmaBirim)
                .Include(x => x.SatinAlmaTalepHizmet)
                    .ThenInclude(x => x.SatinAlmaHizmet)
                        .ThenInclude(x => x.SatinAlmaBirimHizmet)
                .ThenInclude(x => x.SatinAlmaBirim).FirstOrDefaultAsync(x => x.SatinAlmaTalepKod == TalepKod);

            if (talep == null)
            {
                return new ProcessResult<bool>().Failed("Talep bulunamamdı.");
            }

            if(talep.Onaylandi == true)
            {
                return new ProcessResult<bool>().Failed("Talep onceden onaylanmıs.");
            }

            if(talep.Reddedildi == true)
            {
                return new ProcessResult<bool>().Failed("Talep onceden reddedilmis.");
            }

            var OnayciPersonel = await satinAlimDbContext.SatinAlmaBirimOnayci.FirstOrDefaultAsync(x =>
            x.PersonelKod == personel.PersonelKod);

            if(OnayciPersonel.SatinAlmaBirim != talep.SatinAlmaBirim)
            {
                return new ProcessResult<bool>().Failed("Personel talebin yapiligi birimde bulunmamaktadır.");
            }

            if(OnayciPersonel.OnaySira != talep.OnaySira)
            {
                return new ProcessResult<bool>().Failed("Personel onay sırası talebin onay sırasından farklı.");
            }

            var OnaycıBirim = await satinAlimDbContext.SatinAlmaBirim.FirstOrDefaultAsync(x =>
            x.SatinAlmaBirimKod==OnayciPersonel.SatinAlmaBirimKod);

            if (OnaycıBirim.OnaySayi >= talep.OnaySira + 1)
            {
                talep.OnaySira++;
            }

            else
            {
                talep.Onaylandi = true;
            }

            var talepTarihce = new SatinAlmaTalepTarihce();
            talepTarihce.Aciklama = personel.Ad + " " + personel.Soyad + " " + TalepKod + " numaralı talebi onayladı";
            talepTarihce.IslemTarih = talep.IslemTarih;
            talepTarihce.OnaySira = talep.OnaySira;
            talepTarihce.PersonelKod = personel.PersonelKod;
            talepTarihce.SatinAlmaTalepKod = talep.SatinAlmaTalepKod;

            await satinAlimDbContext.SatinAlmaTalepTarihce.AddAsync(talepTarihce);
            satinAlimDbContext.Update(talep);
            await satinAlimDbContext.SaveChangesAsync();

            return new ProcessResult<bool>().Successful(true);
        }





        public async Task<ProcessResult<bool>> TalepReddetAsync(long TalepKod, Guid KullaniciKod)
        {
            var personel = await satinAlimDbContext.Personel.FirstOrDefaultAsync(x =>
            x.KullaniciKod == KullaniciKod);
            if (personel == null)
            {
                return new ProcessResult<bool>().Failed("Personel bulunamadı");
            }

            var talep = await satinAlimDbContext.SatinAlmaTalep
              .Include(x => x.SatinAlmaTalepUrun)
                  .ThenInclude(x => x.SatinAlmaUrun)
                      .ThenInclude(x => x.SatinAlmaBirimUrun)
                          .ThenInclude(x => x.SatinAlmaBirim)
                  .Include(x => x.SatinAlmaTalepHizmet)
                      .ThenInclude(x => x.SatinAlmaHizmet)
                          .ThenInclude(x => x.SatinAlmaBirimHizmet)
                  .ThenInclude(x => x.SatinAlmaBirim).FirstOrDefaultAsync(x => x.SatinAlmaTalepKod == TalepKod);

            if (talep == null)
            {
                return new ProcessResult<bool>().Failed("Talep bulunamamdı.");
            }

            if (talep.Onaylandi == true)
            {
                return new ProcessResult<bool>().Failed("Talep onceden onaylanmıs.");
            }

            if (talep.Reddedildi == true)
            {
                return new ProcessResult<bool>().Failed("Talep onceden reddedilmis.");
            }

            var OnayciPersonel = await satinAlimDbContext.SatinAlmaBirimOnayci.FirstOrDefaultAsync(x =>
            x.PersonelKod == personel.PersonelKod);

            if (OnayciPersonel.SatinAlmaBirim != talep.SatinAlmaBirim)
            {
                return new ProcessResult<bool>().Failed("Personel talebin yapiligi birimde bulunmamaktadır.");
            }

            if (OnayciPersonel.OnaySira != talep.OnaySira)
            {
                return new ProcessResult<bool>().Failed("Personel onay sırası talebin onay sırasından farklı.");
            }

            talep.Reddedildi = true;

            var talepTarihce = new SatinAlmaTalepTarihce();
            talepTarihce.Aciklama = personel.Ad+" "+personel.Soyad+" "+TalepKod+" numaralı talebi reddeti";
            talepTarihce.IslemTarih = talep.IslemTarih;
            talepTarihce.OnaySira = talep.OnaySira;
            talepTarihce.PersonelKod = personel.PersonelKod;
            talepTarihce.SatinAlmaTalepKod = talep.SatinAlmaTalepKod;

            await satinAlimDbContext.SatinAlmaTalepTarihce.AddAsync(talepTarihce);
            satinAlimDbContext.Update(talep);
            await satinAlimDbContext.SaveChangesAsync();

            return new ProcessResult<bool>().Successful(true);
        }
    }


}
