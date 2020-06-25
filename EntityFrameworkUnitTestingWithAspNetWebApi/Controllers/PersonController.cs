using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkUnitTestingWithAspNetWebApi;
using EntityFrameworkUnitTestingWithAspNetWebApi.Repository;

namespace EntityFrameworkUnitTestingWithAspNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ForBlogContext _context = null;
        private readonly IBaseRepository<Person> _baseRepository = null;
        private readonly IPersonRepository _personRepository = null;
        public PersonController(ForBlogContext context,IBaseRepository<Person> baseRepository, IPersonRepository personRepository)
        {           
            _context = context;
            _baseRepository = personRepository;
            _personRepository = personRepository;

        }
        public PersonController()
        {

        }
        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            return await _personRepository.FindAll().ToListAsync();
            //return await _context.Person.ToListAsync();
        }
        // POST: api/Person
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostPerson(Person person)
        {
            if (person == null)
                throw new NullReferenceException("The person object being created cannot be null");
            
                    _personRepository.Create(person);

            //_context.Person.Add(person);
            //_context.SaveChanges();
        }
        // GET: api/Person/5
        [HttpGet("{idNumber}")] 
        public async Task<Person> GetPersonFindByIDNumber(string idNumber)
        {
            return _personRepository.FindByIDNumber(idNumber).SingleOrDefault();
            //return _context.Person.Where(s=>s.IDNumber == idNumber).FirstOrDefault();
        }
        // PUT: api/Person/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {          
            return null;
        } 
        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(Guid id)
        { 
            return null;
        }

        private bool PersonExists(Guid id)
        {
            return false;
        }
    }
}
