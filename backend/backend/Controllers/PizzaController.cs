using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PizzaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            try
            {
                List<Pizza> pizzas = _context.Pizzas.ToList();
                return Ok(pizzas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpGet("{pizzaId}")]
        public IActionResult GetPizzaById(int pizzaId)
        {
            try
            {
                Pizza? pizza = _context.Pizzas.FirstOrDefault(pizza => pizza.Id == pizzaId);
                if (pizza is null)
                    return NotFound();

                return Ok(pizza);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpPut("{pizzaId}")]
        public IActionResult UpdatePizza(int pizzaId, Pizza updPizza)
        {
            try
            {
                Pizza? pizza = _context.Pizzas.FirstOrDefault(pizza => pizza.Id == pizzaId);
                if (pizza is null)
                    return NotFound();

                pizza.Name = updPizza.Name;
                pizza.Description = updPizza.Description;

                _context.SaveChanges();
                return Ok("Pizza Successfully  Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult CreatePizza(Pizza newPizza)
        {
            try
            {
                if (newPizza is null)
                    return BadRequest();

                _context.Pizzas.Add(newPizza);
                _context.SaveChanges();
                return Ok("Pizza Successfully Added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpDelete("{pizzaId}")]
        public IActionResult DeletePizza(int pizzaId)
        {
            try
            {
                Pizza? pizza = _context.Pizzas.FirstOrDefault(pizza => pizza.Id == pizzaId);
                if (pizza is null)
                    return NotFound();
                _context.Pizzas.Remove(pizza);
                _context.SaveChanges();
                return Ok("Pizza seccussfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }
    }
}
