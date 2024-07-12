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
		
		[Column(TypeName = "VARCHAR(1000)")]
		public string Name{get;set;}

        [Column(TypeName = "VARCHAR(1000)")]
		public string LastName { get; set; }

    }
}

