using System.Threading.Tasks;

namespace Convesys.Kernel.Storage
{
    public interface IStorageFactory<TIdentifier>
    {
        Task<IStorage<TIdentifier>> GetStorage<T>(T connection);
    }
}
