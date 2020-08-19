using System;
using System.Collections.Generic;
using AutoMapper;
using DevBoost.REST.API.Models;
using DevBoost.REST.API.ViewModels;
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
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(_userService.GetAll());            
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserViewModel Get(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userService.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public UserViewModel Post([FromBody] CreateUserViewModel userViewModel)
        {
            var user = _userService.Add(_mapper.Map<User>(userViewModel));

            return _mapper.Map<UserViewModel>(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public UserViewModel Put(Guid id, [FromBody] EditUserViewModel userViewModel)
        {
            var user = _userService.Update(id, _mapper.Map<User>(userViewModel));

            return _mapper.Map<UserViewModel>(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userService.Delete(id);
        }
    }
}
