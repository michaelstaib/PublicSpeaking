using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class BookContext : DbContext
    {
        public BookContext()
        {
        }

        public BookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = default!;

        public DbSet<Author> Authors { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=uni.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Author>()
                .HasMany(t => t.Books)
                .WithOne(t => t.Author!)
                .HasForeignKey(t => t.AuthorId);

            modelBuilder
                .Entity<Book>()
                .HasOne(t => t.Author)
                .WithMany(t => t!.Books)
                .HasForeignKey(t => t.AuthorId);
        }
    }
}
