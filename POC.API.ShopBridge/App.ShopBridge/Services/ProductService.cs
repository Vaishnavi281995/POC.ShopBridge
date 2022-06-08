using App.ShopBridge.Models;
using App.ShopBridge.Respository;

namespace App.ShopBridge.Services
{
    public class ProductService
    {
        public ProductRepository productRepository;
        public ProductService()
        {
            productRepository = new ProductRepository();
        }


        public async Task<IList<ProductModel>> Get(string connString)
        {
            productRepository.connectionString = connString;
            return await this.productRepository.Get();
        }

        public async Task<ProductModel> Get(int id, string connString)
        {
            productRepository.connectionString = connString;
            return await this.productRepository.Get(id);
        }

        public async Task<string> Post( ProductModel input, string connString)
        {
            productRepository.connectionString = connString;
            return await this.productRepository.Post(input);
        }

        public async Task<string> Put(int id,  ProductModel input, string connString)
        {
            productRepository.connectionString = connString;
            return await this.productRepository.Put(id, input);
        }

        public async Task<string> Delete(int id, string connString)
        {
            productRepository.connectionString = connString;
            return await this.productRepository.Delete(id);
        }
    }
}
