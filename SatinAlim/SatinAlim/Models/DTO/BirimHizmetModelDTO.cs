using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Models.DTO
{
	public class BirimHizmetModelDTO
    { 
        public int SatinAlmaBirimKod { get; set; }

        public string BirimAd { get; set; } = null!;

        public int OnaySayi { get; set; }


        public int SatinAlmaHizmetKod { get; set; }

        public string Tanim { get; set; } = null!;

        public string? Aciklama { get; set; }

        public string? Birim { get; set; }
    }
}

