using Microsoft.EntityFrameworkCore;

namespace Demo.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Publication> Publications { get; set; } = default!;

    public DbSet<Author> Authors { get; set; } = default!;

    public DbSet<Reader> Readers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Author>()
            .HasMany(t => t.Books)
            .WithOne(t => t.Author!)
            .HasForeignKey(t => t.AuthorId);

        modelBuilder
            .Entity<Reader>()
            .HasMany(t => t.EBooks)
            .WithOne(t => t!.Reader)
            .HasForeignKey(t => t.ReaderId);

        modelBuilder
            .Entity<Book>()
            .HasOne(t => t.Author)
            .WithMany(t => t.Books)
            .HasForeignKey(t => t.AuthorId);

        modelBuilder
            .Entity<Magazine>()
            .HasOne(t => t.Author)
            .WithMany(t => t.Magazines)
            .HasForeignKey(t => t.AuthorId);

        modelBuilder
            .Entity<Paper>()
            .HasOne(t => t.Author)
            .WithMany(t => t!.Papers)
            .HasForeignKey(t => t.AuthorId);

        modelBuilder
            .Entity<Ebook>()
            .HasOne(t => t.Author)
            .WithMany(t => t!.EBooks)
            .HasForeignKey(t => t.AuthorId);

        modelBuilder
            .Entity<Ebook>()
            .HasOne(t => t.Reader)
            .WithMany(t => t!.EBooks)
            .HasForeignKey(t => t.ReaderId);

        modelBuilder.Entity<Publication>()
            .HasDiscriminator<string>("publication_type")
            .HasValue<Book>(nameof(Book))
            .HasValue<Magazine>(nameof(Magazine))
            .HasValue<Paper>(nameof(Paper))
            .HasValue<Ebook>(nameof(Ebook));
    }
}