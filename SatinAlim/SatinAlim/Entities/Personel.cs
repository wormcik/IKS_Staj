﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Entities
{
	public class Personel
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonelKod { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Ad { get; set; } = null!;

        [Required]
        [Column(TypeName = "VARCHAR(100)")] 
        public string Soyad { get; set; } = null!;

        [Column(TypeName = "VARCHAR(100)")]
        public string? Pozisyon { get; set; }

        public ICollection<SatinAlmaBirimOnayci>? SatinAlmaBirimOnaycilar { get; set; }
    }
}

