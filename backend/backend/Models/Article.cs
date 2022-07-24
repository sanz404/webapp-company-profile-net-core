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
    [Index(nameof(Image))]
    [Index(nameof(Slug))]
    [Index(nameof(Title))]
    [Index(nameof(IsPublished))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Image { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Slug { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; }

        public virtual ICollection<CategoryArticle> Categories { get; set; }

        public Boolean IsPublished { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
