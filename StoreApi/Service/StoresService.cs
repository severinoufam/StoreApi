using StoreApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace StoreApi.Services
{
    public class StoresService
    {
        private readonly IMongoCollection<Store> _stores;

        public StoresService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _stores = database.GetCollection<Store>(settings.StoreCollectionName);
        }

        //GET List All/Stores
        public List<Store> Get() => _stores.Find(Store => true).ToList();

        //GET Id/Store
        public Store Get(string id) => _stores.Find<Store>(store => store.Id == id).FirstOrDefault();

        //POST Create/Store
        public Store Create(Store store)
        {
            _stores.InsertOne(store);
            return store;
        }

        //PUT Update/Store
        public void Update(string id, Store storeIn) => _stores.ReplaceOne(store => store.Id == id, storeIn);

        //DELETE remove All/Stores
        public void Remove(Store storeIn) => _stores.DeleteOne(store => store.Id == storeIn.Id);

        //DELETE Id/Store
        public void Remove(string id) => _stores.DeleteOne(store => store.Id == id);
    }
}