using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnDBook.Database
{
    public sealed class DataCollection<T> : IDataCollection<T> where T : DBEntity
    {
        private static int autoIncrement = 1;

        private readonly List<T> _data = new List<T>();

        public List<T> Values => new List<T>(_data);

        public Task<int> AddAsync(T item)
        {
            item.ID = autoIncrement++;

            _data.Add(item);

            return Task.FromResult(item.ID);
        }

        public Task<T> GetAsync(int id)
        {
            var entity = _data.Find(e => e.ID == id);

            return Task.FromResult(entity);
        }

        public Task RemoveAsync(T item)
        {
            _data.Remove(item);

            return Task.CompletedTask;
        }
    }
}