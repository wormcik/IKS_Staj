using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace SatinAlim.Entities
{
	public class SatinAlmaTalepUrun
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long SatinAlmaTalepUrunKod { get; set; }

		[ForeignKey("SatinAlmaTalep")]
		public long SatinAlmaTalepKod { get; set; }

        [Column(TypeName = "NUMERIC(18,2)")]
		public decimal Miktar { get; set; }

		[Column(TypeName = "VARCHAR(10)")]

		public string? PbKod { get; set; }

        [Column(TypeName = "NUMERIC(18,2)")]
		public decimal BirimFiyat { get; set; }

		public SatinAlmaTalep? SatinAlmaTalep { get; set; }
    }
}

