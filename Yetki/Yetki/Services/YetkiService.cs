using Microsoft.AspNetCore.Identity;
using Yetki.Entites;
using Yetki.Models;

namespace Yetki.Services
{
    public class YetkiService
    {
        private readonly YetkiDbContext yetkiDbContext;

        public YetkiService(YetkiDbContext yetkiDbContext)
        {
            this.yetkiDbContext = yetkiDbContext;
        }

        public async Task<bool> SignUpAsync(RegistrationModel registrationModel)
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
        public async Task<bool> SignInAsync()
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
    }
}
