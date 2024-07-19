using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SatinAlim.Models
{
	public class UrunEkleModelDTO
	{
        public int SatinAlmaUrunKod { get; set; }

        public string Tanim { get; set; } = null!;

        public string? Aciklama { get; set; }

        public string? Birim { get; set; }

    }
}

