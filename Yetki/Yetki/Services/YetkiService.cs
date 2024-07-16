namespace Yetki.Services
{
    public class YetkiService
    {
        public async Task<bool> SignUpAsync()
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
