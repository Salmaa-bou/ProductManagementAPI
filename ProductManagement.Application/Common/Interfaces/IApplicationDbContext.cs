using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProductManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ProductManagement.Application.Common.Interfaces
{
  public interface IApplicationDbContext
    {
        public DbSet<Product>  Products { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
