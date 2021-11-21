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
    public class adminController : ControllerBase
    {
        // GET: api/user
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Admin> Getadmin()
        {
            IAdminDataHandler dataHandler = new AdminDataHandler();
            return dataHandler.Select();
        }

        // GET: api/user/5
        [EnableCors("OpenPolicy")]

        [HttpGet("{id}", Name = "Getadmin")]
        public string Getadmin(int id)
        {
            return "value";
        }

        // POST: api/user
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Admin value)
        {
            value.dataHandler.Insert(value);
        }

        // PUT: api/user/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Admin value)
        {
            value.dataHandler.Update(value);
        }

        // DELETE: api/user/5
        [EnableCors("OtherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Admin value = new Admin(){Adminid=id};
            value.dataHandler.Delete(value);
        }
    }
}
