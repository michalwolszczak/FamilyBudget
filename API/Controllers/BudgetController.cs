using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/api/budget")]    
    [ApiController]
    public class BudgetController : Controller
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_budgetRepository.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_budgetRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody]BudgetDto dto)
        {
            var id = _budgetRepository.Create(dto);
            return Created($"api/budget/{id}", null);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _budgetRepository.Delete(id);
            return NoContent();
        }
    }
}
