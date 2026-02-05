using MediatR;
using ProductManagement.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>

    {
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(IProductRepository repository) {
            _repository = repository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken) {
            var product = Product.Create(request.Name,
                request.Description,
                request.Price,
                request.StockQuantity
                );

                
            await _repository.AddAsync(product,cancellationToken);

            return product.Id;
        }
    }
}
