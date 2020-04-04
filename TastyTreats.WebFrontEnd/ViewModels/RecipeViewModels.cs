using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TastyTreats.Model.DTO;
using TastyTreats.Model.Entities;

namespace TastyTreats.WebFrontEnd.ViewModels
{
    public class RecipeEditVM
    {
        public Recipe Recipe { get; set; } 

        public List<SelectListItem> Chefs { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> RecipeTypes { get; set; } = new List<SelectListItem>();
    }

    public class RecipeDetailsVM
    {
        public int RecipeId { get; set; }

        public string Title { get; set; }

        public string Chef { get; set; } 

        public int Yield { get; set; }

        public bool Archived { get; set; }

        public List<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
    }
}