using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("peopleService2")] IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("search/{search}")]
        public List<People> Get(string search) => Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpGet("id")]
        public ActionResult<People> Get(int Id)
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == Id);

            return people != null ? Ok(people) : NotFound();
        }

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);

            return NoContent();
        }
            
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1, Name = "Jose" , BirthDay = new DateTime(1990, 1, 1)
            },
            new People()
            {
                Id = 2, Name = "Maria", BirthDay = new DateTime(1995, 2, 2)
            },
            new People()
            {
                Id = 3, Name = "Pedro", BirthDay = new DateTime(2000, 3, 3)
            },
            new People()
            {
                Id = 4, Name = "Ana", BirthDay = new DateTime(2005, 4, 4)
            },
        };
    }
    
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
