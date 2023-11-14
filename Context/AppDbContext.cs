using Ecc.Integration.Response;
using Ecc.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecc.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<LocationModel> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasKey(u => u.Id);
            modelBuilder.Entity<UserModel>().Property(u => u.Id).HasDefaultValueSql("uuid_generate_v4()");


            modelBuilder.Entity<AuthorModel>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<AuthorModel>().Property(a => a.AuthorId).HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<BookModel>().HasKey(c => c.BookId);
            modelBuilder.Entity<BookModel>().Property(a => a.BookId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<BookModel>().Property(a => a.PublishDate).HasDefaultValueSql("now()");

            modelBuilder.Entity<CategoryModel>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<CategoryModel>().Property(a => a.CategoryId).HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<LocationModel>().HasKey(c => c.LocationId);
            modelBuilder.Entity<LocationModel>().Property(c => c.LocationId).HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<BookModel>()
                .HasOne(b => b.CategoryModel)
                .WithMany()
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BookModel>()
                .HasOne(b => b.AuthorModel)
                .WithMany()
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<UserModel>()
            .HasOne(u => u.LocationModel)
            .WithMany().HasForeignKey(u => u.LocationId);
        }
    }
}
