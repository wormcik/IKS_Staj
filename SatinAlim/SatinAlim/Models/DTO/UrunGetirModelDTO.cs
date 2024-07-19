using System;
namespace SatinAlim.Models
{
	public class UrunGetirModelDTO
	{
        public int SatinAlmaUrunKod { get; set; }

        public string Tanim { get; set; } = null!;

        public string? Aciklama { get; set; }

        public string? Birim { get; set; }
    }
}

