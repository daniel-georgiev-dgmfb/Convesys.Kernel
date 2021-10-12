using System.Threading.Tasks;

namespace Platform.Kernel.Storage
{
    public interface IStorageConnectionManager<TClient> where TClient : class
    {
        Task<TClient> GetStorageClient();
    }
}
