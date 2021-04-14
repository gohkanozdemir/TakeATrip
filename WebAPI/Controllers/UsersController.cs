using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _userService.GetAll();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult getbyid(int id)
        {
            var result = _userService.GetUserById(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyname")]
        public IActionResult getbyname(string name)
        {
            var result = _userService.GetUserByName(name);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyfullname")]
        public IActionResult getbyfullname(string name, string  lastname)
        {
            var result = _userService.GetUserByFullName(name, lastname);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult add(User user)
        {
            var result = _userService.Add(user);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult update(User user)
        {
            var result = _userService.Update(user);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult delte(User user)
        {
            var result = _userService.Delete(user);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
