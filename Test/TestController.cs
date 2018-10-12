using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Profile.CSharp.Microservice
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("json/simple")]
        public IActionResult GetJsonSimple()
        {
            return Ok(new {
                success = true
            });
        }

        [HttpGet("json/complex")]
        public IActionResult GetJsonComplex()
        {
            var items = new object[1000];
            var now = DateTime.Now;

            for (var i = 0; i < 1000; i++) {
                items[i] = new {
                    id = i,
                    another = "thing",
                    ts = now,
                };
            }

            return Ok(new {
                id = 1,
                items,
                success = true
            });
        }
    }
}
