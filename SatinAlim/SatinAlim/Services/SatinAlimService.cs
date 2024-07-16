namespace SatinAlim.Services
{
    public class SatinAlimService
    {
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
    }
}
