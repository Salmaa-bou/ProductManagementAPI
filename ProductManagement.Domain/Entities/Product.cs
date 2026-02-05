using ProductManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Entities
{
   public class Product : BaseEntity

    {
        public String Name { get; private set; } = string.Empty;
        public String Description { get; private set; } = String.Empty;
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool IsActive { get; private set; }
        //private constr for EF core 
        private Product() { }
        public static Product Create(string name, string description, decimal price, int stockQuantity)
        {

            //business rule validation
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("product name cannot be empty", nameof(name));
            if (price <= 0)
                throw new ArgumentException("price cannot be negative or null enter num greater than zeroooooooooo", nameof(price));
            if (stockQuantity < 0)
                throw new ArgumentException("safee bayna", nameof(stockQuantity));
            return new Product
            {
                Name = name,
                Description = description ?? string.Empty,
                Price = price,
                StockQuantity = stockQuantity,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };
        }
        public void UpdateDetails(string name, string description, decimal price)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("product name cannot be empty", nameof(name));
            if (price <= 0)
                throw new ArgumentException("price cannot be negative or null enter num greater than zeroooooooooo", nameof(price));
            Name = name;
            Description = description;
            Price = price;
            UpdatedAt = DateTime.UtcNow;

        }
        public void UpdateStock(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("safee bayna", nameof(quantity));
            StockQuantity += quantity;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Active()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Desactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}