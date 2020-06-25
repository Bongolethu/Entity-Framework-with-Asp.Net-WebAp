using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkUnitTestingWithAspNetWebApi.Repository
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        IQueryable<Person> FindByIDNumber(string IDNumber);
    }
}
