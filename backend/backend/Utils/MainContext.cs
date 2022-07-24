using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Utils
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<About> About { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleComment> ArticleComment { get; set; }
        public DbSet<CategoryArticle> CategoryArticle { get; set; }
        public DbSet<CategoryFaq> CategoryFaq { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }
        public DbSet<CategoryProject> CategoryProject { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Content> Content { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<EmailVerification> EmailVerification { get; set; }
        public DbSet<Faq> Faq { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<User> User { get; set; }
    }
}
