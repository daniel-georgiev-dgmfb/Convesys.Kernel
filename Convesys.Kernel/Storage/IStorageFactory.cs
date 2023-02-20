using System.Threading.Tasks;

namespace Twilight.Kernel.Storage
{
    public interface IStorageFactory<TIdentifier>
    {
        Task<IStorage<TIdentifier>> GetStorage<T>(T connection);
    }
}
