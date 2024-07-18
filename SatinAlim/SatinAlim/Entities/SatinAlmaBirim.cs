using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace SatinAlim.Entities
{
	public class SatinAlmaBirim
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SatinAlmaBirimKod { get; set; }

		[Required]
		[Column(TypeName = "VARCHAR(200)")]
		public string BirimAd { get; set; } = null!;

		[Required]
		public int OnaySayi { get; set; }

        public ICollection<SatinAlmaBirimOnayci>? SatinAlmaBirimOnaycilar { get; set; }
        public ICollection<SatinAlmaBirimPersonel>? SatinAlmaBirimPersonel { get; set; }
		public ICollection<SatinAlmaBirimHizmet>? SatinAlmaBirimHizmet { get; set; }
		public ICollection<SatinAlmaBirimUrun>? SatinAlmaBirimUrun { get; set; }
		public ICollection<SatinAlmaTalep>? SatinAlmaTalep { get; set; }

    }
}

