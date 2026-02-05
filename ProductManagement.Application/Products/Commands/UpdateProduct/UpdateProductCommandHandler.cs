using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Application.Common.Interfaces;

namespace ProductManagement.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;

        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
                
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found ");
            product.UpdateDetails(request.Name, request.Description, request.Price);
            product.UpdateStock(request.StockQuantity);
            await _repository.UpdateAsync(product,cancellationToken);
            return Unit.Value;
        }


    }
}
