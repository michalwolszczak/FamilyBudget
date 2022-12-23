namespace API.Data.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}