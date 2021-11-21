using System;
using API.Interfaces;
using API.Data;
namespace API.models
{
    public class User
    {
        public int Userid{get; set;}
        public string Useremail {get; set;}
        public string Userpassword {get; set;}
        public string UserPhoneNo {get;set;}
        public IUserDataHandler dataHandler{get; set;}

        public User(){
            dataHandler = new UserDataHandler();
        }
    }
}