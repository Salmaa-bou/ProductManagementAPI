using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>

    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(200).WithMessage("product name must not exceed 200 char ");
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description ...............1000 char");
            RuleFor(x => x.Price)
                    .GreaterThan(0).WithMessage("price must be greater than 0");
            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be positive guuuys");
        }
    }
    }
