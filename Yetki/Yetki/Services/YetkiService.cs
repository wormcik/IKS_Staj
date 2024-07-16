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
                var objUser = yetkiDbContext.Users.FirstOrDefault(x => x.Username == registrationModel.Username);
                if (objUser == null)
                {
                    var user = new User();
                    user.Username = registrationModel.Username;
                    user.Name = registrationModel.Name;
                    user.LastName = registrationModel.LastName;
                    user.Password = registrationModel.Password;
                    user.UserType = registrationModel.UserType;
                    user.RegistrationDate = DateTime.Now;
                    yetkiDbContext.Users.Add(user);
                    return true;
                }
                else
                    return false;
                
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
