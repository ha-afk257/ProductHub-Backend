using ProductHub.Models;

namespace ProductHub.Repositories
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99, Description = "A powerful laptop" },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99, Description = "Latest smartphone model" }
        };

        private static long _nextId = 3;

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(long id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }

        public Product Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return product;
        }

        public bool Update(long id, Product updatedData)
        {
            var productToUpdate = _products.SingleOrDefault(p => p.Id == id);
            if (productToUpdate == null)
                return false;

            productToUpdate.Name = updatedData.Name;
            productToUpdate.Price = updatedData.Price;
            productToUpdate.Description = updatedData.Description;
            return true;
        }

        public bool Delete(long id)
        {
            var product = _products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return false;

            _products.Remove(product);
            return true;
        }
    }
}
