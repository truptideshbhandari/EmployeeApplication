using Microsoft.AspNetCore.Mvc;
using PersonCrudAPI.Context;
using PersonCrudAPI.Models;

namespace PersonCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly CRUDContext _CRUDContext;
        public PersonController(CRUDContext CRUDContext)
        {
            _CRUDContext = CRUDContext;
        }

        [HttpGet]
        public IEnumerable<Person> Get(int pageNumber = 1, int pageSize = 10)
        {
            var skippedItems = (pageNumber - 1) * pageSize;
            return _CRUDContext.Persons.Skip(skippedItems).Take(pageSize).ToList();
        }

        [HttpGet("count")]
        public int GetCount()
        {
            return _CRUDContext.Persons.Count();
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _CRUDContext.Persons.SingleOrDefault(x => x.PersonId == id);
        }

        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _CRUDContext.Persons.Update(person);
            _CRUDContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Person person)
        {
            _CRUDContext.Persons.Update(person);
            _CRUDContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _CRUDContext.Persons.FirstOrDefault(x => x.PersonId == id);
            if(item != null)
            {
                _CRUDContext.Persons.Remove(item);
                _CRUDContext.SaveChanges();
            }
        }
    }
}
