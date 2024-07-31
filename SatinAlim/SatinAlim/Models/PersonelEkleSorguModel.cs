namespace SatinAlim.Models
{
    public class PersonelEkleSorguModel
    {
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Pozisyon { get; set; }
        public Guid KullaniciKod { get; set; }
        public int SatinAlmaBirimKod { get; set; }
    }
}
