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
    [Index(nameof(Image))]
    [Index(nameof(Price))]
    [Index(nameof(IsPublished))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Product
    {
        public Product()
        {
            this.Price = 0;
            this.IsPublished = false;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("Category")]
        public long CategoryId { get; set; }
        public virtual CategoryProduct Category { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }

       
        [Column(TypeName = "varchar(191)")]
        public string Image { get; set; }

        public Decimal Price { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public Boolean IsPublished { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
