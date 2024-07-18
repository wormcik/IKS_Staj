using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;

namespace SatinAlim.Entities
{
	public class SatinAlmaTalepUrun
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long SatinAlmaTalepUrunKod { get; set; }

		[ForeignKey("SatinAlmaTalep")]
        [Required]
        public long SatinAlmaTalepKod { get; set; }

        [Column(TypeName = "NUMERIC(18,2)")]
        [Required]
        public decimal Miktar { get; set; }

		[Column(TypeName = "VARCHAR(10)")]
        [Required]
        public string? PbKod { get; set; }

        [Column(TypeName = "NUMERIC(18,2)")]
        [Required]
        public decimal BirimFiyat { get; set; }

        [JsonIgnore]
        public SatinAlmaTalep SatinAlmaTalep { get; set; }
    }
}

