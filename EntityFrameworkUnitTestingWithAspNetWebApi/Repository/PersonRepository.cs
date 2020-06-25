using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkUnitTestingWithAspNetWebApi.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    { 
        public PersonRepository(DbContext context)
           : base(context)
        { 
        }
        public IQueryable<Person> FindByIDNumber(string IDNumber)
        {
            return _context.Set<Person>().Where(s=>s.IDNumber == IDNumber).AsNoTracking();  
        }
    }
}
