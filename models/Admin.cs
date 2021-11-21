using System;
using API.Interfaces;
using API.Data;
namespace API.models
{
    public class Admin
    {
        public int Adminid{get; set;}
        public string Adminusername {get; set;}
        public string Adminpassword {get; set;}
        public IAdminDataHandler dataHandler{get; set;}

        public Admin(){
            dataHandler = new AdminDataHandler();
        }
    }
}