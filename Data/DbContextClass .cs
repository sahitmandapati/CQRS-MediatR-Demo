using CQRS_MediatR_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR_Demo.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }

        public DbSet<StudentDetails> StudentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDetails>().HasKey(x => x.Id);
        }
    }
}
