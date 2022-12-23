namespace API.Data.Entities
{
    public class BudgetUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
    }
}
