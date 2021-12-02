using System;
using System.Dynamic;
using API.Interfaces;
using System.Collections.Generic;
using API.Data;
using API.models;

namespace API.Data
{
    public class ReviewDataHandler : IReviewDataHandler
    {
       private Database db;
        public ReviewDataHandler()
        {
            db = new Database();
        }
         public List<Review> Select(){
            db.Open();
            string sql = "SELECT * FROM reviews order by id desc";           
            List<ExpandoObject> results = db.Select(sql);

            List<Review> review = new List<Review>();
            foreach(dynamic item in results){
                Review temp = new Review(){
                ID = item.id, 
                Reviewstext = item.reviewstext,
                Reviewsauthor = item.reviewsauthor,
                Reviewsrating  = item.reviewsrating,
                Date = item.date,
                Useremail = item.useremail,
                };
            review.Add(temp);
            }
            db.Close();
            return review;
         }
         public void Update(Review review)
         {
            /*review.Date = DateTime.Now;*/
            string sql = "UPDATE reviews SET reviewstext=@Reviewstext, date=@date ";  
            sql+="WHERE id=@id";
            var values = GetValues(review);
            db.Open();
            db.Update(sql, values);
            db.Close();
         }
         public void Delete(Review review)
         { 
            string sql = "DELETE FROM reviews WHERE id=@id";
            var values = GetValues(review);
            db.Open();
            db.Update(sql, values);
            db.Close();
         }
         public void Insert(Review review){
            /*review.Date = DateTime.Now;*/
            var values = GetValues(review);
            string sql = "INSERT INTO reviews(reviewstext, date)"; 
            sql+="VALUES(@reviewstext, @date)";
            db.Open();
            db.Insert(sql, values);
            db.Close();
         }

         public Dictionary<string,object> GetValues(Review review)
         {
             var values = new Dictionary<string,object>()
             {
                 {"@id",review.ID},
                 {"@reviewstext",review.Reviewstext},
                 {"@reviewsauthor",review.Reviewsauthor},
                 {"@reviewsrating",review.Reviewsrating},
                 {"@date",review.Date},
                 {"@useremail",review.Useremail},
             };

             return values;
         }
    }
}