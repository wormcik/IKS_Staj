using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace SatinAlim.Entities
{
    public class SatinAlmaTalepHizmet
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SatinAlmaHizmetKod { get; set; }

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

        public  SatinAlmaTalep SatinAlmaTalep { get; set; }



    }
}
