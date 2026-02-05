using ProductManagement.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _context;
        public ProductRepository(IApplicationDbContext context) { _context = context; }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return await _context.Products.FindAsync(new object[] { id }, cancellation);
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);


        }
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var product = await GetByIdAsync(id, cancellationToken);
            if (product == null)
            {
                throw new KeyNotFoundException($"notttt existtt with that id {id}");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

        }
        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
