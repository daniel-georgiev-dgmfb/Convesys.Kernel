using System.Threading.Tasks;

namespace Twilight.Kernel.Storage
{
    public interface IStorageConnectionManager<TClient> where TClient : class
    {
        Task<TClient> GetStorageClient();
    }
}
