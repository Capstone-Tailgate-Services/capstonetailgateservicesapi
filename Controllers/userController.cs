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
    public class userController : ControllerBase
    {
        // GET: api/user
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<User> Getuser()
        {
            IUserDataHandler dataHandler = new UserDataHandler();
            return dataHandler.Select();
        }

        // MATCH: api/user
        [EnableCors("OpenPolicy")]
        [HttpPut]
        public List<User> MatchUser([FromBody] User value)
        {
            IUserDataHandler dataHandler = new UserDataHandler();
            return dataHandler.Match(value);
        }

        /*[EnableCors("OpenPolicy")]
        [HttpGet]
        public void FindUser([FromBody] User value)
        {
            value.dataHandler.FindUser(value);
        }*/

        // POST: api/user
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] User value)
        {
            value.dataHandler.Insert(value);
        }

        // PUT: api/user/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            value.dataHandler.Update(value);
        }

        // DELETE: api/user/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User value = new User(){Userid=id};
            value.dataHandler.Delete(value);
        }
    }
}
