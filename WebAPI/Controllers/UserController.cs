﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("getUserById")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
        [HttpPost("UpdateUser")]
        public IActionResult UptadeUser(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
    }
}
