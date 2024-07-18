using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SatinAlim.Entities
{
	public class SatinAlmaBirimHizmet
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatinAlmaBirimHizmetKod { get; set; }

        [ForeignKey("SatinAlmaBirim")]
        public int SatinAlmaBirimKod { get; set; }

        [ForeignKey("SatinAlmaHizmet")]
        public int SatinAlmaHizmetKod { get; set; }
        [JsonIgnore]
        public SatinAlmaBirim? SatınAlmaBirim { get; set; }
        [JsonIgnore]
        public SatinAlmaHizmet? SatinAlmaHizmet { get; set; }

        
    }
}

