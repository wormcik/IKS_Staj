using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Models.DTO
{
	public class TalepHizmetModelDTO
	{
        public long SatinAlmaTalepHizmetKod { get; set; }

        public int SatinAlmaHizmetKod { get; set; }

        public decimal Miktar { get; set; }

        public string? PbKod { get; set; }

        public decimal BirimFiyat { get; set; }
    }
}

