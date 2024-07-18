using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SatinAlim.Entities
{
    public class SatinAlmaHizmet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatinAlmaHizmetKod { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string Tanim { get; set; }

        [Column(TypeName = "VARCHAR(2000)")]
        public string Aciklama { get; set; }

        [Column(TypeName = "VARCHAR(20")]
        public string Birim { get; set; }

        public ICollection<SatinAlmaBirimHizmet>? SatinAlmaBirimHizmet { get; set; }

    }
}
