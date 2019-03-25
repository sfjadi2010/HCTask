using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public async Task<PersonRecord> Get(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        [HttpGet]
        [Route("search/{searchtext}")]
        public async Task<IEnumerable<PersonRecord>> Search(string searchtext)
        {
            return await _repository.SearchAsync(searchtext.ToLower());
        }

        // POST: api/PersonRecord
        [HttpPost]
        public async Task<PersonRecord> Post([FromBody] PersonRecord personRecord)
        {
            if (personRecord.PictureName != null)
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                personRecord.PictureName = Guid.NewGuid() + Path.GetExtension(personRecord.PictureName);
                var fullPath = Path.Combine(pathToSave, personRecord.PictureName);

                if (personRecord.FileAsBase64.Contains(","))
                {
                    personRecord.FileAsBase64 = personRecord.FileAsBase64.Substring(personRecord.FileAsBase64.IndexOf(",") + 1);
                }

                personRecord.FileAsByteArray = Convert.FromBase64String(personRecord.FileAsBase64);

                using (var fs = new FileStream(fullPath, FileMode.CreateNew))
                {
                    fs.Write(personRecord.FileAsByteArray, 0, personRecord.FileAsByteArray.Length);
                }
            }

            return await _repository.CreateAsync(personRecord);
        }

        // PUT: api/PersonRecord/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var person = await _repository.FindByIdAsync(id);
            await _repository.DeleteAsync(person);

            return;
        }
    }
}
