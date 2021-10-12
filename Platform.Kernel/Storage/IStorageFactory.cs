using System.Threading.Tasks;

namespace Platform.Kernel.Storage
{
    public interface IStorageFactory<TIdentifier>
    {
        Task<IStorage<TIdentifier>> GetStorage<T>(T connection);
    }
}
