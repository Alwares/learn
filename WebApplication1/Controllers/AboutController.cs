using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class AboutController : Controller
    {
        [Route("")]
        public string Phone()
        {
            return "+36-44-556-5422";
        }

        [Route("[action]")]
        public string Country()
        {
            return "USA";
        }
    }
}