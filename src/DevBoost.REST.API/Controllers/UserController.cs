using System;
using System.Collections.Generic;
using DevBoost.REST.Domain.Models;
using DevBoost.REST.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevBoost.REST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();            
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return _userService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public User Post([FromBody] User user)
        {
            _userService.Add(user);

            return user;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public User Put(Guid id, [FromBody] User user)
        {
            _userService.Update(id, user);

            return user;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userService.Delete(id);
        }
    }
}
