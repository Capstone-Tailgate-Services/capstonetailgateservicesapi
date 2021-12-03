using System;
using API.Interfaces;
using API.Data;
namespace API.models
{
    public class Review
    {
        public int ID{get; set;}
        public string Reviewstext {get; set;}
        public string Reviewsauthor {get; set;}
        public string Reviewsrating {get; set;}
        public IReviewDataHandler dataHandler{get; set;}

        public Review(){
            dataHandler = new ReviewDataHandler();
        }
    }
}