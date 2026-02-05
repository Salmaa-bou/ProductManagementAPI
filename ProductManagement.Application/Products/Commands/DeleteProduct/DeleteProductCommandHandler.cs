using MediatR;
using ProductManagement.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Entities;


namespace ProductManagement.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>

    {
        private readonly IProductRepository _repository;
        public DeleteProductCommandHandler(IProductRepository  context) { _repository = context; }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id,cancellationToken);

            if(product == null )
                throw new KeyNotFoundException($"Product woth ID {request.Id} not found");



            await _repository.DeleteAsync(request.Id,cancellationToken);
            

            return Unit.Value;
                    }
    }
}
