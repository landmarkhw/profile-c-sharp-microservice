using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Profile.CSharp.Microservice
{
    public class CustomType
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
        public DateTime Prop3 { get; set; }
    }

    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("json/hello-world")]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hello, world!");
        }

        [HttpGet("json/complex")]
        public IActionResult GetJsonComplex()
        {
            var items = new object[1000];
            var now = DateTime.Now;

            for (var i = 0; i < 1000; i++)
            {
                items[i] = new
                {
                    id = i,
                    another = "thing",
                    ts = now,
                };
            }

            return Ok(new
            {
                id = 1,
                items,
                success = true
            });
        }

        [HttpGet("json/custom")]
        public IActionResult GetJsonCustom()
        {
            var custom = new CustomType
            {
                Prop1 = 1,
                Prop2 = "testing",
                Prop3 = DateTime.Now,
            };

            return Ok(custom);
        }

        [HttpGet("json/simple")]
        public IActionResult GetJsonSimple()
        {
            return Ok(new
            {
                success = true
            });
        }
    }
}
