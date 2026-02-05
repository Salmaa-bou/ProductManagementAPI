using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Application.Products.DTOs;


namespace ProductManagement.Application.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IApplicationDbContext _context;
        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ProductDto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(p => p.Id == query.Id).Select(p => new ProductDto
                {
                Id = p.Id,
                Name= p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt

            }).FirstOrDefaultAsync(cancellationToken);
            if (product == null) 
                throw new KeyNotFoundException($" that produuuuct makaynsh {query.Id}"
        );

            return product;
        }
    }
}
