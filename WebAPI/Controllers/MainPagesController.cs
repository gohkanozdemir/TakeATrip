﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPagesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome main page!";
        }
    }
}
