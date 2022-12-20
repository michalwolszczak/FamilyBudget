namespace Database.Data.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal Limit { get; set; }
        public decimal Balance { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
