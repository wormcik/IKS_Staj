using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Models
{
    public class TalepEkleSorguModel
    {
        /*[ForeignKey("SatinAlmaBirim")]
        [Required]*/
        public int SatinAlmaBirimKod { get; set; }

        /*[ForeignKey("Personel")]
        [Required]*/
        //public int TalepPersonelKod { get; set; }

        public int SatinAlmaUrunKod{ get; set; }

        //[Column(TypeName = "NUMERIC(18,2)")]
        public decimal OngorulenTutar { get; set; }

        //[Required]
        public string? OngorulenTutarPbKod { get; set; }

        //[Column(TypeName = "VARCHAR(8000)")]
        //[Required]
        public string Aciklama { get; set; } = null!;

        //[Required]
        public int OnaySira { get; set; }

        public int Miktar{ get; set; }

        public int BirimFiyat{ get; set; }

        public DateTime TalepTarih { get; set; }

        public List<TalepUrunSorguModel> TalepUrunSorguModelListe { get; set; }

        public List<TalepHizmetSorguModel> TalepHizmetSorguModelListe { get; set; }
    }
}

