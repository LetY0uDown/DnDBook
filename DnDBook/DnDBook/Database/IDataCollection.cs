using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnDBook.Database
{
    public interface IDataCollection<T> where T : DBEntity
    {
        Task<int> AddAsync(T item);

        Task RemoveAsync(T item);

        Task<T> GetAsync(int id);

        List<T> Values { get; }
    }
}