using Database.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS;Database=FamilyBudgetDb;Trusted_Connection=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
