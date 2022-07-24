﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Index(nameof(Icon))]
    [Index(nameof(Title))]
    [Index(nameof(IsPublished))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Feature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [Column(TypeName = "varchar(64)")]
        public string Icon { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Title { get; set; }


        [Column(TypeName = "text")]
        public string Description { get; set; }

        public Boolean IsPublished { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
