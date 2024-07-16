using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Yetki.Entites
{
	public class UserType
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeId { get; set; }

		[Column(TypeName ="VARCHAR(50)")]
		public string TypeName { get; set; }

	}
}

