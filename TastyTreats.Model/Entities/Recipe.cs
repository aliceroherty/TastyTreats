using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyTreats.Model.Entities
{
    public class Recipe : BaseEntity
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Range(1, int.MaxValue)]
        public int ChefID { get; set; }

        [Range(2, 12)]
        public int Yield { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

        [Required]
        public bool Archived { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TypeID { get; set; }
    }
}
