using BackUpSystem.Data.Models;
using BlogSystem.Data.Models.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BackUpSystem.Data
{
    public class BackUpSystemDbContext : IdentityDbContext<User>
    {
        public BackUpSystemDbContext(DbContextOptions<BackUpSystemDbContext> options)
            : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<TweetHashtag> TweetHashtags { get; set; }
        public DbSet<TwitterAccount> TwitterAccounts { get; set; }
        public DbSet<UserTweet> UserTweets { get; set; }
        public DbSet<UserTwitterAccount> UserTwitterAccounts { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuring many to many realationship between User and TwitterAccount tables
            builder.Entity<UserTwitterAccount>()
                .HasOne(u => u.User)
                .WithMany(t => t.TwitterAccounts)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserTwitterAccount>()
                .HasOne(t => t.TwitterAccount)
                .WithMany(u => u.Users)
                .HasForeignKey(t => t.TwitterAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserTwitterAccount>()
              .HasKey(ut => new { ut.UserId, ut.TwitterAccountId });

            // Configuring many to many realationship between User and Tweet tables
            builder.Entity<UserTweet>()
                .HasOne(u => u.User)
                .WithMany(t => t.FavoriteTweets)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserTweet>()
                .HasOne(t => t.Tweet)
                .WithMany(u => u.Users)
                .HasForeignKey(t => t.TweetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserTweet>()
              .HasKey(ut => new { ut.UserId, ut.TweetId });

            // Configuring many to many realationship between Hashtag and Tweet tables
            builder.Entity<TweetHashtag>()
                .HasOne(u => u.Tweet)
                .WithMany(t => t.Hashtags)
                .HasForeignKey(u => u.TweetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TweetHashtag>()
                .HasOne(t => t.Hashtag)
                .WithMany(u => u.Tweets)
                .HasForeignKey(t => t.HashtagId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TweetHashtag>()
              .HasKey(ut => new { ut.TweetId, ut.HashtagId });

            // Configuring one to many relationship between a TwitterAccount and Tweet tables
            builder.Entity<TwitterAccount>()
                .HasMany(t => t.Tweets)
                .WithOne(t => t.TwitterAccount)
                .HasForeignKey(t => t.TwitterAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Making sure each UserName in User table is unique
            builder.Entity<User>()
                .HasIndex(x => x.UserName)
                .IsUnique(true);

            // Making sure each UserName in TwitterAccount is unique
            builder.Entity<TwitterAccount>()
               .HasIndex(x => x.UserName)
               .IsUnique(true);

            base.OnModelCreating(builder);
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
