using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yetki.Entites
{
    public class UserRole
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserRoleId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string RoleName { get; set; }
    }
}

