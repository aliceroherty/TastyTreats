using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyTreats.Model.Entities
{
    public class BaseEntity
    {
        public List<ValidationError> Errors { get; set; } = new List<ValidationError>();

        public void AddError(ValidationError error)
        {
            Errors.Add(error);
        }
    }
}
