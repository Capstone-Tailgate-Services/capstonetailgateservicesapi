using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reviewController : ControllerBase
    {
        // GET: api/review
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Review> Get()
        {
            IReviewDataHandler dataHandler = new ReviewDataHandler();
            return dataHandler.Select();
        }

        // GET: api/review/5
        [EnableCors("OpenPolicy")]

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/review
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Review value)
        {
            value.dataHandler.Insert(value);
        }

        // PUT: api/review/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Review value)
        {
            value.dataHandler.Update(value);
        }

        // DELETE: api/review/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Review value = new Review(){ID=id};
            value.dataHandler.Delete(value);
        }
    }
}
