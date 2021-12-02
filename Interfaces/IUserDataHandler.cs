using System.Text.RegularExpressions;
using System.Collections.Generic;
using API.models;

namespace API.Interfaces
{
    public interface IUserDataHandler
    {
         public List<User> Select();
         public List<User> Match(User user);
         public void Delete(User user);
         public void Insert(User user);
         public void Update(User user);
         /*public void FindUser(User user);*/
        
    }
}