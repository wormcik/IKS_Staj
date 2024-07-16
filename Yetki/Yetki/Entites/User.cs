using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Yetki.Entites
{
	
	public class User : RegistrationInfo

    {
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Required]
		[Column(TypeName = "VARCHAR(50)")]
		public string Name { get; set; }

        
		[Column(TypeName = "VARCHAR(50)")]
		public string LastName { get; set; }

		[Required]
        [Column(TypeName = "VARCHAR(50)")]
		public string Username { get; set; }

		[Required]
        [Column(TypeName = "VARCHAR(200)")]
		public string Password { get; set; }


		public string UserType { get; set; }

		public bool Removed { get; set; } = false;
    }
}

