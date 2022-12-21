using AutoMapper;
using Database.Data;
using Database.Data.Entities;
using Database.Models;

namespace Database.Repository
{
    public interface IBudgetRepository
    {
        List<BudgetListDto> GetAll();
        BudgetDto Get(int budgetId);
        int Create(BudgetDto dto);
        void Delete(int budgetId);

    }

    public class BudgetRepository : IBudgetRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public BudgetRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext; 
        }

        public int Create(BudgetDto dto)
        {            
            var budget = _mapper.Map<Budget>(dto);
            
            _dbContext.Budgets.Add(budget);
            _dbContext.SaveChanges();

            return budget.Id;
        }

        public void Delete(int budgetId)
        {
            var budget = _dbContext.Budgets.FirstOrDefault(x => x.Id == budgetId);

            if (budget is null)
                throw new Exception("Budget not found");

            _dbContext.Budgets.Remove(budget);
            _dbContext.SaveChanges();
        }

        public BudgetDto Get(int budgetId)
        {
            var budget = _dbContext.Budgets.FirstOrDefault(x => x.Id == budgetId);

            if (budget is null)
                throw new Exception("Budget not found");

            return _mapper.Map<BudgetDto>(budget);
        }

        public List<BudgetListDto> GetAll()
        {
            var budgets = _dbContext.Budgets.ToList();
            return _mapper.Map<List<BudgetListDto>>(budgets);
        }
    }
}
