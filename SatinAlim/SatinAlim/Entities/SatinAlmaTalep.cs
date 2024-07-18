using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Xml;

namespace SatinAlim.Entities
{
    public class SatinAlmaTalep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long SatinAlmaTalepKod { get; set; }

        [ForeignKey("SatinAlmaBirim")]
        [Required]
        public int SatinAlmaBirimKod { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [ForeignKey("SatinAlmaTalepDurum")]
        [Required]
        public string SatinalmaTalepDurumKod { get; set; } = null!;

        [ForeignKey("Personel")]
        [Required]
        public int TalepPersonelKod { get; set; }

        [Required]
        public DateTime TalepTarih { get; set; }

        [Column(TypeName = "NUMERIC(18,2)")]
        [Required]
        public decimal OngorulenTutar;

        [Required]
        public string? OngorulenTutarPbKod { get; set; }

        [Column(TypeName = "VARCHAR(8000)")]
        [Required]
        public string Aciklama { get; set; } = null!;

        [Required]
        public Guid TransactionId { get; set; }

        [Required]
        public int OnaySira { get; set; }

        [Required]
        public DateTime IslemTarih { get; set; }

        [JsonIgnore]
        public SatinAlmaBirim SatinAlmaBirim { get; set; }
        [JsonIgnore]
        public SatinAlmaTalepDurum SatinAlmaTalepDurum { get; set; }
        [JsonIgnore]
        public Personel Personel { get; set; }

        public ICollection<SatinAlmaTalepTarihce>? SatinAlmaTalepTarihce { get; set; }
        public ICollection<SatinAlmaTalepHizmet>? SatinAlmaTalepHizmet { get; set; }

    }
}

