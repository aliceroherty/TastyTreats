using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace TastyTreats.Model.Entities
{
    public class ValidationError
    {
        public ValidationError(string description, ErrorType type)
        {
            ErrorDescription = description;
            Type = type;
        }
        
        public ValidationError(string description, ErrorType type, string errorName)
        {
            ErrorDescription = description;
            Type = type;
            ErrorName = errorName;
        }

        public string ErrorNumber { get; set; }

        public string ErrorName { get; set; }

        public string ErrorDescription { get; set; }

        public ErrorType Type { get; set; }
    }
}
