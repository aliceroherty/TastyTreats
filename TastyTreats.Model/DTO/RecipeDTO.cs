using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Model.DTO
{
    public class RecipeDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int Yield { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

        public bool Archived { get; set; }

        [Display(Name = "Chef")]
        public string ChefFullName 
        { 
            get
            {
                return ChefLastName + ", " + ChefFirstName;
            }
        }

        public string ChefFirstName { get; set; }

        public string ChefLastName { get; set; }

        public string Type { get; set; }
    }
}
