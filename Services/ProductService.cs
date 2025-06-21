using System.Collections.Generic;
using System.Linq;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Pen", Price = 10 },
            new Product { Id = 2, Name = "Notebook", Price = 50 },
            new Product { Id=3, Name="Anil",Price=100},
            new Product { Id=4 , Name="Jeff", Price=200}
        };

        public List<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void Update(int id, Product updated)
        {
            var product = GetById(id);
            if (product == null) return;
            product.Name = updated.Name;
            product.Price = updated.Price;
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null) _products.Remove(product);
        }
    }
}