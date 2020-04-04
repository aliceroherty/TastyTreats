using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TastyTreats.Model.DTO;
using TastyTreats.Model.Entities;
using TastyTreats.Repository;
using Types;

namespace TastyTreats.Service
{
    public class RecipeService
    {
        RecipeRepo repo = new RecipeRepo();
        LookupsService lookups = new LookupsService();
        ChefService chefs = new ChefService();

        public List<RecipeDTO> GetRecipes()
        {
            return repo.RetrieveAllWithDetails();
        }

        public bool Validate(Recipe r)
        {
            ValidationContext context = new ValidationContext(r);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(r, context, results, true);

            foreach (ValidationResult result in results)
            {
                ValidationError error = new ValidationError(result.ErrorMessage, ErrorType.Model);
                error.ErrorName = r.GetType().ToString();
                r.AddError(error);
            }

            //Business Rules
            CheckPastryChefRecipe(r);

            return r.Errors.Count == 0;
        }

        public Recipe Get(int id)
        {
            return repo.Retrieve(id);
        }

        public bool UpdateRecipe(Recipe recipe)
        {
            if (Validate(recipe))
            {
                return repo.Update(recipe);
            }
            else
            {
                return false;
            }
        }

        public RecipeReviewsDTO GetRecipeWithReviews(int recipeId)
        {
            return repo.RetrieveWithReviews(recipeId);
        }

        private void CheckPastryChefRecipe(Recipe r)
        {
            Chef chef = chefs.Get(r.ChefID);

            if (lookups.GetRecipeTypes().Find(type => type.ID == r.TypeID).Name != "Dessert" 
                && lookups.GetChefTypes().Find(type => type.ID == chef.TypeID).Description == "Pastry")
            {
                r.Errors.Add(new ValidationError("Pastry Chefs may only add Recipes for Desserts.", ErrorType.Business));
            }
        } 
    }
}
