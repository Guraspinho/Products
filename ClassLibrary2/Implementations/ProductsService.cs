using Data;
using Domain;
using Services.Abstractions;

namespace Services.Implementations
{
    public class ProductsService : IProductsService
    {
        public AppDbContext appDbContext { get; set; }

        public ProductsService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void CreateProduct(ProductModel product)
        {
            appDbContext.Add(product);
            appDbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var doesProductExist = appDbContext.Products.FirstOrDefault(p => p.Id == id);

            if (doesProductExist != null)
            {
                appDbContext.Products.Remove(doesProductExist);
            }
        }

        public List<ProductModel> GetProductByCategory(int categoryId)
        {
            var products = appDbContext.Products.Where(p => p.CategoryId == categoryId).ToList();

            if (products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("No products found for the given category");
            }
        }

        public ProductModel GetProductById(int id)
        {
            var product = appDbContext.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Unable to find a product with a given id");
            }
        }

        public decimal GetProductPriceByCategory(int categoryId)
        {
            var productQuery = appDbContext.Products.Where(p => p.CategoryId == categoryId);

            if (!productQuery.Any())
            {
                throw new Exception("No products found for this category");
            }

            return productQuery.Sum(x => x.Price);
        }

        public List<decimal> GetProductPricePerCategory()
        {
            return appDbContext.Products
                .GroupBy(p => p.CategoryId)
                .Select(g => g.Sum(x => x.Price))
                .ToList();
        }

        public List<ProductModel> GetProducts()
        {
            return appDbContext.Products.ToList();
        }

        public void UpdateProduct(ProductModel product)
        {
            var doesProductExist = appDbContext.Products.FirstOrDefault(product => product.Id == product.Id);

            if (doesProductExist != null)
            {
                appDbContext.Update(product);
                appDbContext.SaveChanges();
            }
        }
    }
}
