using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;

namespace ProductManagement.Application.Products.Commands.DeleteProduct
{
   public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() {
            RuleFor(x => x.Id)
                    .GreaterThan(0).WithMessage("Invaliiiiiiid Id ");
        }
    }
}
