using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using SatinAlim.Entities;
using SatinAlim.Helpers;
using SatinAlim.Models;
using SatinAlim.Models.DTO;
using System.Reflection.Metadata.Ecma335;


namespace SatinAlim.Services
{
    public class PersonelService
    {
        private readonly IConfiguration configuration;
        private readonly SatinAlimDbContext satinAlmaDbContext;

        public PersonelService(SatinAlimDbContext dbContext, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.satinAlmaDbContext = dbContext;
        }

        public async Task<ProcessResult<PersonelEkleModelDTO>> PersonelEkleAsync(PersonelEkleSorguModel personel)
        {
            try
            {
                var obj = await satinAlmaDbContext.Personel.FirstOrDefaultAsync(x => x.Ad == personel.Ad);
                if (obj != null)
                {
                    return new ProcessResult<PersonelEkleModelDTO>().Failed("Boyle bir personel var!");
                }
                var new_personel = new Personel();
                new_personel.Ad = personel.Ad;
                new_personel.Soyad = personel.Soyad;
                new_personel.Pozisyon = personel.Pozisyon;
                new_personel.SatinAlmaBirimPersonel = new List<SatinAlmaBirimPersonel>();
                new_personel.KullaniciKod = Guid.Parse(personel.KullaniciKod);
                var satinAlmaPersonelBirim = new SatinAlmaBirimPersonel()
                {
                    SatinAlmaBirimKod = personel.SatinAlmaBirimKod,
                };
                new_personel.SatinAlmaBirimPersonel.Add(satinAlmaPersonelBirim);
                satinAlmaDbContext.Personel.Add(new_personel);
                satinAlmaDbContext.SaveChangesAsync();

                var res = new PersonelEkleModelDTO();
                res.Ad = personel.Ad;
                res.Soyad = personel.Soyad;
                res.Pozisyon = personel.Pozisyon;

                return new ProcessResult<PersonelEkleModelDTO>().Successful(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcessResult<bool>> PersonelSilAsync(int personelKod)
        {
            try
            {
                var obj = await satinAlmaDbContext.Personel.FirstOrDefaultAsync(x => x.PersonelKod == personelKod);
                if (obj == null)
                {
                    return new ProcessResult<bool>().Failed("Personel Bulunamadi");
                }
                satinAlmaDbContext.Personel.Remove(obj);
                await satinAlmaDbContext.SaveChangesAsync();
                return new ProcessResult<bool>().Successful(true); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcessResult<PersonelGetirModelDTO>> PersonelGetirAsync(int personelKod)
        {
            try
            {
                var obj = await satinAlmaDbContext.Personel.FirstOrDefaultAsync(x => x.PersonelKod == personelKod);
                if (obj == null)
                {
                    return new ProcessResult<PersonelGetirModelDTO>().Failed("Getirilecek Personel Yok!!");
                }

                PersonelGetirModelDTO personel = new PersonelGetirModelDTO();
                personel.PersonelKod = obj.PersonelKod;
                personel.Ad = obj.Ad;
                personel.Soyad = obj.Soyad;
                personel.Pozisyon = obj.Pozisyon;

                return new ProcessResult<PersonelGetirModelDTO>().Successful(personel);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcessResult<PersonelGuncelleModelDTO>> PersonelGuncelleAsync(PersonelGuncelleSorguModel personel)
        {
            try
            {

                var obj = await satinAlmaDbContext.Personel.FirstOrDefaultAsync(x => x.PersonelKod == personel.PersonelKod);
                if (obj == null)
                {
                    return new ProcessResult<PersonelGuncelleModelDTO>().Failed("Personel Bulunamadi");
                }
                obj.Ad = personel.Ad;
                obj.Soyad = personel.Soyad;
                obj.Pozisyon = personel.Pozisyon;

                await satinAlmaDbContext.SaveChangesAsync();
                var result = new PersonelGuncelleModelDTO();
                result.Ad = obj.Ad;
                result.Soyad = obj.Soyad;
                result.Pozisyon = result.Pozisyon;

                return new ProcessResult<PersonelGuncelleModelDTO>().Successful(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ProcessResult<List<PersonelListeleModelDTO>>> PersonelListeleAsync(PersonelListeleSorguModel sorgu)
        {
            try
            {
                var personelList = await satinAlmaDbContext.Personel.Where(
                    x => (x.Ad == sorgu.Ad.ToUpper() || String.IsNullOrEmpty(sorgu.Ad)) &&
                    x.Soyad.ToUpper().Contains(sorgu.Soyad.ToUpper()) &&
                    (x.Pozisyon.ToUpper() == sorgu.Pozisyon.ToUpper() || String.IsNullOrEmpty(sorgu.Pozisyon))
                    ).ToListAsync();

                if (personelList == null)
                {
                    return new ProcessResult<List<PersonelListeleModelDTO>>().Failed("Personel Bulunamadi");
                }
                var result = new List<PersonelListeleModelDTO>();

                foreach (var personel in personelList)
                {
                    var temp = new PersonelListeleModelDTO();
                    temp.PersonelKod = personel.PersonelKod;
                    temp.Ad = personel.Ad;
                    temp.Soyad = personel.Soyad;
                    temp.Pozisyon = personel.Pozisyon;
                    result.Add(temp);
                }
                return new ProcessResult<List<PersonelListeleModelDTO>>().Successful(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }


}
