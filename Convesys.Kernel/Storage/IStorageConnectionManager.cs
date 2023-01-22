using System.Threading.Tasks;

namespace Convesys.Kernel.Storage
{
    public interface IStorageConnectionManager<TClient> where TClient : class
    {
        Task<TClient> GetStorageClient();
    }
}
