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
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _customerService.GetAll();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult getdetails()
        {
            var result = _customerService.GetCompanyDetails();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult getbyid(int id)
        {
            var result = _customerService.GetCustomerById(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]  // [HttpPut] da olabilir
        public IActionResult update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]  // [HttpDelete] da olabilir
        public IActionResult delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
