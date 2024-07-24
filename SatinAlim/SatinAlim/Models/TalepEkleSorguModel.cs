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
        public int TalepPersonelKod { get; set; }

        //[Column(TypeName = "NUMERIC(18,2)")]
        public decimal OngorulenTutar { get; set; }

        //[Required]
        public string? OngorulenTutarPbKod { get; set; }

        //[Column(TypeName = "VARCHAR(8000)")]
        //[Required]
        public string Aciklama { get; set; } = null!;

        //[Required]
        public int OnaySira { get; set; }
    }
}

