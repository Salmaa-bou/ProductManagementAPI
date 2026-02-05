using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProductManagement.Application.Products.DTOs;

namespace ProductManagement.Application.Products.Queries.GetAllProducts
{
    public  class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
