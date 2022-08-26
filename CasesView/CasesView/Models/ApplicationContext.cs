using Microsoft.EntityFrameworkCore;

namespace CasesView.Models;

public class ApplicationContext : DbContext
{
    public DbSet<Case> CaseForCases { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // создаем базу данных при первом обращении
    }

}
