using MongoDB.Driver;
using OgrenciKayitSistemi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Services
{
    public class Repository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> _collection;

        public Repository(DBContext db)
        {
            _collection = db.Database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> Get() => await _collection.Find(q => true).ToListAsync();


        public async Task<T> Get(string id)
        {
            return await _collection.Find(q => q.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> Create(T item)
        {
            await _collection.InsertOneAsync(item);
            return item;
        }
        public async Task<bool> Update(string id, T itemIn)
        {
            ReplaceOneResult res = await _collection.ReplaceOneAsync(item => item.Id == id, itemIn);
            return res.IsAcknowledged;
        }


        public async void Remove(string id)
        {
            _ = await _collection.DeleteOneAsync(item => item.Id == id);
        }
    }
}
