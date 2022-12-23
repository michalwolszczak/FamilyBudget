using AutoMapper;
using API.Data;
using API.Data.Entities;
using API.Models;
using API.Exceptions;

namespace API.Repository
{
    public interface IBudgetRepository
    {
        List<Budget> GetAll();
        BudgetDto Get(int budgetId);
        int Create(BudgetDto dto);
        void Delete(int budgetId);

    }

    public class BudgetRepository : IBudgetRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public BudgetRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
                throw new NotFoundException("Budget not found");

            _dbContext.Budgets.Remove(budget);
            _dbContext.SaveChanges();
        }

        public BudgetDto Get(int budgetId)
        {
            var budget = _dbContext.Budgets.FirstOrDefault(x => x.Id == budgetId);

            if (budget is null)
                throw new NotFoundException("Budget not found");

            return _mapper.Map<BudgetDto>(budget);
        }

        public List<Budget> GetAll()
        {
            var budgets = _dbContext.Budgets.ToList();
            return _mapper.Map<List<Budget>>(budgets);
        }
    }
}
