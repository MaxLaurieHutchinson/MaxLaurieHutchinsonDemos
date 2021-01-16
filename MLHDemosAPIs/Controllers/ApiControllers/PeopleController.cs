using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLHDemosAPIs.Data;
using MLHDemosAPIs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLHDemosAPIs.Controllers.ApiControllers
{
    /// <summary>
    ///
    /// Go look at the other first... this one is more complicated
    ///
    ///
    /// </summary>

    // Route:     // route: https://localhost:5001/api/v1/People

    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly MLHDemosAPIsContext _context;

        public PeopleController(MLHDemosAPIsContext context)
        {
            _context = context;
        }

        // GET: api/v1/<PeopleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Welcome ", "to ", "the ", "Danger", "Zone" };
        }

        // The default format used by ASP.NET Core is JSON.
        // Read: https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-5.0
        // route: https://localhost:5001/api/v1/People/GetMeTheAnswerInJson
        [HttpGet("GetMeTheAnswerInJson")]
        public ContentResult GetMeTheAnswerInJson()
        {
            var text = "This is a Date: ";

            var date = System.DateTime.Now.ToLongDateString();

            var stichingStringsTogether = text + date;

            // make upper case
            var result = stichingStringsTogether.ToUpperInvariant();

            return Content(result);  // basic text
        }

        // GET api/v1/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<List<People>> GetPeople(int Id, string Name, int? age)
        {
            // seting where to get the data but i have not run .ToListAsync().
            // This will allow you to have more advanced where clauses :)
            var resultset = _context.People;

            // now make Some logic
            if (age.HasValue)
            {
                // Equals is exact
                resultset.Where(x => x.Age.Equals(age));
            }

            if (string.IsNullOrEmpty(Name))
            {
                // Contains is a bit more fuzzy
                resultset.Where(x => x.Name.Contains(Name));
            }

            // Run the query

            var results = await resultset.ToListAsync();

            return results;
        }

        // POST api/v1/<PeopleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // looks live v1 doesn't do that much
        }

        [HttpPost]

        // this is a new version of the api....
        // I put it under v2 meaning version 2 so you can use the old method still. .
        // POST api/v2/People/PostPeople
        [Route("api/v2/[controller]")]
        public async Task<ActionResult<People>> PostPeople(People people)
        {
            _context.People.Add(people);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new { id = people.Id }, people);
        }

        // again you can hard code routes
        [Route("api/v3/[controller]/PostPeople")]
        [HttpPost]
        public void AddPerson()
        {
            // This is adding a pre-defined item to the entity

            var person = new People { Name = "Max", Age = 30 };

            _context.Add<People>(person);
            _context.SaveChanges();
        }

        // The route doesnt even need to say the name of the method
        [Route("api/v1/People/AllThePeople")]
        [HttpPost, HttpGet] // i am telling it you can post or just get (get= go to the page) not ment to do a get for a data post but is easy to show example.
        public void AddAPersonOrTwo()
        {
            // This is adding a pre-defined item to the entity

            var loadofPeople = new List<People>
            {
                new People { Name = "Max", Age = 30 },
                new People { Name = "Anna", Age = 33 },
                new People { Name = "Wei", Age = 31 },
                new People { Name = "Zoe", Age = 49 },
                new People { Name = "Sam", Age = 0 },
                new People { Name = "Tom", Age = 18 }
            };

            _context.Add<List<People>>(loadofPeople);
            _context.SaveChanges();
        }

        // lets add up
        // route: https://localhost:5001/api/v1/People/AddUp?numbers=1&numbers=2&numbers=3
        [Route("api/v1/People/AddUp")]
        [HttpGet("AddUp")]
        public string Get([FromQuery] int[] numbers)
        {
            var result = numbers.Sum();

            return result.ToString();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete]
        public void DeleteAll()
        {
        }
    }
}