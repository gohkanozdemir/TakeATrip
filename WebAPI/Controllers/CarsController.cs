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
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _carService.GetAll();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult getbycarid(int id)
        {
            var result = _carService.GetCarById(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult getbybrandid(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycolorid")]
        public IActionResult getbycolorid(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbymodelyear")]
        public IActionResult getbymodelyear(int modelYear)
        {
            var result = _carService.GetCarsByModelYear(modelYear);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyprice")]
        public IActionResult getbyprice(decimal price)
        {
            var result = _carService.GetCarsByDailyPrice(price);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarname")]
        public IActionResult getbycarname(string name)
        {
            var result = _carService.GetCarsByCarName(name);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsdetails")]
        public IActionResult getcarsdetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult getcardetails(int id)
        {
            var result = _carService.GetCarDetailsById(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]  // [HttpPut] da olabilir
        public IActionResult update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]  // [HttpDelete] da olabilir
        public IActionResult delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
