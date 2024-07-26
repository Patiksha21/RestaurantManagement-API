using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resto.API.Entities;
using Resto.API.Services;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet]
        public List<User> GetAll()
        {
            var users = _userService.GetAll();
            return users;
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userService.Update(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            _userService.Delete(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetById(string id)
        {
            var restaurant = _userService.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            _userService.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
    }
}
