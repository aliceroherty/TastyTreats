using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTreats.Model.DTO;
using TastyTreats.Model.Entities;
using TastyTreats.Repository;

namespace TastyTreats.Service
{
    public class LookupsService
    {
        LookupsRepo repo = new LookupsRepo();

        public List<RecipeTypeLookupDTO> GetRecipeTypes()
        {
            return repo.GetRecipeTypes();
        }

        public List<ChefLookupDTO> GetChefs()
        {
            return repo.GetChefs();
        }

        public List<ChefType> GetChefTypes()
        {
            return repo.GetChefTypes();
        }
    }
}
