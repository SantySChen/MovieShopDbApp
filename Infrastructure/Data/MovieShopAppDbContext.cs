using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopAppDbContext : DbContext
    {
        public MovieShopAppDbContext(DbContextOptions<MovieShopAppDbContext> options):base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                .HasKey(f => new { f.MovieId, f.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(f => f.Genre)
                .WithMany(u => u.MovieGenres)
                .HasForeignKey(f => f.GenreId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(f => f.MovieId);

            modelBuilder.Entity<MovieCast>()
            .HasKey(mc => new { mc.MovieId, mc.CastId });

            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCasts)
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(mc => mc.CastId);

            modelBuilder.Entity<MovieCast>()
                .Property(mc => mc.Character)
                .IsRequired();

            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.UserId, f.MovieId });

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Favorites)
                .HasForeignKey(f => f.MovieId);

            modelBuilder.Entity<Review>()
            .HasKey(r => new { r.UserId, r.MovieId });

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Review>()
                .Property(r => r.CreateDate)
                .IsRequired();

            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .IsRequired();

            modelBuilder.Entity<Review>()
                .Property(r => r.ReviewText)
                .HasMaxLength(500);

            modelBuilder.Entity<Purchase>()
            .HasKey(p => new { p.UserId, p.MovieId });

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.User)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Movie)
                .WithMany(m => m.Purchases)
                .HasForeignKey(p => p.MovieId);

            modelBuilder.Entity<Purchase>()
                .Property(p => p.PurchaseDateTime)
                .IsRequired();

            modelBuilder.Entity<Purchase>()
                .Property(p => p.PurchaseNumber)
                .IsRequired();

            modelBuilder.Entity<Purchase>()
                .Property(p => p.TotalPrice)
                .IsRequired();
        }
    


    }
}
