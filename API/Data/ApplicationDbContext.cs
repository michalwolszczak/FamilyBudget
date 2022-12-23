using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS;Database=FamilyBudgetDb;Trusted_Connection=True;Encrypt=False";
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Creator)
                .WithMany(u => u.Budgets);

            modelBuilder.Entity<Budget>()
                .HasMany(b => b.BudgetUsers)
                .WithOne(bu => bu.Budget)
                .HasForeignKey(bu => bu.BudgetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.BudgetUsers)
                .WithOne(bu => bu.User)
                .HasForeignKey(bu => bu.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BudgetUser>()
                .HasKey(bu => new { bu.BudgetId, bu.UserId });

            modelBuilder.Entity<BudgetUser>()
                .HasOne(bu => bu.Budget)
                .WithMany(b => b.BudgetUsers)
                .HasForeignKey(bu => bu.BudgetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BudgetUser>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.BudgetUsers)
                .HasForeignKey(bu => bu.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
