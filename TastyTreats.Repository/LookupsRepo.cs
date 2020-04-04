using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTreats.Model.DTO;
using TastyTreats.Model.Entities;

namespace TastyTreats.Repository
{
    public class LookupsRepo
    {
        DataAccess db = new DataAccess();

        public List<RecipeTypeLookupDTO> GetRecipeTypes()
        {
            List<RecipeTypeLookupDTO> recipeTypes = new List<RecipeTypeLookupDTO>();

            DataTable dt = db.Execute("RecipeType_GetForLookup");

            foreach (DataRow row in dt.Rows)
            {
                recipeTypes.Add(UnpackRecipeTypeLookup(row));
            }

            return recipeTypes;
        }

        public List<ChefLookupDTO> GetChefs()
        {
            List<ChefLookupDTO> chefs = new List<ChefLookupDTO>();

            DataTable dt = db.Execute("Chef_GetForLookup");

            foreach (DataRow row in dt.Rows)
            {
                chefs.Add(UnpackChefLookup(row));
            }

            return chefs;
        }

        public List<ChefType> GetChefTypes()
        {
            List<ChefType> types = new List<ChefType>();

            DataTable dt = db.Execute("ChefType_GetAll");

            foreach (DataRow row in dt.Rows)
            {
                types.Add(UnpackChefType(row));
            }

            return types;
        }

        private RecipeTypeLookupDTO UnpackRecipeTypeLookup(DataRow row)
        {
            RecipeTypeLookupDTO r = new RecipeTypeLookupDTO();
            r.ID = Convert.ToInt32(row["RecipeTypeId"]);
            r.Name = row["Name"].ToString();
            return r;
        }
        
        private ChefLookupDTO UnpackChefLookup(DataRow row)
        {
            ChefLookupDTO chef = new ChefLookupDTO();
            chef.ID = Convert.ToInt32(row["ChefId"]);
            chef.Name = row["ChefName"].ToString();
            return chef;
        }

        private ChefType UnpackChefType(DataRow row)
        {
            return new ChefType
            {
                ID = Convert.ToInt32(row["ChefTypeId"]),
                Description = row["Description"].ToString()
            };
        }
    }
}
