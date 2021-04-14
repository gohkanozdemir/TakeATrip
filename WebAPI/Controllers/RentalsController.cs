﻿using Business.Abstract;
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
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _rentalService.GetAll();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycar")]
        public IActionResult getbycar(int id)
        {
            var result = _rentalService.GetRentalByCarId(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult getbyid(int id)
        {
            var result = _rentalService.GetRentalById(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult getdetails()
        {
            var result = _rentalService.GetCompanyDetails();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult delte(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}