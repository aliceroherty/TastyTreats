using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyTreats.Model.DTO
{
    public class ChefLookupDTO
    {
        [Display(Name = "Chef ID")]
        public int ID { get; set; }

        [Display(Name = "Chef")]
        public string Name { get; set; }
    }
}
