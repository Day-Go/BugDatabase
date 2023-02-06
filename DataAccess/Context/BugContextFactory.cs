using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;


public class BugContextFactory
{
    public class ReportContextFactory : IDesignTimeDbContextFactory<BugContext>
    {
        public BugContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BugContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=BugDB;Trusted_Connection=True;Encrypt=False;");

            return new BugContext(optionsBuilder.Options);
        }
    }
}
