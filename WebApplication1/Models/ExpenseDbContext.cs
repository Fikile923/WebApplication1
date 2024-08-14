using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ExpenseDbContext : DbContext 
    {
        public DbSet<Expense> Expenses { get; set; }    

        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) //To injext information to the database
            : base(options) 
        {
        
        }
    }
}
