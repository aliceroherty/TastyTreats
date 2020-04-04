using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTreats.Model.DTO;
using TastyTreats.Model.Entities;
using Types;

namespace TastyTreats.Repository
{
    public class RecipeRepo
    {
        DataAccess db = new DataAccess();

        public List<RecipeDTO> RetrieveAllWithDetails()
        {
            List<RecipeDTO> recipes = new List<RecipeDTO>();

            DataTable dt = db.Execute("Recipe_GetAllWithDetails");

            foreach (DataRow row in dt.Rows)
            {
                recipes.Add(UnpackRecipeDTO(row));
            }

            return recipes;
        }

        public Recipe Retrieve(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@ID", id, SqlDbType.Int)
            };

            DataTable dt = db.Execute("Recipe_GetById", parms);

            return dt.Rows.Count == 1 ? UnpackRecipe(dt.Rows[0]) : null;
        }

        public bool Update(Recipe r)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@ID", r.ID, SqlDbType.Int),
                new ParmStruct("@Title", r.Title, SqlDbType.NVarChar),
                new ParmStruct("@ChefID", r.ChefID, SqlDbType.Int),
                new ParmStruct("@Yield", r.Yield, SqlDbType.Int),
                new ParmStruct("@DateAdded", r.DateAdded, SqlDbType.DateTime2),
                new ParmStruct("@Archived", r.Archived, SqlDbType.Bit),
                new ParmStruct("@RecipeType", r.TypeID, SqlDbType.Int)
            };

            return db.ExecuteNonQuery("Recipe_Update", parms) == 1;
        }

        public RecipeReviewsDTO RetrieveWithReviews(int recipeID)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@ID", recipeID, SqlDbType.Int)
            };

            DataTable dt = db.Execute("Recipe_GetByIdWithReviews", parms);

            return UnpackRecipeReviewsDTO(dt);
        }

        private RecipeDTO UnpackRecipeDTO(DataRow row)
        {
            RecipeDTO r = new RecipeDTO();

            r.ID = Convert.ToInt32(row["RecipeID"]);
            r.Title = row["Title"].ToString();
            r.Yield = Convert.ToInt32(row["Yield"]);
            r.DateAdded = Convert.ToDateTime(row["DateAdded"]);
            r.Archived = Convert.ToBoolean(row["Archived"]);
            r.Type = row["Name"].ToString();
            r.ChefLastName = row["LastName"].ToString();
            r.ChefFirstName = row["FirstName"].ToString();

            return r;
        }
        
        private Recipe UnpackRecipe(DataRow row)
        {
            Recipe r = new Recipe();

            r.ID = Convert.ToInt32(row["RecipeID"]);
            r.Title = row["Title"].ToString();
            r.Yield = Convert.ToInt32(row["Yield"]);
            r.DateAdded = Convert.ToDateTime(row["DateAdded"]);
            r.Archived = Convert.ToBoolean(row["Archived"]);
            r.TypeID = Convert.ToInt32(row["RecipeType"]);
            r.ChefID = Convert.ToInt32(row["ChefID"]);

            return r;
        }

        private RecipeReviewsDTO UnpackRecipeReviewsDTO(DataTable dt)
        {
            RecipeDTO recipe = new RecipeDTO();

            if (dt.Rows.Count >= 1)
            {
                recipe = UnpackRecipeDTO(dt.Rows[0]);
            }

            List<ReviewDTO> reviews = new List<ReviewDTO>();

            if (dt.Rows[0]["ReviewId"] != DBNull.Value)
            {
                foreach (DataRow row in dt.Rows)
                {
                    reviews.Add(UnpackReviewDTO(row));
                }
            }

            return new RecipeReviewsDTO
            {
                Details = recipe,
                Reviews = reviews
            };
        }

        private ReviewDTO UnpackReviewDTO(DataRow row)
        {
            ReviewDTO review = new ReviewDTO
            {
                ID = Convert.ToInt32(row["ReviewId"]),
                Comment = row["Comment"].ToString(),
                Stars = Convert.ToInt32(row["Stars"])
            };

            if (!row["ReviewDate"].Equals(DBNull.Value))
            {
                review.Date = Convert.ToDateTime(row["ReviewDate"]);
            }

            return review;
        }
    }
}
