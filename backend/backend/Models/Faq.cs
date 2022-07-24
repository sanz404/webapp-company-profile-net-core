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
    [Index(nameof(CategoryId))]
    [Index(nameof(Question))]
    [Index(nameof(Sort))]
    [Index(nameof(IsPublished))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Faq
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("Category")]
        public long CategoryId { get; set; }
        public virtual CategoryFaq Category { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Question { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Answer { get; set; }

        public int Sort { get; set; }

        public Boolean IsPublished { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
