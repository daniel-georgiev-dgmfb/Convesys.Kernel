using System.IO;
using System.Threading.Tasks;

namespace Platform.Kernel.Serialisation
{
    public interface ISerialiser
    {
        Task<Stream> Serialise(object obj);

        Task<bool> TrySerialise(object obj, out Stream stream);

        Task<object> Deserialise(Stream stream);

        Task<T> Deserialise<T>(Stream stream);
    }
}