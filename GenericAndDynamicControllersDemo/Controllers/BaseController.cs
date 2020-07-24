using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericAndDynamicControllersDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GenericAndDynamicControllersDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : Controller where T : class
    {
        private Repository<T> _repository;

        public BaseController(Repository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public T Get(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost("{id}")]
        public void Post(Guid id, [FromBody] T value)
        {
            _repository.AddOrUpdate(id, value);
        }
    }
}
