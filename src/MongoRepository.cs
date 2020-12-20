using System.Collections.Generic;
using Minify.Interfaces;
using Minify.Model;
using MongoDB.Driver;

namespace Minify{
    public class MongoRepository : IRepository
    {
        private IMongoDatabase database;
        public MongoRepository(){
            var client = new MongoClient(
                                "mongodb+srv://<user>:<password>@<cluster>"
                            );
            database = client.GetDatabase("Epsi");
        }
        public void Add(MinifyData minifyData)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MinifyData> Get()
        {
            throw new System.NotImplementedException();
        }

        public MinifyData Get(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}