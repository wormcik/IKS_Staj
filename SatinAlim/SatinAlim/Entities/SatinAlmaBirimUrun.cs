using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SatinAlim.Entities
{
	public class SatinAlmaBirimUrun
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatinAlmaBirimUrunKod { get; set; }

        [ForeignKey("SatinAlmaBirim")]
        [Required]
        public int SatinAlmaBirimKod { get; set; }

        [ForeignKey("SatinAlmaUrun")]
        [Required]
        public int SatinAlmaUrunKod { get; set; }

        [JsonIgnore]
        public SatinAlmaBirim SatinAlmaBirim { get; set; }

        [JsonIgnore]
        public SatinAlmaUrun SatinAlmaUrun { get; set; }
    }
}

