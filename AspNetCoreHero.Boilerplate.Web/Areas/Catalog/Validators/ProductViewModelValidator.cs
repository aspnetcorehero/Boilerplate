using AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Validators
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {

        public ProductViewModelValidator()
        {
            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }
    }
}
