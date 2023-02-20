using System.Threading.Tasks;

namespace Convesys.Kernel.Storage
{
    public interface IStorage<TIndentifier>
    {
        Task AddAsync<TData>(TData data, TIndentifier id, string key);
        Task AddAsync<TData>(TData data, TIndentifier id, string key, string objectName);
        Task<TData> GetAsync<TData>(TIndentifier id, string key);
        Task<TData> GetAsync<TData>(TIndentifier id, string key, string objectName);
        Task RemoveAsync(TIndentifier id, string key);
        Task RemoveAsync(TIndentifier id, string key, string objectName);
        Task RemoveAllAsync(TIndentifier transactionId);
    }
}
