using System;
using System.Dynamic;
using API.Interfaces;
using System.Collections.Generic;
using API.Data;
using API.models;

namespace API.Data
{
    public class AdminDataHandler : IAdminDataHandler
    {
       private Database db;
        public AdminDataHandler()
        {
            db = new Database();
        }
         public List<Admin> Select(){
            db.Open();
            string sql = "SELECT * FROM admin";           
            List<ExpandoObject> results = db.Select(sql);

            List<Admin> admin = new List<Admin>();
            foreach(dynamic item in results){
                Admin temp = new Admin(){
                Adminid = item.adminid, 
                Adminusername = item.adminusername,
                Adminpassword = item.adminpassword,
                };
            admin.Add(temp);
            }
            db.Close();
            return admin;
         }
         public void Update(Admin admin)
         {
            string sql = "UPDATE admin SET adminusername=@adminusername, adminpassword=@adminpassword ";  
            sql+="WHERE userid=@userid";
            var values = GetValues(admin);
            db.Open();
            db.Update(sql, values);
            db.Close();
         }
         public void Delete(Admin admin)
         { 
            string sql = "DELETE FROM admin WHERE adminid=@adminid";
            var values = GetValues(admin);
            db.Open();
            db.Update(sql, values);
            db.Close();
         }
         public void Insert(Admin admin){
            var values = GetValues(admin);
            string sql = "INSERT INTO admin(adminusername, adminpassword)"; 
            sql+="VALUES(@adminusername, @password)";
            db.Open();
            db.Insert(sql, values);
            db.Close();
         }

         public Dictionary<string,object> GetValues(Admin admin)
         {
             var values = new Dictionary<string,object>()
             {
                 {"@adminid",admin.Adminid},
                 {"@adminusername",admin.Adminusername},
                 {"@adminpassword",admin.Adminpassword}
             };

             return values;
         }
    }
}