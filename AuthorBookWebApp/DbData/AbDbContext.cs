using AuthorBookWebApp.DbData.DbModel;
using Microsoft.EntityFrameworkCore;
using AuthorBookWebApp.Models;

namespace AuthorBookWebApp.DbData
{
    public class AbDbContext : DbContext
    {
        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<BookDbModel> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDbModel>().HasOne(x => x.authorDbModel).WithMany(x => x.Books);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=AuthorBookWebAppDb;Trusted_Connection=True;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<AuthorBookWebApp.Models.AuthorViewModel> AuthorViewModel { get; set; }
        public DbSet<AuthorBookWebApp.Models.BookViewModel> BookViewModel { get; set; }

    }
}
