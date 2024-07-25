using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Models
{
    public class TalepEkleSorguModel
    {

        public int SatinAlmaBirimKod { get; set; }
        public int SatinAlmaUrunKod{ get; set; }

        public decimal OngorulenTutar { get; set; }

     
        public string? OngorulenTutarPbKod { get; set; }

        public string Aciklama { get; set; } = null!;

        public int Miktar{ get; set; }

        public int BirimFiyat{ get; set; }

        public DateTime TalepTarih { get; set; }

        public List<TalepUrunSorguModel>? TalepUrunSorguModelListe { get; set; }

        public List<TalepHizmetSorguModel>? TalepHizmetSorguModelListe { get; set; }
    }
}

