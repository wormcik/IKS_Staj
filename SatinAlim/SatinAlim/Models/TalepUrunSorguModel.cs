using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Models
{
	public class TalepUrunSorguModel
	{
        [ForeignKey("SatinAlmaTalep")]
        [Required]
        public long SatinAlmaTalepKod { get; set; }
        [ForeignKey("SatinAlmaUrun")]
        [Required]
        public int SatinAlmaUrunKod { get; set; }

        public decimal Miktar { get; set; }//

        public string? PbKod { get; set; }//

        public decimal BirimFiyat { get; set; }//
    }
}

