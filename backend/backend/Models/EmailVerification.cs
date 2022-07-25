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
    [Index(nameof(Code))]
    [Index(nameof(Token))]
    [Index(nameof(EmailConfirmed))]
    [Index(nameof(IsExpired))]
    [Index(nameof(ExpiredAt))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class EmailVerification
    {
        public EmailVerification()
        {
            this.EmailConfirmed = false;
            this.IsExpired = false;
            this.ExpiredAt = DateTime.Now;
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
        [Column(TypeName = "varchar(191)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Token { get; set; }

        public Boolean EmailConfirmed { get; set; }

        public Boolean IsExpired { get; set; }

        public DateTime ExpiredAt { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
