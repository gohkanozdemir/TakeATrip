using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private ICarFeatureService _carFeatureService;

        public CarFeaturesController(ICarFeatureService carFeatureService)
        {
            _carFeatureService = carFeatureService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carFeatureService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydoors")]
        public IActionResult GetByDoors(short number)
        {
            var result = _carFeatureService.GetCarFeatureByDoors(number);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyseats")]
        public IActionResult GetBySeats(short number)
        {
            var result = _carFeatureService.GetCarFeatureBySeats(number);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
