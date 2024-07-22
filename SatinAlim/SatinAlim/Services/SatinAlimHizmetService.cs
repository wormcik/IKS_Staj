using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SatinAlim.Entities;
using System.Reflection.Metadata.Ecma335;

namespace SatinAlimHizmet.Services
{
    public class SatinAlimHizmetService
    {
        private readonly SatinAlimDbContext satinAlmaDbContext; // Use SatinAlmaDbContext instead of DbContext
        private readonly IConfiguration configuration;

        public SatinAlimHizmetService(SatinAlimDbContext dbContext, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.satinAlmaDbContext = dbContext;
        }

        public async Task<SatinAlmaTalepHizmet> CreateSatinAlmaTalepHizmetAsync(SatinAlmaTalepHizmet entity)
        {
            satinAlmaDbContext.GetSatinAlmaTalepHizmet.Add(entity);
            await satinAlmaDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<SatinAlmaTalepHizmet> GetSatinAlmaTalepHizmetAsync(int id)
        {
            return await satinAlmaDbContext.GetSatinAlmaTalepHizmet.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> DeleteSatinAlmaTalepHizmetAsync(int id)
        {
            var entity = await satinAlmaDbContext.GetSatinAlmaTalepHizmet.SingleOrDefaultAsync(s => s.Id == id);
            if (entity == null) 
                return false;

            satinAlmaDbContext.GetSatinAlmaTalepHizmet.Remove(entity);
            await satinAlmaDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<SatinAlmaTalepHizmet> UpdateSatinAlmaTalepHizmetAsync(SatinAlmaTalepHizmet entity,int id)
        {
            var hizmet = await satinAlmaDbContext.GetSatinAlmaTalepHizmet.SingleOrDefaultAsync(s => s.Id == id);
            hizmet.Miktar = entity.Miktar;
            hizmet.PbKod = entity.PbKod;
            hizmet.BirimFiyat = entity.BirimFiyat;
            hizmet.SatinAlmaTalep = entity.SatinAlmaTalep;

            satinAlmaDbContext.Entry(entity).State = EntityState.Modified;

            await satinAlmaDbContext.SaveChangesAsync();

            return hizmet;


        }

        // return hizmet
    }
}
