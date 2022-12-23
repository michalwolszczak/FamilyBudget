using API.Data;
using API.Data.Entities;

namespace API
{
    public class CategoriesSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoriesSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.ExpenseCategories.Any())
                {
                    var values = GetExpenseCategories();
                    _dbContext.ExpenseCategories.AddRange(values);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.IncomeCategories.Any())
                {
                    var values = GetIncomeCategories();
                    _dbContext.IncomeCategories.AddRange(values);
                    _dbContext.SaveChanges();
                }

            }
        }

        private List<ExpenseCategory> GetExpenseCategories()
        {
            return new List<ExpenseCategory>
            {
                new ExpenseCategory() { Name = "Miscellaneous" },
                new ExpenseCategory() { Name = "Education" },
                new ExpenseCategory() { Name = "Entertainment" },
                new ExpenseCategory() { Name = "Shopping" },
                new ExpenseCategory() { Name = "Personal Care" }           
            };
        }

        private List<IncomeCategory> GetIncomeCategories()
        {
            return new List<IncomeCategory>
            {
                new IncomeCategory() { Name = "Paycheck" },
                new IncomeCategory() { Name = "Investment" },
                new IncomeCategory() { Name = "Returned Purchase" },
                new IncomeCategory() { Name = "Reimbursement" },
                new IncomeCategory() { Name = "Rental Income" }           
            };
        }
    }
}
