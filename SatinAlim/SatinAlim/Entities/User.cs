using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SatinAlim.Entities
{
	public class User
	{

		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
		[Required]
		[Column(TypeName = "VARCHAR(50)")]
		public string Name{get;set;}
		[Required]
        [Column(TypeName = "VARCHAR(50)")]
		public string LastName { get; set; }

    }
}

