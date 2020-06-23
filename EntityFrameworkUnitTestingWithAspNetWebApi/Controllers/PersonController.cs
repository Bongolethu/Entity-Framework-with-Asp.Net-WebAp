using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkUnitTestingWithAspNetWebApi;

namespace EntityFrameworkUnitTestingWithAspNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {  
        private readonly ForBlogContext _context;
       public PersonController(ForBlogContext context)
        {           
            _context = context; 
        }
        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            return await _context.Person.ToListAsync();
        }
        // POST: api/Person
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostPerson(Person person)
        { 
            _context.Person.Add(person);
            _context.SaveChanges();
        }
        // GET: api/Person/5
        [HttpGet("{idNumber}")]
        public async Task<Person> GetPerson(string idNumber)
        { 
            return _context.Person.Where(s=>s.IDNumber == idNumber).FirstOrDefault();
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
