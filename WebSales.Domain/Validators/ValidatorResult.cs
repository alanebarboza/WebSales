using FluentValidation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WebSales.Domain.Validators
{
    public static class ValidatorResult<T> where T : class
    {
        public static ICollection<string> Validate(AbstractValidator<T> validator, T objecToValidate)
        {
            var result = validator.Validate(objecToValidate);
            return (result.Errors.Count > 0 ? result.Errors.ToList().Select(x => x.ErrorMessage).ToArray() : new Collection<string>());
        }
    }
}
