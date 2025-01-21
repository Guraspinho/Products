
using Domain;

namespace Services.Abstractions
{
    public interface IProductsService
    {
        public List<ProductModel> GetProducts();
        public ProductModel GetProductById(int id);
        public void CreateProduct(ProductModel product);
        public void UpdateProduct(ProductModel product);
        public void DeleteProduct(int id);
        public List<ProductModel> GetProductByCategory(int categoryId);
        public decimal GetProductPriceByCategory(int categoryId);
        public List<decimal> GetProductPricePerCategory();

    }
}
