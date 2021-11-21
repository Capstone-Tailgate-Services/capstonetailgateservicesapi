using System.Collections.Generic;
using API.models;

namespace API.Interfaces
{
    public interface IReviewDataHandler
    {
         public List<Review> Select();
         public void Delete(Review review);
         public void Insert(Review review);
         public void Update(Review review);
    }
}
