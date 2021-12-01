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

        // GET: api/user/5
        /*[EnableCors("OpenPolicy")]
        [HttpGet("{id}")]
        public void MatchUser(int id)
        {
            User value = new User(){Userid=id};
            value.dataHandler.GetUser(value);
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

        /*[EnableCors("OpenPolicy")]        
        [HttpPut]
        public List<User> LogInUser()
        {
            IUserDataHandler loginObj = new UserDataHandler();
            return loginObj.FindUser();
        }*/
    }
}
