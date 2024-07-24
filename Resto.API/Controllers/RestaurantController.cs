using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resto.API.Data;
using Resto.API.Entities;
using Resto.API.Services;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly SqlServerDbContext _dbContext;

        public RestaurantController(IRestaurantService restaurantService, SqlServerDbContext dbContext)
        {
            this._restaurantService = restaurantService;
            _dbContext = dbContext;

        }

        [HttpGet]
        public List<Restaurant> GetAll()
        {
            var restaurants = _restaurantService.GetAll();
            return restaurants;
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            _restaurantService.Update(restaurant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            _restaurantService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetById(string id)
        {
            var restaurant = _restaurantService.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }


        [HttpPost]
        public IActionResult Add([FromBody] Restaurant restaurant)
        {
            _restaurantService.Add(restaurant);
            return CreatedAtAction(nameof(GetById), new { id = restaurant.Id }, restaurant);
        }
    }
}
