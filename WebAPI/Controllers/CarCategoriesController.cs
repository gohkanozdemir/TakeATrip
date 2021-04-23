using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCategoriesController : ControllerBase
    {
        private ICarCategoryService _carCategoryService;

        public CarCategoriesController(ICarCategoryService carCategoryService)
        {
            _carCategoryService = carCategoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
