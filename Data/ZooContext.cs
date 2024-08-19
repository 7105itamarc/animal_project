using _1907FirstWebAppAtempt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Collections.Generic;

namespace _1907FirstWebAppAtempt.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new Animal() { AnimalId = 1, Name = "Eli", Age = 1, Description = "ElephentElephentElephent", CategoryId = 1, PictureName = "/AnimalsPic/elephant.png" },
                new Animal() { AnimalId = 2, Name = "catly", Age = 2, Description = "cat", CategoryId = 1, PictureName = "/AnimalsPic/cat.png"},
                new Animal() { AnimalId = 3, Name = "nake", Age = 2, Description = "snake", CategoryId = 2, PictureName = "/AnimalsPic/snake.png" });


            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Mammales" },
                new Category() { CategoryId = 2, CategoryName = "Reptiles" });

            modelBuilder.Entity<Comment>().HasData(
                new Comment() { CommentId = 1, CategoryId = 1, AnimalId = 1, CommentDetails = "very fat elephent" },
                new Comment() { CommentId = 2, CategoryId = 1, AnimalId = 1, CommentDetails = "very shy elephent" },
                new Comment() { CommentId = 3, CategoryId = 1, AnimalId = 2, CommentDetails = "i'm a cat give me food" },
                new Comment() { CommentId = 4, CategoryId = 2, AnimalId = 3, CommentDetails = "i'm a snakkke" });

        }
    }
}
