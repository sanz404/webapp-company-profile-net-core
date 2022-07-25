using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Index(nameof(FullName))]
    [Index(nameof(Email))]
    [Index(nameof(Phone))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Message
    {
        public Message()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
