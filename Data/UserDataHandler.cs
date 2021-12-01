using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System;
using System.Dynamic;
using API.Interfaces;
using System.Collections.Generic;
using API.Data;
using API.models;

namespace API.Data
{
    public class UserDataHandler : IUserDataHandler
    {
       private Database db;
        public UserDataHandler()
        {
            db = new Database();
        }
        public List<User> Select()
        {
            string sql = "SELECT * FROM user";
            db.Open();
            /*if(user.Admin == 2)
            {
                sql+= "WHERE useremail= @useremail and userpassword=@userpassword";
            }*/
            List<ExpandoObject> results = db.Select(sql);

            List<User> user = new List<User>();
            foreach(dynamic item in results)
            {
                User temp = new User()
                {
                Userid = item.userid, 
                Useremail = item.useremail,
                Userpassword = item.userpassword,
                Admin = item.admin,
                };
                user.Add(temp);
            }
            db.Close();
            return user;
        }
        public List<User> Match(User user)
        {
            string sql = "SELECT * FROM user WHERE useremail= @useremail and userpassword=@userpassword";
            var values = GetValues(user);
            db.Open();

            List<ExpandoObject> results = db.Select(sql);

            List<User> userMatch = new List<User>();
            foreach(dynamic item in results)
            {
                User temp = new User()
                {
                Userid = item.userid, 
                Useremail = item.useremail,
                Userpassword = item.userpassword,
                Admin = item.admin,
                };
                userMatch.Add(temp);
            }
            db.Close();
            return userMatch;
        }
         public void Update(User user)
         {
            string sql = "UPDATE user SET useremail=@useremail, userpassword=@userpassword ";  
            sql+="WHERE userid=@userid";
            var values = GetValues(user);
            db.Open();
            db.Update(sql, values);
            db.Close();
         }
         public void Delete(User user)
         { 
            string sql = "DELETE FROM user WHERE userid=@userid";
            var values = GetValues(user);
            db.Open();
            db.Update(sql, values);
            db.Close();
         }
         public void Insert(User user){
            var values = GetValues(user);
            string sql = "INSERT INTO user(useremail, userpassword)"; 
            sql+="VALUES(@useremail, @userpassword)";
            db.Open();
            db.Insert(sql, values);
            db.Close();
         }
         public void GetUser(User user)
        {
            string sql = "SELECT admin FROM user WHERE useremail= @userid and userpassword=@userpassword";
            var values = GetValues(user);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }
        
         public Dictionary<string,object> GetValues(User user)
         {
             var values = new Dictionary<string,object>()
             {
                 {"@userid",user.Userid},
                 {"@useremail",user.Useremail},
                 {"@userpassword",user.Userpassword},
                 {"@admin",user.Admin},
             };

             return values;
         }
    }
}