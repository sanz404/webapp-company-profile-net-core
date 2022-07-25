using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Index(nameof(Code))]
    [Index(nameof(Name))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Country
    {
        public Country()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
