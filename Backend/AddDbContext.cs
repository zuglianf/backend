using Microsoft.EntityFrameworkCore;

public class AddDbContext : DbContext
{
    public DbSet<Request> Requests{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=Request.db");
    }
}

