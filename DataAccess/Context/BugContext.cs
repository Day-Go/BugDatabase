using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataAccess.Entities;

namespace DataAccess.Context;


public class BugContext : DbContext
{

    public BugContext()
    {

    }

    public BugContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Bug> Bug { get; set; }
    public DbSet<Comment> Comment { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=BugDB;Trusted_Connection=True;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}