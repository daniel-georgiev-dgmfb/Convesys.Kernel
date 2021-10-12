using System.Threading.Tasks;

namespace Platform.Kernel.Security.SecretManagement
{
    public interface ISecretStore
    {
        string StoreLocation { get; }
        Task<string> GetSecret(SecretContext secretContext);
    }
}