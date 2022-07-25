using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Index(nameof(Name))]
    [Index(nameof(Phone))]
    [Index(nameof(Email))]
    [Index(nameof(Website))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Contact
    {
        public Contact()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Website { get; set; }

        [Column(TypeName = "text")]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
