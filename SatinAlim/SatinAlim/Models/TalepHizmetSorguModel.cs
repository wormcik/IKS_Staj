using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SatinAlim.Entities;

namespace SatinAlim.Models
{
	public class TalepHizmetSorguModel
	{
        public int SatinAlmaBirimKod { get; set; }
        public int SatinAlmaHizmetKod { get; set; }


        public decimal Miktar { get; set; }

        public string? PbKod { get; set; }

        public decimal BirimFiyat { get; set; }

    }
}

