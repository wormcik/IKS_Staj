using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Models.DTO
{
	public class TalepModelDTO
	{
        public long SatinAlmaTalepKod { get; set; }

        public int SatinAlmaBirimKod { get; set; }

        //public int PersonelKod { get; set; }

        public DateTime TalepTarih { get; set; }

        public decimal OngorulenTutar { get; set; }

        public string? OngorulenTutarPbKod { get; set; }

        public string Aciklama { get; set; } = null!;

        public Guid TransactionId { get; set; }

        public int OnaySira { get; set; }

        public DateTime IslemTarih { get; set; }

        public List<TalepUrunModelDTO> TalepUrunListe { get; set; }

        public List<TalepHizmetModelDTO> TalepHizmetListe { get; set; }
    }
}

