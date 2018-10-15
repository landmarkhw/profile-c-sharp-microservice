using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Profile.CSharp.Microservice
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository personRepository;

        public PersonController(PersonRepository personRepository)
        {
            this.personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = personRepository.Get(id);
            var data = new Envelope<Person>(person);
            return Ok(data);
        }
    }
}
