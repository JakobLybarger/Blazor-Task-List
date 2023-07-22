using System;
using Microsoft.EntityFrameworkCore;
using TaskList.Shared;

namespace TaskList.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add some starting data to the database
            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = 1,
                    Title = "First Todo",
                    Description = "First Todo Description",
                    DueDate = new DateTime(2023, 7, 20),
                    Status = "Not Completed",
                    Priority = "Low"
                },
                new Todo
                {
                    Id = 2,
                    Title = "Second Todo",
                    Description = "Second Todo Description",
                    DueDate = new DateTime(2023, 7, 29),
                    Status = "Not Completed",
                    Priority = "Medium"
                },
                new Todo
                {
                    Id = 3,
                    Title = "Third Todo",
                    Description = "Third Todo Description",
                    DueDate = new DateTime(2023, 7, 20),
                    Status = "Not Completed",
                    Priority = "High"
                }
            );
        }

        public DbSet<Todo> Todos { get; set; }
    }
}

