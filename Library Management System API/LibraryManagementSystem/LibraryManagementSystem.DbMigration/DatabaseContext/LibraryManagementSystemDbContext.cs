using LibraryManagementSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DbMigration.DatabaseContext
{
    public class LibraryManagementSystemDbContext : IdentityDbContext<Member, IdentityRole, string>
    {
        public LibraryManagementSystemDbContext()
        {
            
        }

        public LibraryManagementSystemDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowdBook> BorrowdBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = DESKTOP-O1NBMET; 
                                        Initial Catalog = LibraryManagementSystemDb; 
                                        Integrated Security = True; 
                                        TrustServerCertificate = True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}