using Business.Abstract;
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
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _categoryService.GetAll();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydoors")]
        public IActionResult getbydoors(short number)
        {
            var result = _categoryService.GetCategoryByDoors(number);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyseats")]
        public IActionResult getbyseats(short number)
        {
            var result = _categoryService.GetCategoryBySeats(number);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyname")]
        public IActionResult getbyname(string name)
        {
            var result = _categoryService.GetCategoryByCategoryName(name);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
