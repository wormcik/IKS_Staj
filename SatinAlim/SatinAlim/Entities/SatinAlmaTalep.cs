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
        public int SatinAlmaBirimKod { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [ForeignKey("SatinAlmaTalepDurum")]
        public string SatinalmaTalepDurumKod { get; set; } = null!;

        [ForeignKey("Personel")]
        public int TalepPersonelKod { get; set; }

        public DateTime TalepTarih { get; set; }

        [Column(TypeName = "NUMERIC(18,2)")]
        public decimal OngorulenTutar;

        public string? OngorulenTutarPbKod { get; set; }

        [Column(TypeName = "VARCHAR(8000)")]
        public string Aciklama { get; set; } = null!;

        public Guid TransactionId { get; set; }

        public int OnaySira { get; set; }

        public DateTime IslemTarih { get; set; }

        [JsonIgnore]
        public SatinAlmaBirim? SatinAlmaBirim { get; set; }
        [JsonIgnore]
        public SatinAlmaTalepDurum? SatinAlmaTalepDurum { get; set; }
        [JsonIgnore]
        public Personel? Personel { get; set; }

        public ICollection<SatinAlmaTalepTarihce>? SatinAlmaTalepTarihce { get; set; }
        public ICollection<SatinAlmaTalepHizmet>? SatinAlmaTalepHizmet { get; set; }

    }
}

