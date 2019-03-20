using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCTask.Models;
using HCTask.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonRecordController : ControllerBase
    {
        private readonly PersonRecordRepository _repository;
        public PersonRecordController(PersonRecordRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PersonRecord
        [HttpGet]
        public async Task<IEnumerable<PersonRecord>> Get()
        {
            return await _repository.FindAllAsync();
        }

        // GET: api/PersonRecord/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PersonRecord
        [HttpPost]
        public async Task<PersonRecord> Post([FromBody] PersonRecord personRecord)
        {
            return await _repository.CreateAsync(personRecord);
        }

        // PUT: api/PersonRecord/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
