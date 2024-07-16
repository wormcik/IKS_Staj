using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Yetki.Entites
{
	public class RegistrationInfo
	{
        [Required]
        Guid? RegistrationUserCode { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        string? RegistrationUserName { get; set; }

        [Required]
        DateTime? RegistrationDate { get; set; }

        [Required]
        Guid? UpdateUserCode { get; set; }

        [Required]
        DateTime? UpdateDate { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        string? UpdateUserName { get; set; }

        [Required]
        Guid? ProcessCode { get; set; }
    }
}

