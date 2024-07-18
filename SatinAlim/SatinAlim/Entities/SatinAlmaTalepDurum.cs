using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Entities
{
	public class SatinAlmaTalepDurum
	{
		[Key]
        [Column(TypeName = "VARCHAR(20)")]
        public int SatinAlmaTalepDurumKod { get; set; }

    }
}

