using StoreApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace StoreApi.Services
{
    public class ProductsService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductsService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        //GET List All/Products
        public List<Product> Get() => _products.Find(Product => true).ToList();

        //GET Id/Product
        public Product Get(string id) => _products.Find<Product>(product => product.Id == id).FirstOrDefault();

        //POST Create/Product
        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        //PUT Update/Product
        public void Update(string id, Product productIn) => _products.ReplaceOne(product => product.Id == id, productIn);

        //DELETE remove All/Product
        public void Remove(Product productIn) => _products.DeleteOne(product => product.Id == productIn.Id);

        //DELETE Id/Product
        public void Remove(string id) => _products.DeleteOne(product => product.Id == id);
    }
}