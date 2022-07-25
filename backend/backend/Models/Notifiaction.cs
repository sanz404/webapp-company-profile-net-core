using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Index(nameof(UserId))]
    [Index(nameof(Subject))]
    [Index(nameof(SortContent))]
    [Index(nameof(ReadedAt))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Notification
    {
        public Notification()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Subject { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string SortContent { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string FullContent { get; set; }

        public DateTime ReadedAt { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
