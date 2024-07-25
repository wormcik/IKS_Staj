using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

namespace SatinAlim.Entities
{
    public class SatinAlmaBirimOnayci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatinAlmaBirimOnayciKod { get; set; }

        [ForeignKey("SatinAlmaBirim")]
        [Required]
        public int SatinAlmaBirimKod { get; set; }

        [ForeignKey("Personel")]
        [Required]
        public int PersonelKod { get; set; }

        [Required]
        public int OnaySira { get; set; } 

        [Required]
        public bool Sureli { get; set; } 

        public DateTime BaslangicTarih { get; set; }

        public DateTime BitisTarih { get; set; }

        [JsonIgnore]
        public  Personel Personel { get; set; }

        [JsonIgnore]
        public  SatinAlmaBirim SatinAlmaBirim { get; set; }
    }
}


