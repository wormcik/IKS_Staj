using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SatinAlim.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SatinAlim.Models.DTO
{
	public class TalepUrunModelDTO
	{
        public long SatinAlmaTalepUrunKod { get; set; }

        public int SatinAlmaUrunKod { get; set; }

        public decimal Miktar { get; set; }

        public string? PbKod { get; set; }

        public decimal BirimFiyat { get; set; }

    }
}

