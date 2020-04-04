using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyTreats.Model.DTO
{
    public class RecipeTypeLookupDTO
    {
        [Display(Name="Recipe Type ID")]
        public int ID { get; set; }

        [Display(Name = "Recipe Type")]
        public string Name { get; set; }
    }
}
