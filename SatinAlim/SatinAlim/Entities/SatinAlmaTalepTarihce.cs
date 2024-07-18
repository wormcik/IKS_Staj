using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SatinAlim.Entities
{
	public class SatinAlmaTalepTarihce
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SatinAlmaTalepTarihceKod { get; set; }

        [ForeignKey("SatinAlmaTalep")]
        [Required]
        public long SatinAlmaTalepKod { get; set; }

        [ForeignKey("Personel")]
        [Required]
        public int PersonelKod { get; set; }

        [ForeignKey("SatinAlmaTalepDurum")]
        [Column(TypeName ="VARCHAR(20)")]
        [Required]
        public string? SatinAlmaTalepDurumKod { get; set; }

        [Required]
        public int OnaySira { get; set; }

        [Column(TypeName = "VARCHAR(2000)")]
        [Required]
        public string? Aciklama { get; set; }

        [Required]
        public DateTime IslemTarih { get; set; }

        [JsonIgnore]
        public SatinAlmaTalepDurum SatinAlmaTalepDurum { get; set; }

        [JsonIgnore]
        public SatinAlmaTalep SatinAlmaTalep { get; set; }

        [JsonIgnore]
        public Personel Personel { get; set; }
    }
}

