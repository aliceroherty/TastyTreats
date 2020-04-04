using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTreats.Model.Entities;
using TastyTreats.Repository;
using Types;

namespace TastyTreats.Service
{
    public class ReviewService
    {
        ReviewRepo repo = new ReviewRepo();

        public bool AddReview(Review review)
        {
            if (Validate(review))
            {
                return repo.Add(review);
            }
            else
            {
                return false;
            }
        }

        private bool Validate(Review r)
        {
            ValidationContext context = new ValidationContext(r);
            List<ValidationResult> results = new List<ValidationResult>();

            Validator.TryValidateObject(r, context, results);

            foreach (ValidationResult result in results)
            {
                r.AddError(new ValidationError(result.ErrorMessage, ErrorType.Model, result.GetType().ToString()));
            }

            return r.Errors.Count == 0;
        }
    }
}
