using Microsoft.EntityFrameworkCore;
using WordWiz.Domain.Entities;
using WordWiz.Domain.Entities.Common;

namespace WordWiz.Infrastructure.Data.Context;

public class WordWizDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Word> Words { get; set; }

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