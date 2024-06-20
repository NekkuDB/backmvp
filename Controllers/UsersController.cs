using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Repositories;
using System.Collections.Generic;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userRepository.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] User loginUser)
        {
            var user = _userRepository.GetByUsername(loginUser.Username);
            if (user == null || user.Password != loginUser.Password)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Is2FAEnabled = user.Is2FAEnabled;
            existingUser.Key = user.Key;
            existingUser.Counter = user.Counter;

            _userRepository.Update(existingUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(id);
            return NoContent();
        }
    }
}
