using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TastyTreats.Model.Entities
{
    public class Review : BaseEntity
    {
        public int ID { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Stars can only be numbers between 0 and 5.")]
        public int Stars { get; set; }

        public DateTime ReviewDate { get; set; }

        [Required]
        public int RecipeID { get; set; }
    }
}
