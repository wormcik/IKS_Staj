using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SatinAlim.Entities
{

    public class SatinAlmaBirimPersonel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatinAlmaBirimPersonelKod { get; set; }

        [ForeignKey("SatinAlmaBirim")]
        [Required]
        public int SatinAlmaBirimKod { get; set; }

        [ForeignKey("Personel")]
        [Required]
        public int PersonelKod { get; set; }


        [JsonIgnore]
        public Personel Personel { get; set; }

        [JsonIgnore]
        public SatinAlmaBirim SatinAlmaBirim { get; set; }


    }
}


