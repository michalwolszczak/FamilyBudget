using API.Data.Entities;

namespace API.Models
{
    public class BudgetDto
    {
        public decimal Limit { get; set; }
        public decimal Balance { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }

    }
}
