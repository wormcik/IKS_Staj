using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Yetki.Entites
{
	public class RegistrationInfo
	{
        public Guid? RegistrationUserCode { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? RegistrationUserName { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
        public Guid? UpdateUserCode { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? UpdateUserName { get; set; }
        
        public Guid? ProcessCode { get; set; }
    } 
}

