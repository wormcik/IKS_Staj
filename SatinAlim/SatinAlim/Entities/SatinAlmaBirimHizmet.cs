using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Entities
{
	public class SatinAlmaBirimHizmet
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatinAlmaBirimHizmetKod { get; set; }

        [ForeignKey("SatinAlmaBirim")]
        public int SatinAlmaBirim { get; set; }

        [ForeignKey("SatinAlmaHizmet")]
        public int SatinAlmaHizmetKod { get; set; }

        public SatinAlmaBirim? SatınAlmaBirim { get; set; }

        public SatinAlmaHizmet? SatinAlmaHizmet { get; set; }
        
    }
}

