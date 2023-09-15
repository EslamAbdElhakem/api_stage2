using Microsoft.EntityFrameworkCore;

namespace api_stage2.Models;

public class stageContext : DbContext
{
    public stageContext(DbContextOptions<stageContext> options)
        : base(options)
    {
    }

    public DbSet<stageItem> TodoItems { get; set; } = null!;
}


 

    