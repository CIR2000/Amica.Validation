using System;
using Amica.Models;
using FluentValidation;

namespace Amica.Validation {
    public class ProductValidator : AbstractValidator<Product> {
        public ProductValidator() {
            RuleFor(product => product.Name)
                .NotEmpty()
                .When(product => string.IsNullOrEmpty(product.Description));

            RuleFor(product => product.Description)
                .NotEmpty()
                .When(product => string.IsNullOrEmpty(product.Name));
        }
    }
}