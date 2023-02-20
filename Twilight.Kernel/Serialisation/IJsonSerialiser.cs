using System.Threading.Tasks;

namespace Convesys.Kernel.Serialisation
{
    public interface IJsonSerialiser : ISerialiser
    {
        Task<string> SerialiseToJson(object obj);
        Task<object> DeserialiseFromJson(string json);
        Task<T> DeserialiseFromJson<T>(string json);
    }
}