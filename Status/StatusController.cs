using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Profile.CSharp.Microservice
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Person> Get()
        {
            var success = Db.Test();
            return Ok(new {
                Database = success
            });
        }
    }
}
