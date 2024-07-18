using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SatinAlim.Entities
{

    public class SatinAlmaBirimPersonel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SatınAlmaBirimPersonelKod { get; set; }

        [ForeignKey("SatınAlmaBirim")]
        public int SatinAlmaBirimKod { get; set; }

        [ForeignKey("Personel")]

        public int PersonelKod { get; set; }


        [JsonIgnore]
        public Personel? Personel { get; set; }

        [JsonIgnore]
        public SatinAlmaBirim? SatınAlmaBirim { get; set; }


    }


