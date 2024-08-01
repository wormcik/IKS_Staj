using System;
namespace SatinAlim.Models.DTO
{
	public class BirimUrunModelDTO
	{
        public int SatinAlmaBirimKod { get; set; }

        public string? BirimAd { get; set; }




        public int SatinAlmaUrunKod { get; set; }

        public string Tanim { get; set; } = null!;

        public string? Aciklama { get; set; }

        public string? Birim { get; set; }
    }
}

