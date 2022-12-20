using Database.Data.Entities;

namespace Database.Models
{
    public class BudgetDto
    {
        public decimal Limit { get; set; }
        public decimal Balance { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }

    }
}
