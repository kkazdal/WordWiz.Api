using Microsoft.EntityFrameworkCore;
using WordWiz.Domain.Entities;
using WordWiz.Domain.Entities.Common;

namespace WordWiz.Infrastructure.Data.Context;

public class WordWizDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<User> Users { get; set; }

    public WordWizDbContext(DbContextOptions<WordWizDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<Question>()
            .HasOne(q => q.Category)
            .WithMany(c => c.Questions)
            .HasForeignKey(q => q.CategoryId);

        modelBuilder.Entity<Question>()
            .Property(q => q.Choices)
            .HasColumnType("jsonb");

        base.OnModelCreating(modelBuilder);
    }

} 