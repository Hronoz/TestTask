using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Context
{
    public class TaskDbContext : DbContext
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<Record> Records { get; set; } = null!;
        public DbSet<Result> Results { get; set; } = null!;
    }
}