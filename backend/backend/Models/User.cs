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
    [Index(nameof(CountryId))]
    [Index(nameof(Username))]
    [Index(nameof(Email))]
    [Index(nameof(Phone))]
    [Index(nameof(City))]
    [Index(nameof(ZipCode))]
    [Index(nameof(IsAdmin))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class User
    {
        public User()
        {
            this.IsAdmin = false;
            this.Status = false;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("Country")]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Email { get; set; }

        
        [Column(TypeName = "varchar(64)")]
        public string Phone { get; set; }

        [Column(TypeName = "text")]
        public string Address1 { get; set; }

        [Column(TypeName = "text")]
        public string Address2 { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string ZipCode { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string Password { get; set; }

        [Column(TypeName = "text")]
        public string Token { get; set; }

        public Boolean IsAdmin { get; set; }

        public Boolean Status { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<ArticleComment> ArticleComment { get; set; }

        public virtual ICollection<EmailVerification> EmailVerification { get; set; }

        public virtual ICollection<Notification> Notification { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
