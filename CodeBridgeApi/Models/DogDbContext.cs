using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CodeBridgeApi.Models
{
    
    public class DogDbContext : DbContext
    {
        public DogDbContext(DbContextOptions<DogDbContext> options)
                : base(options)
        {
        }
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Dog>().HasData(
                new Dog
                {
                    Name = "Neo",
                    Color = "red & amber",
                    Tail_Length = "22",
                    Weight = "32"

                });

            modelBuilder.Entity<Dog>().HasData(
                new Dog
                {
                    Name = "Jessy",
                    Color = "black & white",
                    Tail_Length = "7",
                    Weight = "14"

                });
        }
    }
}
