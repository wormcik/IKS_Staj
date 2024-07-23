namespace SatinAlim.Models.DTO
{
    public class HizmetListeleModelDTO
    {
        public int SatinAlmaHizmetKod { get; set; }

        public string Tanim { get; set; } = null!;

        public string? Aciklama { get; set; }

        public string? Birim { get; set; }
    }
}
