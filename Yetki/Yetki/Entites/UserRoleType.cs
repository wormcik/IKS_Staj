using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yetki.Entites
{
	public class UserRoleType
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserRoleTypeId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string UserTypeName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string UserRoleName { get; set; }
    }
}

