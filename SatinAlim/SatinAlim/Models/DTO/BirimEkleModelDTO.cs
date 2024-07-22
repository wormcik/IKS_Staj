using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Models.DTO
{
	public class BirimEkleModelDTO
	{
        public string? BirimAd { get; set; }

        public int OnaySayi { get; set; }
    }
}

