using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTreats.Model.Entities;
using Types;

namespace TastyTreats.Repository
{
    public class ReviewRepo
    {
        DataAccess db = new DataAccess();

        public bool Add(Review review)
        {
            List<ParmStruct> parms = new List<ParmStruct>
            {
                new ParmStruct("@Comment", review.Comment, SqlDbType.VarChar),
                new ParmStruct("@Stars", review.Stars, SqlDbType.Int),
                new ParmStruct("@Date", review.ReviewDate, SqlDbType.DateTime2),
                new ParmStruct("@RecipeID", review.RecipeID, SqlDbType.Int)
            };

            return db.ExecuteNonQuery("Review_Insert", parms) == 1;
        }
    }
}
