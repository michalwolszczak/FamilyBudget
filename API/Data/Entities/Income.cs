namespace API.Data.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
    }
}