using System;
namespace SatinAlim.Models
{
	public class UrunGuncelleSorguModel
	{
        public int SatinAlmaUrunKod { get; set; }

        public string Tanim { get; set; }

        public string? Aciklama { get; set; }

        public string? Birim { get; set; }
    }
}

