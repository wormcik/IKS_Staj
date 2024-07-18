using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace SatinAlim.Entities
{
    public class SatinAlmaUrun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatinAlmaUrunKod { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string Tanim { get; set; }

        [Column(TypeName = "VARCHAR(2000)")]
        public string Aciklama { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string Birim { get; set; }

        public ICollection<SatinAlmaBirimUrun> SatinAlmaBirimUrun { get; set; }
    }
}
